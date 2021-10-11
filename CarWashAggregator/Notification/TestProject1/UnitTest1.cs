using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarWashAggregator.Notification.Bl;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_method_GetNotific()
        {
            Class1 cl = new Class1();
            string text = "Testing method notific";
            string theme = "Test";
            cl.SendNotific(text, theme);
        }
    }
}
