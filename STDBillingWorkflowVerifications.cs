using FIT.GTAF.Common.Core.Abstraction;
using FIT.GTAF.IOM.Data.Abstraction.ADDOnWoFMO;
using FIT.GTAF.IOM.Data.Abstraction.AllPages;
using FIT.GTAF.IOM.Data.Abstraction.Common;
using FIT.GTAF.IOM.Data.Abstraction.FeaturesMenuOptions;
using FIT.GTAF.IOM.Data.Abstraction.HubHelpStream;
using FIT.GTAF.IOM.Data.Abstraction.HubStream;
using FIT.GTAF.IOM.Data.Abstraction.PPVBilling;
using FIT.GTAF.IOM.Data.Abstraction.PPVWoFMO;
using FIT.GTAF.IOM.Data.Abstraction.PPVWorkOrder;
using FIT.GTAF.IOM.Data.Abstraction.STDBilling;
using FIT.GTAF.IOM.Data.Abstraction.WorkOrder;
using FIT.GTAF.IOM.Pages.Abstraction.IADDON;
using FIT.GTAF.IOM.Pages.Abstraction.IADDOnWoFMO;
using FIT.GTAF.IOM.Pages.Abstraction.IPPVBillingPage;
using FIT.GTAF.IOM.Pages.Abstraction.ISTDBillingPage;
using FIT.GTAF.IOM.Pages.Abstraction.Work_Order;
using FIT.GTAF.IOM.Pages.Abstraction.WorkOrder;
using FIT.GTAF.IOM.Pages.Impl.STDBillingPage;
using FIT.GTAF.IOM.WebDriver.Abstraction;
using FIT.GTAF.IOM.Workflow.Abstraction.ADDON.Verifications;
using FIT.GTAF.IOM.Workflow.Abstraction.ADDOnWoFMO.Verifications;
using FIT.GTAF.IOM.Workflow.Abstraction.PPVBilling.Verifications;
using FIT.GTAF.IOM.Workflow.Abstraction.STDBilling.Verifications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace FIT.GTAF.IOM.WorkFlow.Impl.STDBilling.Verifications
{
    public class STDBillingWorkflowVerifications : IOMWorkflowbase, ISTDBillingWorkflowVerifications
    {
        private IWOCreationRequestPage woCreationRequestPage = null;

        private IWorkOrdersPage workorderPage = null;
        private readonly ICommonData commonData = null;
        private readonly IWorkOrderData workorderData = null;
        private readonly IADDOnWoFMOData addonfmodata = null;
        private readonly IPPVBillingData ppvbillingdata = null;
        private readonly ISTDBillingData stdbillingdata = null;


        private IWOCreationRequestPage wocreationrequestPage = null;
        private IADDONCreationPage addoncreationPage = null;
        private IADDOnWoFMOCreationPage addonfmocreationpage = null;
        private IPPVBillingCreationPage ppvbillingcreationpage = null;
        private ISTDBillingCreationPage stdbillingcreationpage = null;


        private readonly IDictionary<string, string> data = null;
        private readonly IDictionary<int, IDictionary<string, string>> Datas = null;

        public STDBillingWorkflowVerifications(IIOMBrowserHelper browser, IReportHelper extent, ILoggerHelper logg, ICommonData commonData)
        {

            this.browser = browser;
            this.extent = extent;
            this.logging = logg;
            if (commonData != null)
            {
                this.commonData = commonData;
                data = this.commonData.helper.Data;
                Datas = this.commonData.helper.Datas;
            }
            SetupWorkflow(browser, extent, logg);
            woCreationRequestPage = unityContainer.Resolve<IWOCreationRequestPage>();
            workorderPage = unityContainer.Resolve<IWorkOrdersPage>();
            wocreationrequestPage = unityContainer.Resolve<IWOCreationRequestPage>();
            addoncreationPage = unityContainer.Resolve<IADDONCreationPage>();
            addonfmocreationpage = unityContainer.Resolve<IADDOnWoFMOCreationPage>();
            ppvbillingcreationpage = unityContainer.Resolve<IPPVBillingCreationPage>();
            stdbillingcreationpage = unityContainer.Resolve<ISTDBillingCreationPage>();


        }

        public void VerifyUpdateSellerReference(int stepNumber)
        {
            try
            {
                Assert.IsTrue(stdbillingcreationpage.IsADDOnExtensionDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "ADD-On Extension is displayed");
                logging.Info("ADD-On Extension is displayed.");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "ADD-On Extension button doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "ADD-On Extension button doesn't displayed !!");
                throw ex;
            }
        }

        public void VerifyClickOnSTDSalesOrdeBillingPending(int stepNumber)
        {
            try
            {
                Assert.IsTrue(stdbillingcreationpage.IsADDToBillDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "ADD To Bill button is displayed");
                logging.Info("ADD To Bill button is displayed.");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "ADD To Bill buttonn doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "ADD To Bill button doesn't displayed !!");
                throw ex;
            }
        }

        public void VerifyPickBAUSTDWoBilling(int stepNumber)
        {
            try
            {
                Assert.IsTrue(stdbillingcreationpage.IsTableDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Table is displayed");
                logging.Info("Table is displayed.");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Table doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Table doesn't displayed !!");
                throw ex;
            }
        }

        public void VerifyClickBillingReleaseSTD(int stepNumber)
        {
            try
            {
                Assert.IsTrue(stdbillingcreationpage.IsBillDeliveriesCliquable());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Bill Deliveries Cliquable");
                logging.Info("Bill Deliveries Cliquable.");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Bill Deliveries isn't Cliquable: " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Bill Deliveries isn't Cliquable !!");
                throw ex;
            }
        }


        











    }
}
