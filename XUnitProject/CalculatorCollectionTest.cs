using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using ClassLibrary;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace XUnitProject
{
    [CollectionDefinition("Calc Test")]
    public class CalculatorTestCollectionDefinition : ICollectionFixture<Calculator> { }


    /// <summary>
    /// All Classes annotated with "Calc Test" using the same instance of a Calculator
    /// </summary>
    [Collection("Calc Test")]
    class CalculatorCollectionTest
    {
        private readonly Calculator calc;
        private readonly ITestOutputHelper sysout;

        public CalculatorCollectionTest(ITestOutputHelper output, Calculator calc)
        {
            this.calc = calc;
            this.sysout = output;
        }
    }
}
