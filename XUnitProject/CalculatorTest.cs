using System;
using Xunit;
using ClassLibrary;
using System.Threading.Tasks;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Collections;

namespace XUnitProject
{
    /// <summary>
    /// Notes:
    /// - https://www.youtube.com/watch?v=2Wp8en1I9oQ
    /// - Test-Lifecycles: XUnit creates a new Test-Instance for each Test-Method.
    /// 
    /// </summary>
    public class CalculatorTest 
    {
        #region Essential Fields for XUnit
        private readonly ITestOutputHelper sysout;
        #endregion

        #region Fields
        private readonly Calculator calc = new Calculator();
        #endregion

        #region Constructors
        public CalculatorTest(ITestOutputHelper sysout)
        {
            this.sysout = sysout;
        }
        #endregion


        #region Test Cases

        #region Simple Facts
        [Fact]
        public void TestAdd()
        {
            Assert.Equal(2, calc.add(1.0, 1.0));
        }

        [Fact]
        public async void TestAddAsync()
        {
            await Task.Run(() => TestAdd());
        }

        [Fact(Skip = "This test was skipped :D")]
        public void skippedTest()
        {
            Assert.True(true);
        }

        [Fact(Timeout = 2000)]
        public async void TimeoutTest()
        {
            await Task.Delay(1000);
            Assert.True(true);
        }
        #endregion


        #region Theories
        [Theory(DisplayName = "Testing Add with Params")]
        [InlineData(0, 0)]
        [InlineData(1, -1)]
        [InlineData(100, 20)]
        public void TestAddParameterized(double n1, double n2)
        {
            Assert.Equal(n1 + n2, calc.add(n1, n2));
        }

        [Theory]
        [MemberData(nameof(ProvideTestDataForTestAddManyParameterized))]
        public void TestAddManyParameterized(string msg, double[] addParams)
        {
            var ownCalc = 0.0;
            var calcCalc = 0.0;
            foreach(var param in addParams)
            {
                ownCalc += param;
                calcCalc = calc.add(calcCalc,param);
            }
            sysout.WriteLine(msg);
            sysout.WriteLine($"OWN: {ownCalc}, CALC: {calcCalc}");
            Assert.Equal(ownCalc,calcCalc);
            
        }

        /// <summary>
        /// This Method is used to provide arbitrary kind of data to a parameterized test function.
        /// </summary>
        /// <returns> The Test Data for each parameterized Test - Execution</returns>
        public static IEnumerable<object[]> ProvideTestDataForTestAddManyParameterized()
        {
            yield return new object[] { "MSG1", new double[] { 5, 5, 5 } };
            yield return new object[] { "MSG2", new double[] { 0, 1, -1 } };
        }

        [Theory]
        [ClassData(typeof(DivisionTestData))]
        public void testDivision(double n1, double n2) 
        { 
            if(n2 == 0) 
            {
                Assert.Throws<Exception>(() => calc.divide(n1,n2));
            }
            else
            {
                Assert.Equal(n1/n2,calc.divide(n1,n2));
            }
        }

        public class DivisionTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { 10.0, 0.0 };
                yield return new object[] { 10.0, 5.0 };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        #endregion


        #endregion

    }
}
