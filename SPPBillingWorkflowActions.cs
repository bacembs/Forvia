using FIT.GTAF.Common.Core.Abstraction;
using FIT.GTAF.IOM.Data.Abstraction.Common;
using FIT.GTAF.IOM.Data.Abstraction.ADDON;
using FIT.GTAF.IOM.Data.Abstraction.WorkOrder;
using FIT.GTAF.IOM.Pages.Abstraction.Common;
using FIT.GTAF.IOM.Pages.Abstraction.IADDON;
using FIT.GTAF.IOM.Pages.Abstraction.Work_Order;
using FIT.GTAF.IOM.Pages.Abstraction.WorkOrder;
using FIT.GTAF.IOM.WebDriver.Abstraction;
using FIT.GTAF.IOM.Workflow.Abstraction.ADDON.Actions;
using FIT.GTAF.IOM.Workflow.Abstraction.WorkOrder.Actions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Unity;
using FIT.GTAF.IOM.Workflow.Abstraction.PPVWorkOrder.Actions;
using FIT.GTAF.IOM.Data.Abstraction.PPVWorkOrder;
using FIT.GTAF.IOM.Pages.Abstraction.IPPVWorkOrderPage;
using FIT.GTAF.IOM.Pages.Impl.PPVWorkOrderPage;
using FIT.GTAF.IOM.Workflow.Abstraction.ADDOnWoFMO.Actions;
using FIT.GTAF.IOM.Pages.Abstraction.IADDOnWoFMO;
using FIT.GTAF.IOM.Data.Abstraction.ADDOnWoFMO;
using FIT.GTAF.IOM.Data.Abstraction.AllPages;
using FIT.GTAF.IOM.Data.Abstraction.FeaturesMenuOptions;
using FIT.GTAF.IOM.Data.Abstraction.HubHelpStream;
using FIT.GTAF.IOM.Data.Abstraction.HubStream;
using FIT.GTAF.IOM.Data.Abstraction.PPVWoFMO;
using FIT.GTAF.IOM.Data.Impl.PPVWoFMO.Model;
using FIT.GTAF.IOM.Pages.Impl.PPVWoFMOPage;
using FIT.GTAF.IOM.Workflow.Abstraction.PPVBilling.Actions;
using FIT.GTAF.IOM.Pages.Abstraction.IPPVBillingPage;
using FIT.GTAF.IOM.Data.Abstraction.PPVBilling;
using FIT.GTAF.IOM.Pages.Impl.AllPagesPage;
using FIT.GTAF.IOM.Workflow.Abstraction.STDBilling.Actions;
using FIT.GTAF.IOM.Pages.Impl.STDBillingPage;
using FIT.GTAF.IOM.Data.Abstraction.STDBilling;
using FIT.GTAF.IOM.Pages.Abstraction.ISTDBillingPage;
using System.IO;
using OfficeOpenXml;
using System.Linq;
using OpenQA.Selenium;



namespace FIT.GTAF.IOM.WorkFlow.Impl.STDBilling.Actions
{
    public class STDBillingWorkflowActions : IOMWorkflowbase, ISTDBillingWorkflowActions
    {
        private IHomePage homePage = null;
        private IWOCreationRequestPage wocreationrequestPage = null;
        private IADDONCreationPage addoncreationpage = null;
        private IWorkOrdersPage workorderPage = null;
        private IADDOnWoFMOCreationPage addonfmocreationpage = null;
        private IPPVBillingCreationPage ppvbillingcreationpage = null;
        private ISTDBillingCreationPage stdbillingcreationpage = null;


        private readonly IWorkOrderData workorderData = null;
        private readonly ICommonData commonData = null;
        private readonly IADDONData addondata = null;
        private readonly IADDOnWoFMOData addonfmodata = null;
        private readonly IPPVBillingData ppvbillingdata = null;
        private readonly ISTDBillingData stdbillingdata = null;


        private readonly IDictionary<string, string> data = null;
        private readonly IDictionary<int, IDictionary<string, string>> Datas = null;


        public STDBillingWorkflowActions(IIOMBrowserHelper browser, IReportHelper extent, ILoggerHelper logg,
            ICommonData commonData,IWorkOrderData workorderData, IPPVWorkOrderData ppvworkorderdata, IHubStream hubstreamdata,
            IHubHelpStreamData hubhelpstreamdata, IAllPagesData allpagesdata, IFeaturesMenuOptionsData featuresmenuoptionsData,
            IPPVWoFMOData ppvwofmoData, IADDOnWoFMOData addonfmodata, IPPVBillingData ppvbillingdata, ISTDBillingData stdbillingdata)
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
            addoncreationpage = unityContainer.Resolve<IADDONCreationPage>();
            addonfmocreationpage = unityContainer.Resolve<IADDOnWoFMOCreationPage>();
            ppvbillingcreationpage = unityContainer.Resolve<IPPVBillingCreationPage>();
            stdbillingcreationpage = unityContainer.Resolve<ISTDBillingCreationPage>();
            this.stdbillingdata = stdbillingdata;

        }

        public void UpdateSellerReference(int stepNumber)
        {
            try
            {

                stdbillingcreationpage.ClickUpdate();
                stdbillingcreationpage.SetUpdateSellerReference(Datas[stepNumber][stdbillingdata.WBS]);
                stdbillingcreationpage.PickBilledStatus(Datas[stepNumber][stdbillingdata.Status]);
                stdbillingcreationpage.ClickUpdateSeller();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Update", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnSTDSalesOrdeBillingPending(int stepNumber)
        {
            try
            {

                stdbillingcreationpage.ClickOnSTDSalesOrdeBillingPending();             

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("STD Sales Order Billing Pending", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void PickBAUSTDWoBilling(int stepNumber)
        {
            try
            {

                stdbillingcreationpage.ClickOnBauSeller(Datas[stepNumber][stdbillingdata.SellerBau]);
                stdbillingcreationpage.ClickOnBauBuyer(Datas[stepNumber][stdbillingdata.BuyerBau]);


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("BAU", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnExcelDashboardImportTemplate(int stepNumber)
        {
            try
            {

                stdbillingcreationpage.ClicKOnDashboardExcel();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("BAU", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ModifyExcelFile(int stepNumber)
        {
            try
            {
               
                stdbillingcreationpage.GetLastDownloadedFileexcel();
                stdbillingcreationpage.ModifyExcelFileDownloaded(Datas[stepNumber][stdbillingdata.Object],Datas[stepNumber][stdbillingdata.CostElem],
                    Datas[stepNumber][stdbillingdata.Period],Datas[stepNumber][stdbillingdata.ActualCostToDateEUR],Datas[stepNumber][stdbillingdata.InvoicedToDateEUR]);


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Modify Excel", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnImportDataControllerSTD(int stepNumber)
        {
            try
            {
                stdbillingcreationpage.ClickImportDataCont();
                stdbillingcreationpage.ClickPickTheFile();
                stdbillingcreationpage.ClickActualDate();
                stdbillingcreationpage.ClickUploadSTDBilling();
                stdbillingcreationpage.ClickUpdateStatusIOM();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Import Data Controller", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickBillingReleaseSTD(int stepNumber)
        {
            try
            {

                stdbillingcreationpage.ClickBillingReleaseSTDWo();
                stdbillingcreationpage.ClickAddToBILL();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Billing Release STD Wo", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickFileNameBillingSTD(int stepNumber)
        {
            try
            {

                stdbillingcreationpage.ClicKOnBillingSTDExcel();

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Billing", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }









    }
}
