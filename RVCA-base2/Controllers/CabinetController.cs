using ExcelWorker.Excel_model_v3;
using RVCA_base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using RVCA_base2.Models;

namespace RVCA_base2.Controllers
{
    public class CabinetController : Controller
    {
        // GET: Cabinet
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Uk(int id = 0, string additionalAction = null)
        {
            if (id == 0)
                id = 100;

            if (string.IsNullOrEmpty(additionalAction))
            {

                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                if (TempData["postHref"] != null)
                    ViewData["postHref"] = TempData["postHref"];
                else
                    ViewData["postHref"] = "NULL";
                return View("UkView", data);
            }
            else if (additionalAction == "editsummary")
            {
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("UkEditSummary", data);
            }
            else if (additionalAction == "editsummary2")
            {
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("UkEditSummary2", data);
            }
            else if (additionalAction == "editdetails")
            {
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("UkEditDetails", data);
            }
            else if (additionalAction == "editmaindetails")
            {
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("UkEditMainDetails", data);
            }
            else if (additionalAction == "editboss")
            {
                ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/";
                //ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/editboss/";
                if ((!string.IsNullOrEmpty(Request["objId"])) && (Request["objId"] == "0"))
                {
                    CabinetContact item = new CabinetContact();
                    return View("EditContact", item);
                }
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("EditContact", data.ukBosses.First());
            }
            else if (additionalAction == "editemployee")
            {
                ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/";
                //ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/editemployee/";
                if ((!string.IsNullOrEmpty(Request["objId"])) && (Request["objId"] == "0"))
                {
                    CabinetContact item = new CabinetContact();
                    return View("EditContact", item);
                }
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("EditContact", data.ukEmployees.First());
            }
            else if (additionalAction == "editnews")
            {
                ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/";
                //ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/editnews/";
                if ((!string.IsNullOrEmpty(Request["objId"])) && (Request["objId"] == "0"))
                {
                    NewsListItem item = new NewsListItem();
                    return View("EditNews", item);
                }
                int objectId = int.Parse(Request["objId"]);
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("EditNews", data.news.First(x => x.id == objectId));
            }
            else if (additionalAction == "editclosedfund")
            {
                ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/";
                //ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/editclosedfund/";
                if ((!string.IsNullOrEmpty(Request["objId"])) && (Request["objId"] == "0"))
                {
                    UkFundData item = new UkFundData();
                    return View("EditClosedFund", item);
                }
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("EditClosedFund", data.ClosedFunds.First());
            }
            else if (additionalAction == "editmanagementfund")
            {
                ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/";
                //ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/editmanagementfund/";
                if ((!string.IsNullOrEmpty(Request["objId"])) && (Request["objId"] == "0"))
                {
                    UkFundData item = new UkFundData();
                    return View("EditManagementFund", item);
                }
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("EditManagementFund", data.FundsUnderControl.First());
            }
            else if (additionalAction == "editmutualinvestor")
            {
                ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/";
                //ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/editmutualinvestor/";
                if ((!string.IsNullOrEmpty(Request["objId"])) && (Request["objId"] == "0"))
                {
                    MutualInvestor item = new MutualInvestor();
                    return View("EditMutualInvestor", item);
                }
                int objectId = int.Parse(Request["objId"]);
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("EditMutualInvestor", data.mutualInvestors.First(x => x.id == objectId));
            }
            else if (additionalAction == "editfundexits")
            {
                ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/";
                //ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/editfundexits/";
                if ((!string.IsNullOrEmpty(Request["objId"])) && (Request["objId"] == "0"))
                {
                    FundExitsListItem item = new FundExitsListItem();
                    return View("EditFundExit", item);
                }
                int objectId = int.Parse(Request["objId"]);
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("EditFundExit", data.fundExits.First(x => x.id == objectId));
            }
            else if (additionalAction == "editfundinvestments")
            {
                ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/";
                //ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/editfundinvestments/";
                if ((!string.IsNullOrEmpty(Request["objId"])) && (Request["objId"] == "0"))
                {
                    FundInvestmentsListItem item = new FundInvestmentsListItem();
                    return View("EditFundInvestments", item);
                }
                int objectId = int.Parse(Request["objId"]);
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("EditFundInvestments", data.fundInvestments.First(x => x.id == objectId));
            }
            else if (additionalAction == "editsupplier")
            {
                ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/";
                //ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/editsupplier/";
                if ((!string.IsNullOrEmpty(Request["objId"])) && (Request["objId"] == "0"))
                {
                    UkPartnerData item = new UkPartnerData();
                    return View("EditPartnerData", item);
                }
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("EditPartnerData", data.Postavshiki.First());
            }
            else if (additionalAction == "editauditor")
            {
                ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/";
                //ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/editauditor/";
                if ((!string.IsNullOrEmpty(Request["objId"])) && (Request["objId"] == "0"))
                {
                    UkPartnerData item = new UkPartnerData();
                    return View("EditPartnerData", item);
                }
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("EditPartnerData", data.Auditor.First());
            }
            else if (additionalAction == "editconsultant")
            {
                ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/";
                //ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/editconsultant/";
                if ((!string.IsNullOrEmpty(Request["objId"])) && (Request["objId"] == "0"))
                {
                    UkPartnerData item = new UkPartnerData();
                    return View("EditPartnerData", item);
                }
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("EditPartnerData", data.LawConsultants.First());
            }
            else if (additionalAction == "editagent")
            {
                ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/";
                //ViewData["SubmitUrl"] = "/cabinet/uk/" + id + "/editagent/";
                if ((!string.IsNullOrEmpty(Request["objId"])) && (Request["objId"] == "0"))
                {
                    UkPartnerData item = new UkPartnerData();
                    return View("EditPartnerData", item);
                }
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                return View("EditPartnerData", data.ListingAgent.First());
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ActionName("uk")]
        public ActionResult UkPost(int id = 0, string additionalAction = null)
        {
            string path = "/cabinet/uk/";
            if (id != 0)
                path = path + id.ToString() + "/";
            if (additionalAction == "editsummary")
            {
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                TempData["postHref"] = "local#summary";
            }
            else if (additionalAction == "editsummary2")
            {
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                TempData["postHref"] = "local#summary2";
            }
            else if (additionalAction == "editdetails")
            {
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                TempData["postHref"] = "local#details";
            }
            else if (additionalAction == "editmaindetails")
            {
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                TempData["postHref"] = "local#maindetails";
            }
            else
            {
                CabinetUkData data = MyExcel.GetDataFromDataSource(id);
                ViewData["postHref"] = "NULL";
                return View("UkView", data);
            }
            return Redirect(path);
        }
    }
}