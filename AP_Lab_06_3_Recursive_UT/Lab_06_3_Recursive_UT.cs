/* Lab_06_3_Recursive_UT.cs
 * Якубовський Владислав
 * Unit-test до програми Lab_06_3_Recursive.cs */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AP_Lab_06_3_Recursive.Lab_06_3_Recursive;

namespace AP_Lab_06_3_Recursive_UT
{
    [TestClass]
    public class Lab_06_3_Recursive_UT
    {
        [TestMethod]
        public void TestEvenMaximumByRegularFunctions()
        {
            int[] array = { 3, 7, -43, -8, 11, -4, 0 };

            int evenMax = EvenMaximumByRegularFunctions(array, new int[CountEvenElements(array)]);

            Assert.AreEqual(-4, evenMax);
        }

        [TestMethod]
        public void TestEvenMaximumByTemplates()
        {
            int[] array = { 3, 7, -43, -8, 11, -4, 0 };

            int evenMax = EvenMaximumByTemplates(array, new int[CountEvenElements(array)]);

            Assert.AreEqual(-4, evenMax);
        }
    }
}
