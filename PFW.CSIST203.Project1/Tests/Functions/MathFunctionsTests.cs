using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PFW.CSIST203.Project1.Tests.Functions
{
    public abstract class MathFunctionsTests : TestBase
    {
        protected PFW.CSIST203.Project1.Functions.MathFunctions MathFunctionObj { get; set; } = new Project1.Functions.MathFunctions();

        /// <summary>
        /// Add method testing harness
        /// </summary>
        [TestClass]
        public class AddMethod : MathFunctionsTests
        {
            [TestMethod]
            public void IntegerAddition()
            {
                Assert.AreEqual(10M, decimal.Parse(MathFunctionObj.Add("5", "5")));
                Assert.AreEqual(10M, decimal.Parse(MathFunctionObj.Add("1", "9")));
                Assert.AreEqual(10M, decimal.Parse(MathFunctionObj.Add("-20", "30")));
                Assert.AreEqual(10M, decimal.Parse(MathFunctionObj.Add("0", "10")));
                Assert.AreEqual(10M, decimal.Parse(MathFunctionObj.Add("10", "0")));
                Assert.AreEqual(10M, decimal.Parse(MathFunctionObj.Add(" 10 ", " 0 ")));
            }

            [TestMethod]
            public void NonIntegerAddition()
            {
                Assert.AreEqual(10M, decimal.Parse(MathFunctionObj.Add("0.1", "9.9")));
                Assert.AreEqual(10M, decimal.Parse(MathFunctionObj.Add("45.23", "-35.23")));
                Assert.AreEqual(10M, decimal.Parse(MathFunctionObj.Add("  45.23", "-35.23 ")));
            }

            [TestMethod]
            public void BadInput()
            {
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Add("text", "10"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Add("10", "text"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Add("", ""));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Add(null, ""));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Add("", null));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Add(null, null));
            }
        }

        /// <summary>
        /// Subtract method testing harness
        /// </summary>
        [TestClass]
        public class SubtractMethod : MathFunctionsTests
        {
            [TestMethod]
            public void IntegerSubtraction()
            {
                Assert.AreEqual(0.0M, decimal.Parse(MathFunctionObj.Subtract("5", "5")));
                Assert.AreEqual(-8M, decimal.Parse(MathFunctionObj.Subtract("1", "9")));
                Assert.AreEqual(-50M, decimal.Parse(MathFunctionObj.Subtract("-20", "30")));
                Assert.AreEqual(-10M, decimal.Parse(MathFunctionObj.Subtract("0", "10")));
                Assert.AreEqual(10M, decimal.Parse(MathFunctionObj.Subtract("10", "0")));
                Assert.AreEqual(10M, decimal.Parse(MathFunctionObj.Subtract("10 ", " 0")));
            }

            [TestMethod]
            public void NonIntegerSubtraction()
            {
                Assert.AreEqual(-9.8M, decimal.Parse(MathFunctionObj.Subtract("0.1", "9.9")));
                Assert.AreEqual(80.46M, decimal.Parse(MathFunctionObj.Subtract("45.23", "-35.23")));
                Assert.AreEqual(5.2M, decimal.Parse(MathFunctionObj.Subtract("0", "-5.2")));
                Assert.AreEqual(5.2M, decimal.Parse(MathFunctionObj.Subtract(" 0", "  -5.2")));
            }

            [TestMethod]
            public void BadInput()
            {
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Subtract("text", "10"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Subtract("10", "text"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Subtract("", ""));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Subtract(null, ""));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Subtract("", null));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Subtract(null, null));
            }
        }

        /// <summary>
        /// Multiplication testing harness
        /// </summary>
        [TestClass]
        public class MultiplyMethod : MathFunctionsTests
        {
            [TestMethod]
            public void IntegerMultiplication()
            {
                for (int i = 0; i <= 10; i++)
                {
                    for (int j = 0; j <= 10; j++)
                    {
                        var result = System.Convert.ToDecimal(i * j);
                        Assert.AreEqual(result, decimal.Parse(MathFunctionObj.Multiply(i.ToString(), j.ToString())));
                        Assert.AreEqual(result, decimal.Parse(MathFunctionObj.Multiply(j.ToString(), i.ToString())));
                        Assert.AreEqual(result, decimal.Parse(MathFunctionObj.Multiply(" " + i.ToString(), j.ToString())));
                        Assert.AreEqual(result, decimal.Parse(MathFunctionObj.Multiply(" " + i.ToString(), " " + j.ToString())));
                    }
                }
            }

            [TestMethod]
            public void NonIntegerMultiplication()
            {
                foreach (double d1 in new[] { 3.5, 2.5, 7.12, 123.9 })
                {
                    foreach (double d2 in new[] { 1.2, 10.23, -23.1, 0.223, 0, 10.1 })
                    {
                        var result = System.Convert.ToDecimal(d1 * d2);
                        Assert.AreEqual(result, decimal.Parse(MathFunctionObj.Multiply(d1.ToString(), d2.ToString())));
                        Assert.AreEqual(result, decimal.Parse(MathFunctionObj.Multiply(d2.ToString(), d1.ToString())));
                        Assert.AreEqual(result, decimal.Parse(MathFunctionObj.Multiply(d2.ToString() + " ", d1.ToString())));
                        Assert.AreEqual(result, decimal.Parse(MathFunctionObj.Multiply(d2.ToString(), " " + d1.ToString())));
                    }
                }
            }

            [TestMethod]
            public void BadInput()
            {
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Multiply("text", "10"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Multiply("10", "text"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Multiply("", ""));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Multiply(null, ""));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Multiply("", null));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Multiply(null, null));
            }
        }

        /// <summary>
        /// Division method testing harness
        /// </summary>
        [TestClass]
        public class DivideMethod : MathFunctionsTests
        {
            [TestMethod]
            public void IntegerDivision()
            {
                Assert.AreEqual(1M, decimal.Parse(MathFunctionObj.Divide("5", "5")));
                Assert.AreEqual(5M, decimal.Parse(MathFunctionObj.Divide("10", "2")));
                Assert.AreEqual(0.5M, decimal.Parse(MathFunctionObj.Divide("5", "10")));
            }

            [TestMethod]
            public void NonIntegerDivision()
            {
                Assert.AreEqual(5M, decimal.Parse(MathFunctionObj.Divide("0.5", "0.1")));
                Assert.AreEqual(3.8M, decimal.Parse(MathFunctionObj.Divide("11.4", "3")));
                Assert.AreEqual(13.5M, decimal.Parse(MathFunctionObj.Divide("310.5", "23")));
                Assert.AreEqual(4.3M, decimal.Parse(MathFunctionObj.Divide("349.16", "81.2")));
            }

            [TestMethod]
            public void DivideByZero()
            {
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Divide("1.0", "0"));
            }

            [TestMethod]
            public void BadInput()
            {
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Divide("text", "10"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Divide("10", "text"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Divide("", ""));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Divide(null, ""));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Divide("", null));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Divide(null, null));
            }
        }

        /// <summary>
        /// Modulus method testing harness
        /// </summary>
        [TestClass]
        public class ModulusMethod : MathFunctionsTests
        {
            [TestMethod]
            public void VarietyOfCalculations()
            {
                Assert.AreEqual(0M, decimal.Parse(MathFunctionObj.Modulus("5", "5")));
                Assert.AreEqual(1M, decimal.Parse(MathFunctionObj.Modulus("9", "2")));
                Assert.AreEqual(2.1M, decimal.Parse(MathFunctionObj.Modulus("25.1", "23")));
                Assert.AreEqual(-15.6M, decimal.Parse(MathFunctionObj.Modulus("-178.2", "27.1")));
            }

            [TestMethod]
            public void DivideByZero()
            {
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Modulus("1.0", "0"));
            }

            [TestMethod]
            public void BadInput()
            {
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Modulus("text", "10"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Modulus("10", "text"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Modulus("", ""));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Modulus(null, ""));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Modulus("", null));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Modulus(null, null));
            }
        }

        /// <summary>
        /// Power method testing harness
        /// </summary>
        [TestClass]
        public class PowerMethod : MathFunctionsTests
        {
            [TestMethod]
            public void VarietyOfCalculations()
            {
                Assert.AreEqual(25M, decimal.Parse(MathFunctionObj.Power("5", "2")));
                Assert.AreEqual(100M, decimal.Parse(MathFunctionObj.Power("10", "2")));
                Assert.AreEqual(4096M, decimal.Parse(MathFunctionObj.Power("8", "4")));
                Assert.AreEqual(1079986.28684488M, decimal.Parse(MathFunctionObj.Power("25.3", "4.3")));
            }

            [TestMethod]
            public void ZeroRaisedtoANonZeroPower()
            {
                Assert.AreEqual(0M, decimal.Parse(MathFunctionObj.Power("0", "1")));
                Assert.AreEqual(0M, decimal.Parse(MathFunctionObj.Power("0", "2")));
                Assert.AreEqual(0M, decimal.Parse(MathFunctionObj.Power("0", "0.5")));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Power("0", "-5"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Power("0", "-0.5"));
            }

            [TestMethod]
            public void ZeroRaisedtoZeroPower()
            {
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Power("0", "0"));
            }

            [TestMethod]
            public void NonZeroRaisedToOne()
            {
                Assert.AreEqual(1M, decimal.Parse(MathFunctionObj.Power("1", "1")));
                Assert.AreEqual(0.5M, decimal.Parse(MathFunctionObj.Power("0.5", "1")));
                Assert.AreEqual(-1M, decimal.Parse(MathFunctionObj.Power("-1", "1")));
            }

            [TestMethod]
            public void BadInput()
            {
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Power("text", "10"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Power("10", "text"));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Power("", ""));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Power(null, ""));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Power("", null));
                Assert.AreEqual(Project1.Functions.MathFunctions.ErrorMessage, MathFunctionObj.Power(null, null));
            }
        }
    }

}
