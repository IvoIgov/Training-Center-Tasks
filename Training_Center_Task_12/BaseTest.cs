using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Training_Center_Task_12
{
    [AllureNUnit]
    [AllureParentSuite("Root Suite")]
    public class BaseTest
    {
        //[OneTimeSetUp]
        //public void CleanupResultDirectory()
        //{
        //    AllureExtensions.WrapSetUpTearDownParams(() => { AllureLifecycle.Instance.CleanupResultDirectory(); },
        //        "Clear Allure Results Directory");
        //}
    }
}
