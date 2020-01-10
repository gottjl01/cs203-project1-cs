using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PFW.CSIST203.Project1.Tests
{

    /// <summary>
    /// A collection of tests that verify the functionality of the testing harness itself
    /// </summary>
    public abstract class SystemTests : TestBase
    {

        /// <summary>
        /// Test harness for GetMethodLogger()
        /// </summary>
        [TestClass]
        public class GetMethodLoggerMethod : SystemTests
        {

            /// <summary>
            /// Verify the log4net logging object has the correct name for the current executing method
            /// </summary>
            [TestMethod]
            public void LoggerNameMatchesCallingMethodName()
            {
                var log = GetMethodLogger();
                var stackTrace = new System.Diagnostics.StackTrace();
                Assert.IsNotNull(stackTrace.GetFrame(0), "Stack Trace Frame(0) information object could not be created");
                Assert.IsNotNull(stackTrace.GetFrame(0).GetMethod(), "Stack Trace Frame(0) method information could not be retrieved");
                Assert.IsTrue(!string.IsNullOrWhiteSpace(stackTrace.GetFrame(0).GetMethod().Name), "Stack Trace Frame(0) method name not found");
                var methodName = stackTrace.GetFrame(0).GetMethod().Name;
                Assert.AreEqual(log.Logger.Name, methodName, "Failed to match method name to logger name");
            }

            /// <summary>
            /// Verify the log4net logging object has the correct name for the current executing method
            /// </summary>
            [TestMethod]
            public void LoggerNameMatchesForAnyFrameLevel()
            {
                var log = GetMethodLogger(1);
                var stackTrace = new System.Diagnostics.StackTrace();
                Assert.IsNotNull(stackTrace.GetFrame(0), "Stack Trace Frame(0) information object could not be created");
                Assert.IsNotNull(stackTrace.GetFrame(0).GetMethod(), "Stack Trace Frame(0) method information could not be retrieved");
                Assert.IsTrue(!string.IsNullOrWhiteSpace(stackTrace.GetFrame(0).GetMethod().Name), "Stack Trace Frame(0) method name not found");
                var methodName = stackTrace.GetFrame(0).GetMethod().Name;
                Assert.AreEqual(log.Logger.Name, methodName, "Failed to match method name to logger name");
            }
        }

        /// <summary>
        /// Verify the state of the testing object is correct after the setup method has been called
        /// </summary>
        [TestClass]
        public class SetupMethod : SystemTests
        {
            [TestMethod]
            public void RootLoggerWasAssigned()
            {
                Assert.IsNotNull(this.logger, "Failed to assign root logger object");
                Assert.AreEqual(OriginalWorkingDirectory, System.IO.Directory.GetCurrentDirectory(), "The current working directory does not match the original working directory prior to test start");
            }
        }

        /// <summary>
        /// Testing harness for AssertDelegateSuccess
        /// </summary>
        [TestClass]
        public class AssertDelegateSuccessMethod : SystemTests
        {

            /// <summary>
            /// Verify the AssertDelegateSuccess does not throw an exception under normal operation
            /// </summary>
            [TestMethod]
            public void TestDelegateDidNotThrowException()
            {
                AssertDelegateSuccess(() =>
                {
                }, "Exception was thrown unexpectedly when none should have occurred during custom assert delegate method"
);
            }

            /// <summary>
            /// Verify AssertDelegateSuccess indicates failure when an exception is thrown
            /// </summary>
            [TestMethod]
            public void TestDelegateDidThrowException()
            {
                var exception = new System.Exception();
                try
                {
                    AssertDelegateSuccess(() =>
                    {
                        throw exception;
                    }, "This exception was expected to be thrown"
);
                    Assert.Fail("An exception was thrown by custom delegate assert method and did not prevent execution as expected");
                }
                catch (Exception ex)
                {
                    if (exception != ex)
                        Assert.Fail("Unexpected exception type was thrown: " + ex.GetType().ToString());
                }
            }
        }

        /// <summary>
        /// Testing harness for AssertDelegateFailure
        /// </summary>
        [TestClass]
        public class AssertDelegateFailureMethod : SystemTests
        {

            /// <summary>
            /// Verify not throwing an exception causes failure
            /// </summary>
            [TestMethod]
            public void TestDelegateDidNotThrowException()
            {
                var notThrown = false;
                try
                {
                    AssertDelegateFailure(() =>
                    {
                    }, typeof(Exception), "Expected behavior: no exception was thrown, but one was expected"
);
                    notThrown = true;
                }
                catch (Exception ex)
                {
                }
                if (notThrown)
                    Assert.Fail("An exception was expected to be thrown, but one was not");
            }

            /// <summary>
            /// Verify throwing an exception exception causes success
            /// </summary>
            [TestMethod]
            public void TestDelegateDidThrowException()
            {
                var exception = new Exception();
                try
                {
                    AssertDelegateFailure(() =>
                    {
                        throw exception;
                    }, typeof(Exception), "Expected behavior: no exception was thrown, but one was expected"
);
                }
                catch (Exception ex)
                {
                    Assert.Fail("Error when delegate failure check: " + ex.Message);
                }
            }
        }

        /// <summary>
        ///         ''' Testing harness for GetMethodSpecificWorkingDirectory()
        ///         ''' </summary>
        [TestClass]
        public class GetMethodSpecificWorkingDirectoryMethod : SystemTests
        {

            /// <summary>
            /// Verify the name of the testing directory created is correct
            /// </summary>
            [TestMethod]
            public void IsDirectoryNameCorrect()
            {
                var stackTrace = new System.Diagnostics.StackTrace();
                var clazz = this.GetType();
                var category = clazz.BaseType;
                var method = stackTrace.GetFrame(0).GetMethod();
                var expected_directoryName = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Tests", TrimStringFromEnd(category.Name, "Tests", true), TrimStringFromEnd(clazz.Name, "Method", true), method.Name);

                // cananicalize the local directory path
                var expected = new System.Uri(expected_directoryName).LocalPath;
                var generated_directoryName = GetMethodSpecificWorkingDirectory();
                // cananicalize the local directory path
                var actual = new System.Uri(generated_directoryName).LocalPath;

                Assert.AreEqual(expected, actual, "The generated path is not consistent with the expected value");
                Assert.IsTrue(System.IO.Directory.Exists(actual), "The default method should have created the directory");
                Assert.AreEqual(0, System.IO.Directory.GetFiles(actual).Length, "The default method should have created an empty directory");
            }

            /// <summary>
            /// Verify the name of the testing directory is correct when using within a lambda function
            /// </summary>
            [TestMethod]
            public void IsDirectoryNameCorrectWithinLambda()
            {
                AssertDelegateSuccess(() =>
                {
                    var stackTrace = new System.Diagnostics.StackTrace();
                    var clazz = this.GetType();
                    var category = clazz.BaseType;
                    var method = stackTrace.GetFrame(2).GetMethod();
                    var expected_directoryName = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Tests", TrimStringFromEnd(category.Name, "Tests", true), TrimStringFromEnd(clazz.Name, "Method", true), method.Name);

                    // canonicalize the local directory path
                    var expected = new System.Uri(expected_directoryName).LocalPath;
                    var generated_directoryName = GetMethodSpecificWorkingDirectory();
                    // cananicalize the local directory path
                    var actual = new System.Uri(generated_directoryName).LocalPath;

                    Assert.AreEqual(expected, actual, "The generated path is not consistent with the expected value");
                    Assert.IsTrue(System.IO.Directory.Exists(actual), "The default method should have created the directory");
                    Assert.AreEqual(0, System.IO.Directory.GetFiles(actual).Length, "The default method should have created an empty directory");
                }, "No exception should have been thrown");
            }

            /// <summary>
            /// Verify the name of the testing directory is correct when using within any number of nested lambda functions
            /// </summary>
            [TestMethod]
            public void IsDirectoryNameCorrectWithinNestedLambda()
            {
                AssertDelegateSuccess(() =>
                {
                    Action nested1 = () =>
                    {
                        var stackTrace = new System.Diagnostics.StackTrace();
                        var clazz = this.GetType();
                        var category = clazz.BaseType;
                        var method = stackTrace.GetFrame(6).GetMethod();
                        var expected_directoryName = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Tests", TrimStringFromEnd(category.Name, "Tests", true), TrimStringFromEnd(clazz.Name, "Method", true), method.Name);

                        // cananicalize the local directory path
                        var expected = new System.Uri(expected_directoryName).LocalPath;
                        var generated_directoryName = GetMethodSpecificWorkingDirectory();
                        // cananicalize the local directory path
                        var actual = new System.Uri(generated_directoryName).LocalPath;
                        Assert.AreEqual(expected, actual, "The generated path is not consistent with the expected value");
                        Assert.IsTrue(System.IO.Directory.Exists(actual), "The default method should have created the directory");
                        Assert.AreEqual(0, System.IO.Directory.GetFiles(actual).Length, "The default method should have created an empty directory");
                    };

                    Action nested2 = () =>
                    {
                        nested1();
                    };
                    Action nested3 = () =>
                    {
                        nested2();
                    };
                    Action nested4 = () =>
                    {
                        nested3();
                    };

                    // attempt a heavily nested series of lambda functions
                    nested4();
                }, "No exception should have been thrown");
            }
        }

        /// <summary>
        ///         ''' Testing harness for the IsASCII() method
        ///         ''' </summary>
        [TestClass]
        public class IsASCIIMethod : SystemTests
        {

            /// <summary>
            /// Verifies that the helper method property detects all ASCII compatible characters
            /// </summary>
            [TestMethod]
            public void DetectsASCII()
            {
                for (int i = 0; i <= 127; i++)
                {
                    var SingleByte = new byte[] { System.Convert.ToByte(i) };
                    var SingleCharacterString = System.Text.Encoding.Default.GetString(SingleByte);
                    Assert.IsTrue(IsASCII(SingleCharacterString), "Did not detect character '" + SingleCharacterString + "' with code '" + i.ToString() + "' as ASCII");
                }
            }

            /// <summary>
            /// Verifies that the helper method property detects all non-ASCII compatible characters
            /// </summary>
            [TestMethod]
            public void DetectsNonASCII()
            {
                for (int i = 128; i <= 255; i++)
                {
                    var SingleByte = new byte[] { System.Convert.ToByte(i) };
                    var SingleCharacterString = System.Text.Encoding.Default.GetString(SingleByte);
                    Assert.IsFalse(IsASCII(SingleCharacterString), "Detected character '" + SingleCharacterString + "' with code '" + i.ToString() + "' as ASCII");
                }
            }
        }

        /// <summary>
        /// Testing harness for the TrimStringFromEnd() method
        /// </summary>
        [TestClass]
        public class TrimStringFromEndMethod : SystemTests
        {

            /// <summary>
            /// Verify the ignore case parameter works as expected
            /// </summary>
            [TestMethod]
            public void TrimsEndOfStringIgnoringCase()
            {
                var testingString = "A Simple Textual Example";
                Assert.AreEqual("A Simple Textual", TrimStringFromEnd(testingString, "Example", true));
                Assert.AreEqual("A Simple", TrimStringFromEnd(testingString, " textual example", true));
                Assert.AreEqual(testingString, TrimStringFromEnd(testingString, "A Simple", true));
            }

            /// <summary>
            /// Verify the case-sensitive replace works as expected
            /// </summary>
            [TestMethod]
            public void TrimsEndOfStringRespectingCase()
            {
                var testingString = "A Simple Textual Example";
                Assert.AreEqual("A Simple Textual", TrimStringFromEnd(testingString, "Example", false));
                Assert.AreEqual(testingString, TrimStringFromEnd(testingString, " textual example", false));
                Assert.AreEqual(testingString, TrimStringFromEnd(testingString, "A Simple", false));
            }

            /// <summary>
            /// Verify trailing whitespace has no impact on the trimming operation
            /// </summary>
            [TestMethod]
            public void TrimsEndOfStringIgnoringWhitespace()
            {
                var testingString = "A Simple Textual Example ";
                Assert.AreEqual("A Simple Textual", TrimStringFromEnd(testingString, "Example", true));
                Assert.AreEqual("A Simple", TrimStringFromEnd(testingString, " textual example", true));
                Assert.AreEqual(testingString.Trim(), TrimStringFromEnd(testingString, "A Simple", true));
            }

            /// <summary>
            /// Verify no exception is thrown with null or whitespace input or removal strings
            /// </summary>
            [TestMethod]
            public void NoExceptionOnNullOrWhitespace()
            {
                // Dim testingString = "A Simple Textual Example"
                AssertDelegateSuccess(() =>
                {
                    TrimStringFromEnd(string.Empty, "anything", true);
                    TrimStringFromEnd(null, "something", true);
                    TrimStringFromEnd("Nothing", string.Empty, true);
                    TrimStringFromEnd("Thing", null, true);
                    TrimStringFromEnd(null, null, true);
                    TrimStringFromEnd(string.Empty, string.Empty, true);
                }, "No exception should be thrown for null or whitespace strings");
            }

            /// <summary>
            /// Verify that the trim method does not impact the string more than once and only the final substring if it occurs more than once
            /// </summary>
            [TestMethod]
            public void DoesNotRemoveMoreThanOnce()
            {
                var testingString = "ATestATestATest";
                Assert.AreEqual("ATestATest", TrimStringFromEnd(testingString, "ATest", true));
            }
        }
    }
}
