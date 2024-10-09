using FIT.GTAF.Common.Core.Abstraction;
using FIT.GTAF.IOM.Data.Abstraction.Common;
using FIT.GTAF.IOM.Data.Abstraction.WorkOrder;
using FIT.GTAF.IOM.Pages.Abstraction.IADDON;
using FIT.GTAF.IOM.Pages.Abstraction.IHubStreamPage;
using FIT.GTAF.IOM.Pages.Abstraction.IHubHelpStreamPage;
using FIT.GTAF.IOM.Pages.Abstraction.Work_Order;
using FIT.GTAF.IOM.Pages.Abstraction.WorkOrder;
using FIT.GTAF.IOM.Pages.Impl.Common;
using FIT.GTAF.IOM.WebDriver.Abstraction;
using FIT.GTAF.IOM.Workflow.Abstraction.ADDON.Verifications;
using FIT.GTAF.IOM.Workflow.Abstraction.HubStream.Verifications;
using FIT.GTAF.IOM.Workflow.Abstraction.HubHelpStream.Verifications;
using FIT.GTAF.IOM.Workflow.Abstraction.WorkOrder.Verifications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using OpenQA.Selenium;
using FIT.GTAF.IOM.Workflow.Abstraction.AllPages.Verifications;
using FIT.GTAF.IOM.Pages.Abstraction.IAllPagesPage;
using FIT.GTAF.IOM.Pages.Impl.AllPagesPage;

namespace FIT.GTAF.IOM.WorkFlow.Impl.AllPages.Verifications
{
    public class AllPagesWorkflowVerifications : IOMWorkflowbase, IAllPagesWorkflowVerifications
    {
        private IWOCreationRequestPage woCreationRequestPage = null;
        private IWorkOrdersPage workorderPage = null;
        private readonly ICommonData commonData = null;
        private readonly IWorkOrderData workorderData = null;
        private IWOCreationRequestPage wocreationrequestPage = null;
        private IADDONCreationPage addoncreationPage = null;
        private IHubStreamCreationPage hubstreamcreationPage = null;
        private IHubHelpStreamCreationPage hubhelpstreamcreationPage = null;
        private IAllPagesCreationPage allpagescreationPage = null;


        private readonly IDictionary<string, string> data = null;
        private readonly IDictionary<int, IDictionary<string, string>> Datas = null;

        public AllPagesWorkflowVerifications(IIOMBrowserHelper browser, IReportHelper extent, ILoggerHelper logg, ICommonData commonData) 
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
            hubstreamcreationPage = unityContainer.Resolve<IHubStreamCreationPage>();
            hubhelpstreamcreationPage = unityContainer.Resolve<IHubHelpStreamCreationPage>();
            allpagescreationPage = unityContainer.Resolve<IAllPagesCreationPage>();


        }


        public void VerifyClickOnMyWorkOrderList(int stepNumber)
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

        public void VerifyClickOnWorkOrderControllingSearch(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsBuyerClassificationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "WorkOrderControllingSearch Page is displayed");
                logging.Info("WorkOrderControllingSearch Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "WorkOrderControllingSearch Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "WorkOrderControllingSearch Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnLogisticsReport(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsProgramDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Logistics Report Page is displayed");
                logging.Info("Logistics Report Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Logistics Report Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Logistics Report Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnReminderDashboard(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsSearchDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "ReminderDashboard Page is displayed");
                logging.Info("ReminderDashboard Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "ReminderDashboard Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "ReminderDashboard Page doesn't displayed!!");
                throw ex;
            }
        }
        public void VerifyClickOnKPI(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsSearchDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "KPI Page is displayed");
                logging.Info("KPI Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "KPI Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "KPI Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnBudgetTracker(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsSearchDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "BudgetTracker Page is displayed");
                logging.Info("BudgetTracker Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "BudgetTracker Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "BudgetTracker Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnWorAdmin(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "WorAdmin Page is displayed");
                logging.Info("WorAdmin Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "WorAdmin Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "WorAdmin Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnManageProductGroups(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "ProductGroups Page is displayed");
                logging.Info("ProductGroups Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "ProductGroups Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "ProductGroups Page doesn't displayed!!");
                throw ex;
            }
        }
        public void VerifyClickOnManageOem(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "ManageOem Page is displayed");
                logging.Info("ManageOem Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "ManageOem Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "ManageOem Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnManagePrograms(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Programs Page is displayed");
                logging.Info("Manage Programs Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Manage Programs Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Programs Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnManageRegions(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Regions Page is displayed");
                logging.Info("Manage Regions Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Manage Regions Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Regions Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnManageCountries(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Countries Page is displayed");
                logging.Info("Manage Countries Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Manage Countries Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Countries Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnManageSites(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Sites Page is displayed");
                logging.Info("Manage Sites Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Manage Sites Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Sites Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnManageCostCenters(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Manage CostCenters Page is displayed");
                logging.Info("Manage CostCenters Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Manage CostCenters Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Manage CostCenters Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnManageForms(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Forms Page is displayed");
                logging.Info("Manage Forms Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Manage Forms Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Forms Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnManageBau(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Bau Page is displayed");
                logging.Info("Manage Bau Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Manage Bau Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Bau Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnViewJobLevels(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "View JobLevels Page is displayed");
                logging.Info("View JobLevels Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "View JobLevels Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "View JobLevels Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnManageUserList(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Manage UserList Page is displayed");
                logging.Info("Manage UserList Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Manage UserList Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Manage UserList Page doesn't displayed!!");
                throw ex;
            }
        }
        public void VerifyClickOnManageCurrency(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Currency Page is displayed");
                logging.Info("Manage Currency Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Manage Currency Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Currency Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnImportData(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Import Data Page is displayed");
                logging.Info("Import Data Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Import Data Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Import Data Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnIssueTracker(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Issue Tracker Page is displayed");
                logging.Info("Issue Tracker Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Issue Tracker Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Issue Tracker Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnFileTracker(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsAdministrationDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "FileTracker Page is displayed");
                logging.Info("FileTracker Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "FileTracker Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "FileTracker Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnPPVIntracoBillingPending(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsBillingDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "PPV Intraco BillingPending Page is displayed");
                logging.Info("PPV Intraco BillingPending Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "PPV Intraco BillingPending Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "PPV Intraco BillingPending Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnPPVIntercoBillingPending(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsBillingDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "PPV Interco BillingPending Page is displayed");
                logging.Info("PPV Interco BillingPending Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "PPV Interco BillingPending Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "PPV Intraco BillingPending Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnSTDSalesOrderBillingPending(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsBillingDisplayed()); 
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "STD Sales Order Billing Pending Page is displayed");
                logging.Info("STD Sales Order Billing Pending Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "STD Sales Order Billing Pending Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "STD Sales Order Billing Pending Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnImportDataController(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsBillingDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Import DataController Page is displayed");
                logging.Info("Import DataController Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Import DataController Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Import DataController Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnManageProgramSellerDetails(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsBillingDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Program Seller Details Page is displayed");
                logging.Info("Manage Program Seller Details Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Manage Program Seller Details Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Manage Program Seller Details Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnManageGLaccounts(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsBillingDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Manage GLaccounts Page is displayed");
                logging.Info("ManageGLaccounts Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "ManageGLaccounts Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Manage GLaccounts Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnPPVDeliveryPending(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsBillingDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Manage GLaccounts Page is displayed");
                logging.Info("ManageGLaccounts Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "ManageGLaccounts Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Manage GLaccounts Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnContractDashboard(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsESignatureDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Contract Dashboard Page is displayed");
                logging.Info("Contract Dashboard Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "Contract Dashboard Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "Contract Dashboard Page doesn't displayed!!");
                throw ex;
            }
        }

        public void VerifyClickOnTranslationManagement(int stepNumber)
        {
            try
            {
                Assert.IsTrue(allpagescreationPage.IsESignatureDisplayed());
                extent.SetStepStatusPass(TestContext.CurrentContext.Test.Name, stepNumber, "Translation Management Page is displayed");
                logging.Info("ranslation Management Page is displayed");
            }
            catch (AssertionException ex)
            {
                logging.Error("stepNumber : " + stepNumber + "ranslation Management Page doesn't displayed : " + ex.Message);
                extent.SetStepStatusFail(TestContext.CurrentContext.Test.Name, stepNumber, "ranslation Management Page doesn't displayed!!");
                throw ex;
            }
        }
        


    }
}
