using FIT.GTAF.Common.Core.Abstraction;
using FIT.GTAF.IOM.Data.Abstraction.Common;
using FIT.GTAF.IOM.Data.Abstraction.WorkOrder;
using FIT.GTAF.IOM.Pages.Abstraction.Common;
using FIT.GTAF.IOM.Pages.Abstraction.Work_Order;
using FIT.GTAF.IOM.Pages.Abstraction.WorkOrder;
using FIT.GTAF.IOM.WebDriver.Abstraction;
using FIT.GTAF.IOM.Workflow.Abstraction.WorkOrder.Actions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Unity;

namespace FIT.GTAF.IOM.WorkFlow.Impl.WorkOrder.Actions
{
    public class WorkOrderWorkflowActions : IOMWorkflowbase, IWorkOrderWorkflowActions
    {
        private IHomePage homePage = null;
        private IWOCreationRequestPage wocreationrequestPage = null;
        private IWorkOrdersPage workorderPage = null;


        private readonly ICommonData commonData = null;
        private readonly IWorkOrderData workorderData = null;
        private readonly IDictionary<string, string> data = null;
        private readonly IDictionary<int, IDictionary<string, string>> Datas = null;


        public WorkOrderWorkflowActions(IIOMBrowserHelper browser, IReportHelper extent, ILoggerHelper logg, ICommonData commonData, IWorkOrderData workorderData)
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

        }


        public void ChooseClassification(int stepNumber)
        {
            try
            {
                wocreationrequestPage.SetClassification(Datas[stepNumber][commonData.ValidClassification]);


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Choose the Classification ", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }
        public void EnterBuyerInformationDetails(int stepNumber)
        {
            try
            {
                wocreationrequestPage.SetRegion(Datas[stepNumber][commonData.ValidRegion]);
                wocreationrequestPage.SetOEM(Datas[stepNumber][commonData.ValidOEM]);
                wocreationrequestPage.SetBrandStd(Datas[stepNumber][commonData.brandstd]);
                wocreationrequestPage.ClickProgram();
                wocreationrequestPage.SetBuyingMgr(Datas[stepNumber][commonData.ValidBuyingMgr]);

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Enter Buyer information details ", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }
        public void EnterWorkRequestDetails(int stepNumber)
        {
            try
            {
                wocreationrequestPage.SetReason(Datas[stepNumber][commonData.ValidReason]);
                wocreationrequestPage.SetExpectedResult();

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Enter Expected Results Details ", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }
        public void EnterSellerInformationDetails(int stepNumber)
        {
            try
            {
                wocreationrequestPage.SetYear(Datas[stepNumber][commonData.ValidYear]);
                wocreationrequestPage.SetCountry(Datas[stepNumber][commonData.ValidCountry]);
                wocreationrequestPage.SetLocation(Datas[stepNumber][commonData.ValidLocation]);
                wocreationrequestPage.SetFunction(Datas[stepNumber][commonData.ValidFunction]);
                wocreationrequestPage.SetDepartment(Datas[stepNumber][commonData.ValidDepartment]);
                wocreationrequestPage.SetJobLevel(Datas[stepNumber][commonData.ValidJob]);
                wocreationrequestPage.SetDescription(Datas[stepNumber][commonData.ValidDescription]);
                wocreationrequestPage.SetNumberhours(Datas[stepNumber][commonData.ValidHoursNumber]);
                wocreationrequestPage.ClickHoursCost();
                wocreationrequestPage.SetStartmonth(Datas[stepNumber][commonData.ValidStartmonth]);
                wocreationrequestPage.SetFinishmonth(Datas[stepNumber][commonData.ValidFinishmonth]);
                wocreationrequestPage.SetRelatedHead(Datas[stepNumber][commonData.ValidRelatedHead]);
                wocreationrequestPage.SetNonHoursLocation(Datas[stepNumber][commonData.ValidLocation]);
                wocreationrequestPage.SetNonHoursFunction(Datas[stepNumber][commonData.ValidFunction]);
                wocreationrequestPage.SetNonHoursDepartment(Datas[stepNumber][commonData.ValidDepartment]);
                wocreationrequestPage.SetNonHoursJobLevel(Datas[stepNumber][commonData.ValidJob]);
                wocreationrequestPage.SetCostType(Datas[stepNumber][commonData.ValidCostType]);
                wocreationrequestPage.SetNonHoursDescription(Datas[stepNumber][commonData.ValidDescription]);
                wocreationrequestPage.SetUnit(Datas[stepNumber][commonData.ValidUnit]);
                wocreationrequestPage.SetCostUnit(Datas[stepNumber][commonData.ValidCostUnit]);
                wocreationrequestPage.SetQuantity(Datas[stepNumber][commonData.ValidQuantity]);
                wocreationrequestPage.ClickNonHoursCost();

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Enter Seller information details ", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }


        public void ClickOnSubmitforApproval(int stepNumber)
        {
            try
            {
                wocreationrequestPage.ClickonApprovalRequest();

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Approve the request", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnSubmit(int stepNumber)
        {
            try
            {
                wocreationrequestPage.ClickApprove();

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Submit the approved request", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void ClickOnMyWorkQuotation(int stepNumber)
        {
            try
            {
                homePage.ClickMyWorkQuotation();

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on My Work Quotation", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }
        public void ClickOnLastWorkOrder(int stepNumber)
        {
            try
            {
                workorderPage.ClickonWorkOrder();

            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Click on Work Order", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }
        public void ApproveTheWorkOrder(int stepNumber)
        {
            try
            {
                wocreationrequestPage.ResponseRequest(Datas[stepNumber][commonData.ValidAction]);
                wocreationrequestPage.ClickonApprovalRequest();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Approve the request", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }
        public void SellingApproveTheWorkOrder(int stepNumber)
        {
            try
            {
                wocreationrequestPage.ResponseRequestSelling(Datas[stepNumber][commonData.ValidAction]);
                wocreationrequestPage.ClickonApprovalRequest();


            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Approve the request", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }
        public void EnterMandatoryFields(int stepNumber)
        {
            try
            {
                wocreationrequestPage.SetTax(Datas[stepNumber][commonData.ValidTax]);
                wocreationrequestPage.SetMarkup(Datas[stepNumber][commonData.ValidMarkup]);
                wocreationrequestPage.RefreshTax();



            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Enter all Mandatory Fields", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }
        public void ChooseBuyingControllerandSubmit(int stepNumber)
        {
            try
            {
                wocreationrequestPage.ChooseBuyingController(Datas[stepNumber][commonData.ValidBuyingController]);
                wocreationrequestPage.ConfirmBC();



            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Choose the next approver", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }

        public void BuyingControllerApproveTheWorkOrder(int stepNumber)
        {
            try
            {
                wocreationrequestPage.ResponseRequestSelling(Datas[stepNumber][commonData.ValidAction]);
                wocreationrequestPage.SetBAU(Datas[stepNumber][commonData.ValidBAU]);
                wocreationrequestPage.SetWBS(Datas[stepNumber][commonData.ValidWBS]);
                wocreationrequestPage.Submitstdbuyingcontroller();
            }
            catch (Exception ex)
            {
                logging.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                extent.SetStepStatusFail("Approve the request", stepNumber, $"{MethodBase.GetCurrentMethod().Name} crashed : Exception : {ex.Message}");
                throw ex;
            }
        }
    }
}