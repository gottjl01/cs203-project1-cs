using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PFW.CSIST203.Project1.Tests.Functions
{
    public abstract class ArrayFunctionsTests : TestBase
    {

        /// <summary>
        /// Helper method designed to ensure that two arrays have elements that are equal
        /// </summary>
        /// <param name="arr1">The first array to check</param>
        /// <param name="arr2">The second array to check</param>
        /// <returns>True if the two arrays are non-null and their elements are exactly equal, otherwise false</returns>
        protected bool ArraysMatch(string[] arr1, string[] arr2)
        {
            var result = false;
            // arrays must be non-null and exact length for this comparison to occur
            if (arr1 != null && arr2 != null && arr1.Length == arr2.Length)
            {
                result = true;
                for (int i = 0; result && i <= arr1.Length - 1 & result; i++)
                    result = result & string.Equals(arr1[i], arr2[i]);
            }
            return result;
        }

        /// <summary>
        /// Constructor testing harness
        /// </summary>
        [TestClass]
        public class _Constructor : ArrayFunctionsTests
        {
            [TestMethod]
            public void Parameterless()
            {
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj = null;
                AssertDelegateSuccess(() =>
                {
                    obj = new Project1.Functions.ArrayFunctions();
                }, "Failed to instantiate object correctly using default constructor");
                Assert.IsNotNull(obj, "This object cannot be null");
                Assert.AreEqual(PFW.CSIST203.Project1.Functions.ArrayFunctions.DefaultPersistentFile, obj.PersistentFile);
                Assert.IsNotNull(obj.Randomizer);
            }

            [TestMethod]
            public void PersistentFileParameterOnly()
            {
                string path = System.IO.Path.GetTempFileName();
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj = null;
                AssertDelegateSuccess(() =>
                {
                    obj = new Project1.Functions.ArrayFunctions(path);
                }, "Failed to instantiate object correctly using default constructor");
                Assert.IsNotNull(obj, "This object cannot be null");
                Assert.AreEqual(path, obj.PersistentFile);
                Assert.IsNotNull(obj.Randomizer);
            }

            [TestMethod]
            public void AllParameters()
            {
                string path = System.IO.Path.GetTempFileName();
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj = null;
                AssertDelegateSuccess(() =>
                {
                    obj = new Project1.Functions.ArrayFunctions(path, 123);
                }, "Failed to instantiate object correctly using default constructor");
                Assert.IsNotNull(obj, "This object cannot be null");
                Assert.AreEqual(path, obj.PersistentFile);
                Assert.IsNotNull(obj.Randomizer);
            }

            [TestMethod]
            public void NullPersistentFileThrowsException()
            {
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj;
                AssertDelegateFailure(() =>
                {
                    obj = new Project1.Functions.ArrayFunctions(null);
                }, typeof(ArgumentException), "Instantiation should not have succeeded with a null persistent file specified");
            }

            [TestMethod]
            public void EmptyOrWhitespacePersistentFilenameThrowsException()
            {
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj;
                AssertDelegateFailure(() =>
                {
                    obj = new Project1.Functions.ArrayFunctions(string.Empty);
                }, typeof(ArgumentException), "Instantiation should not have succeeded with an emtpy string for the persistent file");

                AssertDelegateFailure(() =>
                {
                    obj = new Project1.Functions.ArrayFunctions(" ");
                }, typeof(ArgumentException), "Instantiation should not have succeeded with a whitespace string for the persistent file");
            }

            [TestMethod]
            public void PersistentFilePointsToNonExistentDirectory()
            {
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj;
                var path = @"C:\temp\" + System.Guid.NewGuid().ToString() + @"\temp.tmp";
                AssertDelegateFailure(() =>
                {
                    obj = new Project1.Functions.ArrayFunctions(path);
                }, typeof(System.IO.DirectoryNotFoundException), "Instantiation should not have succeeded with a persistent file path pointing to a non-existent directory");
            }
        }

        /// <summary>
        /// Store method testing harness
        /// </summary>
        [TestClass]
        public class StoreMethod : ArrayFunctionsTests
        {
            [TestMethod]
            public void ContentsAreStoredCorrectly()
            {
                var array = new[] { "f", "g", "h", "i", "j" };
                var contents = string.Join(System.Environment.NewLine, array);
                var tmpFile = System.IO.Path.Combine(this.GetMethodSpecificWorkingDirectory(), PFW.CSIST203.Project1.Functions.ArrayFunctions.DefaultPersistentFile);
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj = new PFW.CSIST203.Project1.Functions.ArrayFunctions(tmpFile);
                obj.Store(array);

                // read the contents of the stored file back
                var savedContents = string.Empty;

                AssertDelegateSuccess(() =>
                {
                    using (System.IO.Stream stream = System.IO.File.OpenRead(tmpFile))
                    {
                        using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                        {
                            savedContents = reader.ReadToEnd().Trim();
                        }
                    }
                }, "The file handle should have been Dispose()'d of when the ArrayFunctions class finishes storing the data");

                Assert.AreEqual(contents, savedContents, "The saved contents needs to match the expected contents");
            }
        }

        /// <summary>
        /// Load method testing harness
        /// </summary>
        [TestClass]
        public class LoadMethod : ArrayFunctionsTests
        {
            [TestMethod]
            public void FileDoesNotExist()
            {
                var directory = this.GetMethodSpecificWorkingDirectory();
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj = new PFW.CSIST203.Project1.Functions.ArrayFunctions();
                AssertDelegateFailure(() =>
                {
                    obj.Load(5);
                }, typeof(System.IO.FileNotFoundException), "The data file should not have been present for this test and loading from it should have failed");
            }

            [TestMethod]
            public void ContentsAreLoadedCorrectly()
            {
                var array = new[] { "a", "b", "c", "d", "e" };
                var contents = string.Join(System.Environment.NewLine, array);
                var tmpFile = System.IO.Path.Combine(this.GetMethodSpecificWorkingDirectory(), PFW.CSIST203.Project1.Functions.ArrayFunctions.DefaultPersistentFile);
                System.IO.File.WriteAllText(tmpFile, contents);
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj = new PFW.CSIST203.Project1.Functions.ArrayFunctions();
                string[] data = null;
                AssertDelegateSuccess(() =>
                {
                    data = obj.Load(array.Length);
                }, "No failure reading the persistent file should have occurred");
                Assert.IsTrue(ArraysMatch(data, array), "The data read from the persistent file did not match the expected contents");
            }
        }

        /// <summary>
        /// ShiftRight method testing harness
        /// </summary>
        [TestClass]
        public class ShiftRightMethod : ArrayFunctionsTests
        {
            [TestMethod]
            public void ShiftsCorrectly()
            {
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj = new PFW.CSIST203.Project1.Functions.ArrayFunctions();
                var startingArray = new[] { "a", "b", "c", "d", "e" };
                var shift1 = new[] { "e", "a", "b", "c", "d" };
                var result1 = obj.ShiftRight(startingArray);
                Assert.IsTrue(ArraysMatch(result1, shift1), "The shifted array element alignment did Not match the expected result");
                var shift2 = new[] { "d", "e", "a", "b", "c" };
                var result2 = obj.ShiftRight(obj.ShiftRight(startingArray));
                Assert.IsTrue(ArraysMatch(result2, shift2), "The shifted array element alignment did Not match the expected result");
            }
        }

        /// <summary>
        /// ShiftLeft method testing harness
        /// </summary>
        [TestClass]
        public class ShiftLeftMethod : ArrayFunctionsTests
        {
            [TestMethod]
            public void ShiftsCorrectly()
            {
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj = new PFW.CSIST203.Project1.Functions.ArrayFunctions();
                var startingArray = new[] { "a", "b", "c", "d", "e" };
                var shift1 = new[] { "b", "c", "d", "e", "a" };
                var result1 = obj.ShiftLeft(startingArray);
                Assert.IsTrue(ArraysMatch(result1, shift1), "The shifted array element alignment did Not match the expected result");
                var shift2 = new[] { "c", "d", "e", "a", "b" };
                var result2 = obj.ShiftLeft(obj.ShiftLeft(startingArray));
                Assert.IsTrue(ArraysMatch(result2, shift2), "The shifted array element alignment did Not match the expected result");
            }
        }

        /// <summary>
        /// Randomize method testing harness
        /// </summary>
        [TestClass]
        public class RandomizeMethod : ArrayFunctionsTests
        {
            [TestMethod]
            public void RandomizesCorrectly()
            {
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj = new PFW.CSIST203.Project1.Functions.ArrayFunctions(PFW.CSIST203.Project1.Functions.ArrayFunctions.DefaultPersistentFile, 123);
                var startingArray = new[] { "a", "b", "c", "d", "e" };
                var random1 = new[] { "e", "c", "d", "b", "a" };
                startingArray = obj.Randomize(startingArray);
                Assert.IsTrue(ArraysMatch(startingArray, random1), "The first randomization did not result in the expected result");
                // reset the array back
                startingArray = new[] { "a", "b", "c", "d", "e" };
                Random rnd = new Random(123);
                var manualRandomizer = startingArray.OrderBy(n => rnd.Next()).ToArray();
                Assert.IsTrue(ArraysMatch(random1, manualRandomizer), "The encapsulated randomization did not match the external implementation expectation");
            }
        }

        /// <summary>
        /// Reverse method testing harness
        /// </summary>
        [TestClass]
        public class ReverseMethod : ArrayFunctionsTests
        {
            [TestMethod]
            public void ReversesCorrectly()
            {
                PFW.CSIST203.Project1.Functions.ArrayFunctions obj = new PFW.CSIST203.Project1.Functions.ArrayFunctions();
                var startingArray = new[] { "a", "b", "c", "d", "e" };
                var reversal = new[] { "e", "d", "c", "b", "a" };
                startingArray = obj.Reverse(startingArray);
                Assert.IsTrue(ArraysMatch(startingArray, reversal));
                startingArray = obj.Reverse(startingArray);
                startingArray = obj.Reverse(startingArray);
                Assert.IsTrue(ArraysMatch(startingArray, reversal));
                startingArray = obj.Reverse(startingArray);
                reversal = obj.Reverse(reversal);
                Assert.IsTrue(ArraysMatch(startingArray, reversal));
            }
        }
    }
}
