using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace XUnitProject
{
    /// <summary>
    /// In this class, the Calculator Instance will be reused for every  Test-Instance that is instanciated for each
    /// Test-Method.
    /// 
    /// All Logic for setup and cleanup is done in the constructor or dispose method of a Test-Class 
    /// (= @BeforeEach/@AfterEach in JUnit)
    /// </summary>
    public class OneLifecycleCalculatorTest : IClassFixture<Calculator>, IDisposable
    {
        private readonly Calculator calc;
        private readonly ITestOutputHelper sysout;

        public OneLifecycleCalculatorTest(ITestOutputHelper output, Calculator calc)
        {
            this.calc = calc;
            this.sysout = output;
        }

        public void Dispose()
        {
            sysout.WriteLine("Do Cleanup...");
        }
    }
}
