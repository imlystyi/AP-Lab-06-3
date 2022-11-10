/* Lab_06_3_Iterative_UT.cs
 * Якубовський Владислав
 * Unit-test до програми Lab_06_3_Iterative.cs */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AP_Lab_06_3_Iterative.Lab_06_3_Iterative;

namespace AP_Lab_06_3_Iterative_UT
{
    [TestClass]
    public class Lab_06_3_Iterative_UT
    {
        [TestMethod]
        public void TestEvenMaximumByRegularFunctions()
        {
            int[] array = { 3, 7, -43, -8, 11, -4, 0 };

            int evenMax = EvenMaximumByRegularFunctions(array);

            Assert.AreEqual(-4, evenMax);
        }

        [TestMethod]
        public void TestEvenMaximumByTemplates()
        {
            int[] array = { 3, 7, -43, -8, 11, -4, 0 };
            
            int evenMax = EvenMaximumByTemplates(array);

            Assert.AreEqual(-4, evenMax);
        }
    }
}
