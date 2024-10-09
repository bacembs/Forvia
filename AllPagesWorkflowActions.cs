using FIT.GTAF.Common.Core.Abstraction;
using FIT.GTAF.IOM.Data.Abstraction.Common;
using FIT.GTAF.IOM.Data.Abstraction.PPVWorkOrder;
using FIT.GTAF.IOM.Data.Abstraction.WorkOrder;
using FIT.GTAF.IOM.Pages.Abstraction.Common;
using FIT.GTAF.IOM.Pages.Abstraction.IHubStreamPage;
using FIT.GTAF.IOM.Pages.Abstraction.IAllPagesPage;
using FIT.GTAF.IOM.Pages.Abstraction.IHubHelpStreamPage;
using FIT.GTAF.IOM.Pages.Abstraction.IPPVWorkOrderPage;
using FIT.GTAF.IOM.Pages.Abstraction.Work_Order;
using FIT.GTAF.IOM.Pages.Abstraction.WorkOrder;
using FIT.GTAF.IOM.WebDriver.Abstraction;
using FIT.GTAF.IOM.Workflow.Abstraction.PPVWorkOrder.Actions;
using FIT.GTAF.IOM.Workflow.Abstraction.WorkOrder.Actions;
using FIT.GTAF.IOM.Workflow.Abstraction.HubHelpStream.Actions;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Unity;
using FIT.GTAF.IOM.Data.Abstraction.HubStream;
using FIT.GTAF.IOM.Data.Abstraction.HubHelpStream;
using FIT.GTAF.IOM.Data.Impl.HubStream.Model;
using FIT.GTAF.IOM.Workflow.Abstraction.AllPages.Actions;
using FIT.GTAF.IOM.Data.Abstraction.AllPages;

namespace FIT.GTAF.IOM.WorkFlow.Impl.AllPages.Actions
{
    public class AllPagesWorkflowActions : IOMWorkflowbase, IAllPagesWorkflowActions
    {
        private IHomePage homePage = null;
        private IWOCreationRequestPage wocreationrequestPage = null;
        private IPPVWorkOrderCreationPage ppvworkordercreationpage = null;
        private IWorkOrdersPage workorderPage = null;
        private IHubStreamCreationPage hubstreamcreationpage = null;
        private IHubHelpStreamCreationPage hubhelpstreamcreationpage = null;
        private IAllPagesCreationPage allpagescreationpage = null;


        private readonly IWorkOrderData workorderData = null;
        private readonly ICommonData commonData = null;
        private readonly IPPVWorkOrderData ppvworkorderdata = null;
        private readonly IHubHelpStreamData hubhelpstreamdata = null;
        private readonly IHubStream hubstreamdata = null;
        private readonly IAllPagesData allpagesdata = null;

        private readonly IDictionary<string, string> data = null;
        private readonly IDictionary<int, IDictionary<string, string>> Datas = null;


        public AllPagesWorkflowActions(IIOMBrowserHelper browser, IReportHelper extent, ILoggerHelper logg, ICommonData commonData, IWorkOrderData workorderData, IPPVWorkOrderData ppvworkorderdata, IHubStream hubstreamdata, IHubHelpStreamData hubhelpstreamdata, IAllPagesData allpagesdata)
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
            homePage = unityContainer.Resolve<IHomePage>();
            wocreationrequestPage = unityContainer.Resolve<IWOCreationRequestPage>();
            workorderPage = unityContainer.Resolve<IWorkOrdersPage>();
            ppvworkordercreationpage = unityContainer.Resolve<IPPVWorkOrderCreationPage>();
            hubhelpstreamcreationpage = unityContainer.Resolve<IHubHelpStreamCreationPage>();
            allpagescreationpage = unityContainer.Resolve<IAllPagesCreationPage>();

        }

        public void ClickOnMyWorkOrderList(int stepNumber)
        {
            try
            {
                allpagescreationpage.ClickOnMyWorkOrderList();

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on My Work OrderList", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnWorkOrderControllingSearch(int stepNumber)
        {
            try
            {
                allpagescreationpage.ClickOnControllingSearch();

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Controlling Search", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnLogisticsReport(int stepNumber)
        {
            try
            {
                allpagescreationpage.ClickOnLogisticsReport();

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Logistics Report", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnReminderDashboard(int stepNumber)
        {
            try
            {
                allpagescreationpage.ClickOnReminderDashboard();

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on ReminderDashboard", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnKPI(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnKPIWoIntake();
                allpagescreationpage.ClickOnKPIWorkLoad();
                allpagescreationpage.ClickOnKPITTA();
                allpagescreationpage.ClickOnKPIControlTower();
                allpagescreationpage.ClickOnKPIWOHoursTracker();



            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on KPI", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnBudgetTracker(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnBudgetTracker();
              

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Budget Tracker", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnWorAdmin(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnWorAdmin();
                allpagescreationpage.ClickOnAdresses();
                allpagescreationpage.ClickOnPCL();



            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on WorAdmin", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManageProductGroups(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnManageProductGroups();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on ManageProductGroups", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManageOem(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnManageOem();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on ManageOem", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManagePrograms(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnIomProgram();
                allpagescreationpage.ClickOnMdmProgram();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on ManageOem", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManageRegions(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnManageRegions();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Manage Regions", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManageCountries(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnManageCountries();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Manage Countries", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManageSites(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnManageSites();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Manage Sites", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManageCostCenters(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnManageCostCenters();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Manage CostCenters", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManageForms(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnManageForms();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Manage Forms", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManageBau(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnManageBau();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Manage Bau", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnViewJobLevels(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnViewJobLevels();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on View JobLevels", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManageUserList(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnAddNewUser();
                allpagescreationpage.ClickOnManageHelpPage();



            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on View JobLevels", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManageCurrency(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnManageCurrency();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Manage Currency", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnImportData(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnImportData();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Import Data", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnIssueTracker(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnDiscrepancies();
                allpagescreationpage.ClickOnCompletionCV();
                allpagescreationpage.ClickOnWbsCcIo();
                allpagescreationpage.ClickOnComplianceMaintenance();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Issue Tracker", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnFileTracker(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnFileTracker();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on File Tracker", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnPPVIntracoBillingPending(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnPPVIntracoBillingPending();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on PPV Intraco BillingPending", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnPPVIntercoBillingPending(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnPPVIntercoBillingPending();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on PPV Interco BillingPending", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnSTDSalesOrderBillingPending(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnSTDSalesOrderBillingPending();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on STD Sales Order BillingPending", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnImportDataController(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnImportDataController();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Import DataController", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManageProgramSellerDetails(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnManageProgramSellerDetails();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Manage Program Seller Details", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnManageGLaccounts(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnManageGLaccounts();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Manage GLaccounts", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnPPVDeliveryPending(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnPPVDeliveryPending();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on PPV Delivery Pending", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnContractDashboard(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnContractDashboard();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Contract Dashboard", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnTranslationManagement(int stepNumber)
        {
            try
            {

                allpagescreationpage.ClickOnTranslationManagement();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Translation Management", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }



    }
}
