using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PFW.CSIST203.Project1.Tests
{
    /// <summary>
    /// Base class for all test harnesses
    /// </summary>
    public abstract class TestBase : System.IDisposable
    {
        /// <summary>
        /// Get a value indicating whether the current test object has been disposed
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// A logging object named for the current testing harness
        /// </summary>
        protected log4net.ILog logger;

        /// <summary>
        /// The working directory where the application was original ran from
        /// </summary>
        protected static readonly string OriginalWorkingDirectory;

        /// <summary>
        /// Static constructor that retains the original working directory for the Setup() method
        /// </summary>
        static TestBase()
        {
            OriginalWorkingDirectory = System.IO.Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Provides test initialization logic
        /// </summary>
        [TestInitialize]
        public virtual void Setup()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
            logger = log4net.LogManager.GetLogger(this.GetType());
            System.IO.Directory.SetCurrentDirectory(OriginalWorkingDirectory);
        }

        /// <summary>
        /// Provides test cleanup logic
        /// </summary>
        [TestCleanup]
        public void Dispose()
        {
            if (!isDisposed)
            {
                log4net.LogManager.Shutdown();
                isDisposed = true;
            }
        }

        /// <summary>
        /// Utility method that retrieves a method-specific logger
        /// </summary>
        /// <returns>A log4net logging object named for the current stack frame method</returns>
        protected log4net.ILog GetMethodLogger()
        {
            return GetMethodLogger(2);
        }

        /// <summary>
        /// Utility method that retrieves a method-specific logger at the specified frame
        /// </summary>
        /// <param name="frame">The frame level to name the logger</param>
        /// <returns>A log4net logging object named for the specified stack frame method</returns>
        protected log4net.ILog GetMethodLogger(int frame)
        {
            var stackTrace = new System.Diagnostics.StackTrace();
            return log4net.LogManager.GetLogger(stackTrace.GetFrame(frame).GetMethod().Name);
        }

        /// <summary>
        /// Helper method that asserts delegate execution was successful
        /// </summary>
        /// <param name="action">Delegate that should not throw an exception</param>
        /// <param name="message">The message to log when the delegate execution does not succeed</param>
        protected void AssertDelegateSuccess(Action action, string message)
        {
            try
            {
                action.Invoke();
            }
            catch (System.Exception ex)
            {
                var log = GetMethodLogger(2);
                var msg = "Error during delegate execution";
                log.Error(msg, ex);
                throw;
            }
        }

        /// <summary>
        /// Helper method that asserts delegate execution was a failure
        /// </summary>
        /// <param name="action">The delegate action to execute</param>
        /// <param name="exceptionType">The type of exception that should be thrown</param>
        /// <param name="message">A message describing what no thrown exception means</param>
        protected void AssertDelegateFailure(Action action, Type exceptionType, string message)
        {
            Assert.IsNotNull(exceptionType, "Null exception type was supplied, but this cannot be tested for");
            try
            {
                action.Invoke();
                Assert.Fail("The delegate did not throw the intended exception: " + exceptionType.FullName);
            }
            catch (System.Exception ex)
            {
                if (ex.GetType() != exceptionType)
                {
                    var msg = String.Format("Delegate threw exception of type '{0}', but expected '{1}': {2}", ex.GetType(), exceptionType, message);
                    var log = GetMethodLogger(2);
                    log.Error(msg, ex);
                    Assert.Fail(msg);
                }
            }
        }

        /// <summary>
        /// Retrieves a clean working directory for use by a testing method
        /// </summary>
        /// <returns>A full directory path pointing to the root location on disk suitable for a unit test</returns>
        protected string GetMethodSpecificWorkingDirectory()
        {
            return GetMethodSpecificWorkingDirectory(
                System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile),
                3
            );
        }

        /// <summary>
        /// Retrieves a clean working directory for use by a testing method
        /// </summary>
        /// <param name="baseDirectory">The root folder where the Test subdirectory will be created</param>
        /// <param name="depth">Frame depth used to retrieve the name of the test directory</param>
        /// <returns>A full directory path pointing to the root location on disk suitable for a unit test</returns>
        protected string GetMethodSpecificWorkingDirectory(string baseDirectory, int depth)
        {
            return GetMethodSpecificWorkingDirectory(baseDirectory, depth, true);
        }

        /// <summary>
        /// Retrieves a clean working directory for use by a testing method
        /// </summary>
        /// <param name="baseDirectory">The root folder where the Test subdirectory will be created</param>
        /// <param name="depth">Frame depth used to retrieve the name of the test directory</param>
        /// <param name="setWorkingDirectory">Should the current working directory be changed?</param>
        /// <returns>A full directory path pointing to the root location on disk suitable for a unit test</returns>
        protected string GetMethodSpecificWorkingDirectory(string baseDirectory, int depth, bool setWorkingDirectory)
        {
            var stackTrace = new System.Diagnostics.StackTrace();

            // This handles anonymous method invokation and the two frames added by using it
            var method = stackTrace.GetFrame(depth).GetMethod();
            if (method.DeclaringType.FullName.IndexOf("<>") >= 0)
            {
                method = stackTrace.GetFrame(depth + 2).GetMethod();
            }

            // handle any number of nested lambda functions
            if (System.Text.RegularExpressions.Regex.IsMatch(method.Name, "\\<.*\\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                var tmpDepth = depth;
                while (System.Text.RegularExpressions.Regex.IsMatch(method.Name, "\\<.*\\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    tmpDepth += 2;
                    method = stackTrace.GetFrame(tmpDepth).GetMethod();
                }
            }

            var methodEncapsulatingClass = method.DeclaringType;
            var methodEncapsulatingClassName = TrimStringFromEnd(methodEncapsulatingClass.Name, "Method", true);
            var encapsulatingClass = methodEncapsulatingClass.BaseType;
            var encapsulatingClassName = TrimStringFromEnd(encapsulatingClass.Name, "Tests", true); // SystemTests

            // calculate a shortened file structure path when the folder path exceeds OS limits
            // NOTE: It is still possible the base directory location is too long and failure could still occur
            var finalBase = System.IO.Path.Combine(baseDirectory, "Tests", encapsulatingClassName);
            var md5hash = string.Empty;
            if (finalBase.Length + methodEncapsulatingClassName.Length + method.Name.Length + 3 >= 247)
            {
                using (var hash = System.Security.Cryptography.MD5.Create())
                {
                    var tmp = methodEncapsulatingClassName + "\\" + method.Name;
                    var bytes = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(tmp));
                    md5hash = new System.Guid(bytes).ToString();
                }
            }

            var finalDirectory = string.IsNullOrWhiteSpace(md5hash) ?
                System.IO.Path.Combine(finalBase, methodEncapsulatingClassName, method.Name) :
                System.IO.Path.Combine(finalBase, md5hash);

            // https://social.technet.microsoft.com/Forums/windows/en-US/43945b2c-f123-46d7-9ba9-dd6abc967dd4/maximum-path-length-limitation-on-windows-is-255-or-247?forum=w7itprogeneral
            if (finalDirectory.Length >= 247)
            {
                throw new ArgumentException("Unable to create testing directory because it is too long: " + finalDirectory);
            }

            if (setWorkingDirectory)
            {
                System.IO.Directory.CreateDirectory(finalDirectory);
                System.IO.Directory.SetCurrentDirectory(finalDirectory);
            }

            return finalDirectory;
        }

        /// <summary>
        /// Retrieves a clean working directory for use by the testing method specified at the given stack frame and base directory
        /// </summary>
        /// <returns>full path to the a working test directory</returns>
        protected string GetCleanWorkingTestDirectory()
        {
            return GetCleanWorkingTestDirectory(true);
        }

        /// <summary>
        /// Retrieves a clean working directory for use by the testing method specified at the given stack frame and base directory
        /// </summary>
        /// <param name="cleanWorkingDirectory">Should the folder be cleaned before the test runs?</param>
        /// <returns>full path to the a working test directory</returns>
        protected string GetCleanWorkingTestDirectory(bool cleanWorkingDirectory)
        {
            return GetCleanWorkingTestDirectory(
                System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile),
                3,
                cleanWorkingDirectory
            );
        }

        /// <summary>
        /// Retrieves a clean working directory for use by the testing method specified at the given stack frame and base directory
        /// </summary>
        /// <param name="depth">Frame depth used to determine the name of the test folder</param>
        /// <param name="cleanWorkingDirectory">Should the folder be cleaned before the test runs?</param>
        /// <returns>full path to the a working test directory</returns>
        protected string GetCleanWorkingTestDirectory(int depth, bool cleanWorkingDirectory)
        {
            return GetCleanWorkingTestDirectory(
                System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile),
                depth,
                cleanWorkingDirectory
            );
        }

        /// <summary>
        /// Retrieves a clean working directory for use by the testing method specified at the given stack frame and base directory
        /// </summary>
        /// <param name="baseDirectory">The base directroy from which to create the test directory</param>
        /// <param name="depth">Frame depth used to determine the name of the test folder</param>
        /// <param name="cleanWorkingDirectory">Should the folder be cleaned before the test runs?</param>
        /// <returns>full path to the a working test directory</returns>
        protected string GetCleanWorkingTestDirectory(string baseDirectory, int depth, bool cleanWorkingDirectory)
        {
            return GetCleanWorkingTestDirectory(baseDirectory, depth, cleanWorkingDirectory, true);
        }

        /// <summary>
        /// Retrieves a clean working directory for use by the testing method specified at the given stack frame and base directory
        /// </summary>
        /// <param name="baseDirectory">The base directroy from which to create the test directory</param>
        /// <param name="depth">Frame depth used to determine the name of the test folder</param>
        /// <param name="cleanWorkingDirectory">Should the folder be cleaned before the test runs?</param>
        /// <param name="setWorkingDirectory">Should the working directory be set to the test folder upon retrieval</param>
        /// <returns>full path to the a working test directory</returns>
        protected string GetCleanWorkingTestDirectory(string baseDirectory, int depth, bool cleanWorkingDirectory, bool setWorkingDirectory)
        {
            var testDirectory = GetMethodSpecificWorkingDirectory(baseDirectory, depth + 1, setWorkingDirectory);
            logger.Info(String.Format("Working Directory: {0}", testDirectory));
            if (cleanWorkingDirectory && System.IO.Directory.Exists(testDirectory))
            {
                System.IO.Directory.Delete(testDirectory, true);
            }
            System.IO.Directory.CreateDirectory(testDirectory);
            return testDirectory;
        }

        /// <summary>
        /// Utility method that takes embedded resources located at the designated location and copies them into a target directory
        /// </summary>
        /// <param name="embeddedResourceBase"></param>
        /// <param name="targetDirectory"></param>
        protected void CopyEmbeddedResourceBaseToDirectory(string embeddedResourceBase, string targetDirectory)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames();
            foreach (var resource in resources)
            {
                if (resource.StartsWith(embeddedResourceBase))
                {

                    // perform some basic fixing
                    var fixedResourceName = resource.Replace("._", ".");

                    var resourceRelativePathCompontents = fixedResourceName.Replace(embeddedResourceBase, string.Empty).TrimStart('.').Split('.');
                    var resourceRelativePath = string.Join("\\", resourceRelativePathCompontents, 0, resourceRelativePathCompontents.Length - 1)
                        + "." + resourceRelativePathCompontents[resourceRelativePathCompontents.Length - 1];

                    // calculate the relative path of the file's output location
                    var targetPath = System.IO.Path.Combine(targetDirectory, resourceRelativePath);

                    var Directory = System.IO.Path.GetDirectoryName(targetPath);
                    System.IO.Directory.CreateDirectory(Directory);

                    // copy the input to the output stream
                    using (var output = System.IO.File.OpenWrite(targetPath))
                    {
                        using (var input = assembly.GetManifestResourceStream(resource))
                        {
                            var b1 = System.Convert.ToByte(input.ReadByte());
                            var b2 = System.Convert.ToByte(input.ReadByte());
                            var b3 = System.Convert.ToByte(input.ReadByte());

                            var data = new byte[] { b1, b2, b3 };
                            var str = System.Text.Encoding.Default.GetString(data);

                            if (IsASCII(str))
                                input.Seek(0, System.IO.SeekOrigin.Begin);
                            else
                                input.Seek(3, System.IO.SeekOrigin.Begin);
                            input.CopyTo(output, 4096);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Utility function for determining whether the supplied string falls into the ASCII character set
        /// </summary>
        /// <param name="value">A string that may or may not only use ASCII characters</param>
        /// <returns>True if all characters are part of the ASCII character set, otherwise false</returns>
        internal static bool IsASCII(string value)
        {
            return System.Text.Encoding.UTF8.GetByteCount(value) == value.Length;
        }

        /// <summary>
        /// Utility function for trimming a string located at the end of the supplied input string
        /// </summary>
        /// <param name="str">The input string to evaluate</param>
        /// <param name="removalString">The string that should be trimmed from the end if present</param>
        /// <param name="ignoreCase">Should the match be case insensitive</param>
        /// <returns>The trimmed string or the original string if the matched string was not found at the end</returns>
        internal static string TrimStringFromEnd(string str, string removalString, bool ignoreCase)
        {
            var result = string.IsNullOrWhiteSpace(str) ? null : str.Trim();
            if (!String.IsNullOrWhiteSpace(removalString))
            {
                var comparison = ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
                if (!String.IsNullOrWhiteSpace(result) && result.EndsWith(removalString, comparison))
                {

                    // look for the last occurrance of the supplied string
                    var index = result.LastIndexOf(removalString, comparison);

                    // is the discovered string located at the end?
                    if (index + removalString.Length == result.Length)
                    {
                        // remove the trailing string from the supplied input string
                        result = result.Substring(0, index).Trim();
                    }

                }
            }
            return result;
        }
    }
}
