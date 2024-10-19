using FIT.GTAF.Common.Core.Abstraction;
using FIT.GTAF.IOM.Data.Abstraction.Common;
using FIT.GTAF.IOM.Data.Abstraction.WorkOrder;
using FIT.GTAF.IOM.Pages.Abstraction.Work_Order;
using FIT.GTAF.IOM.Pages.Abstraction.WorkOrder;
using FIT.GTAF.IOM.WebDriver.Abstraction;
using FIT.GTAF.IOM.Workflow.Abstraction.WorkOrder.Verifications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace FIT.GTAF.IOM.WorkFlow.Impl.WorkOrder.Verifications
{
    public class WorkOrderWorkflowVerifications : IOMWorkflowbase, IWorkOrderWorkflowVerification
    {
        private IWOCreationRequestPage woCreationRequestPage = null;
        private IWorkOrdersPage workorderPage = null;
        private readonly ICommonData commonData = null;
        private readonly IWorkOrderData workorderData = null;
        private IWOCreationRequestPage wocreationrequestPage = null;


        private readonly IDictionary<string, string> data = null;
        private readonly IDictionary<int, IDictionary<string, string>> Datas = null;

        public WorkOrderWorkflowVerifications(IIOMBrowserHelper browser, IReportHelper extent, ILoggerHelper logg, ICommonData commonData)
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


        }

        public void VerifyClickOnCreateNewQuotation(int stepNumber)
        {
            try
            {
                Assert.IsTrue(woCreationRequestPage.IsClassificationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "A new tab is opened and Buyer Information section is displayed");
                logging.Info("A new tab is opened and Buyer Information section is displayed.");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Buyer information section doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Buyer information section doesn't displayed !!");
                throw ex;
            }
        }

        public void VerifyChooseClassification(int stepNumber)
        {
            try
            {
                Assert.IsTrue(woCreationRequestPage.IsRegionDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "New flieds are appears");
                logging.Info("New flieds are appears.");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "The fields doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "The fields doesn't displayed !!");
                throw ex;
            }
        }

        public void VerifyEnterBuyerInformationDetails(int stepNumber)
        {
            try
            {
                Assert.IsTrue(woCreationRequestPage.IsReasonDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "The 'Work Request Details' section is enabled");
                logging.Info("The 'Work Request Details' section is enabled.");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "The 'Work Request Details' section doesn't enabled: " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "The 'Work Request Details' section doesn't enabled !!");
                throw ex;
            }
        }

        public void VerifyEnterWorkRequestDetails(int stepNumber)
        {
            try
            {
                Assert.IsTrue(woCreationRequestPage.IsYearDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "The 'Seller Information' Section is enabled");
                logging.Info("The 'Seller Information' Section is enabled.");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "The 'Seller Information' Section doesn't enabled : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "The 'Seller Information' Section doesn't enabled !!");
                throw ex;
            }
        }

        public void VerifyEnterSellerInformationDetails(int stepNumber)
        {
            try
            {
                Assert.IsTrue(woCreationRequestPage.IsRequestApprovedTabDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "The 'The Work Request Actions' tab on the buttom of the page is displayed");
                logging.Info("The 'The Work Request Actions' tab on the buttom of the page is displayed.");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "The 'The Work Request Actions' tab on the buttom of the page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "The 'The Work Request Actions' tab on the buttom of the page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnSubmitforApproval(int stepNumber)
        {
            try
            {
                Assert.IsTrue(woCreationRequestPage.IsPopupApproveDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "A popup appears to submit and you can put a note to the approval");
                logging.Info("A popup appears to submit and you can put a note to the approval ");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "The popup doesn't appear : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "The popup doesn't appear !!");
                throw ex;
            }
        }
        public void VerifyClickOnMyWorkQuotation(int stepNumber)
        {
            try
            {
                Assert.IsTrue(workorderPage.IsListofWorkOrdersDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "The list of work orders is displayed");
                logging.Info("The list of work orders is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "The list of work orders doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "The list of work orders doesn't displayed!!");
                throw ex;
            }
        }
        public void VerifyClickOnLastWorkOrder(int stepNumber)
        {
            try
            {
                wocreationrequestPage.HandletoSecondPage((Datas[stepNumber][commonData.ValidSecondUrl]));
                Assert.IsTrue(woCreationRequestPage.IsWorkOrderRequestPageDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "The 'Work Order' section is enabled");
                logging.Info("The 'Work Order' section is enabled ");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "The 'Work Order' section doesn't enabled : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "The 'Work Order' section doesn't enabled !!");
                throw ex;
            }
        }
        public void VerifyEnterMandatoryFields(int stepNumber)
        {
            try
            {
                Assert.IsTrue(woCreationRequestPage.IsApproveTabDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "All mondatory fields must be added");
                logging.Info("All mondatory fields must be added ");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "missed field : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "missed field !!");
                throw ex;
            }
        }
        public void VerifyApproveTheWorkOrder(int stepNumber)
        {
            try
            {
                Assert.IsTrue(woCreationRequestPage.IsApproveTabDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "A popup appear to choose the next approver");
                logging.Info("A popup appear to choose the next approver ");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "A popup doesn't appear to choose the next approver: " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "A popup doesn't appear to choose the next approver !!");
                throw ex;
            }
        }
    }
}