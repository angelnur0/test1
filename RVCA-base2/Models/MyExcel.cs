using ExcelWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using ExcelWorker.Excel_model_v3;
using RVCA_base2.Models;

namespace RVCA_base.Models
{
    static public class MyExcel
    {
        static ExcelDocument excelDocument = null;

        public static ExcelDocument GetWorkbook()
        {
            return excelDocument;
        }

        public static void LoadExcel(string excelFilePath)
        {
            excelDocument = new ExcelDocument(excelFilePath);
        }
        
        public static List<MenuItem> GetMenu()
        {
            return excelDocument.menu.GetMenu();
        }

        public static MenuTree GetMenuTree()
        {
            return excelDocument.menu.GetMenuTree();
        }

        public static ExcelStatPage GetStatPageByLink(string link)
        {
            return excelDocument.GetStatPageByLink(link);
        }

        public static string GetSubDataTable(DataFilters filters, DataFields fields)
        {
            return excelDocument.GetSubDataTableJS(filters, fields);
        }

        public static DateTime GetLastModifiedDate()
        {
            return excelDocument.lastModifiedDate;
        }

        public static DataRow GetDetails(string tableName, int id)
        {
            return excelDocument.GetDetails(tableName, id);
        }

        public static DataRow GetDetailByField(string tableName, string fieldName,string fieldValue)
        {
            return excelDocument.GetDetailByField(tableName, fieldName,fieldValue.TrimStart(' ').TrimEnd(' '));
        }

        public static DataRow[] GetDetailsList(string tableName, string condition)
        {
            return excelDocument.GetDetailsList(tableName, condition);
        }

        public static string GetSearchResultFields(string tableName)
        {
            return excelDocument.GetSearchResultFields(tableName);
        }

        public static InvestmentResult GetInvestmentResult(int recordId)
        {
            DataRow ukAllData = MyExcel.GetDetails("f_3", recordId);
            InvestmentResult data = new InvestmentResult();
            data.fundId = ukAllData[0].ToString();
            data.fundName = ukAllData[3].ToString();
            data.foundatationDate = ukAllData[4].ToString();
            data.fundSizeAtFinalClosing = "0";
            data.activesUnderManagement = ukAllData[6].ToString();
            data.dateOfData = ukAllData[7].ToString();
            data.fundStatus = ukAllData[8].ToString();
            data.numberOfInvestment = ukAllData[9].ToString();
            data.numberOfExits = ukAllData[10].ToString();
            data.numberOfCompaniesInPortfolio = ukAllData[11].ToString();
            data.targetIRR = ukAllData[12].ToString();
            data.factIRR = ukAllData[13].ToString();
            data.dryPowder = ukAllData[14].ToString();
            data.MedianValueOfInvesmentRound = ukAllData[15].ToString();
            data.ManagementCompany = ukAllData[16].ToString();
            data.ManagementCompanyId = MapUKToId_HAckED(ukAllData[16].ToString(), 0).ToString();
            data.Strategy = ukAllData[5].ToString();
            return data;
        }

        public static FundData GetFundDataFromDataSource(int recordId)
        {
            DataRow ukAllData = MyExcel.GetDetails("f_2", recordId);
            FundData data = new FundData()
            {
                id = int.Parse(ukAllData[2].ToString()),
                Title = ukAllData[3].ToString(),
                Jurisdiction = ukAllData[32].ToString(),
                WebSite = ukAllData[28].ToString(),
                InvestorType = ukAllData[5].ToString(),
                FundType = ukAllData[5].ToString(),
                FoundationDate = ukAllData[6].ToString(),
                Geography = ukAllData[19].ToString().Replace(";", "<br/>"),
                GeographyFocus = ukAllData[20].ToString().Replace(";", "<br/>"),
                PrefferedRegions = ukAllData[21].ToString().Replace(";", "<br/>"),
                IndustrialFocus = ukAllData[22].ToString().Replace(";", "<br/>"),
                StageFocus = ukAllData[23].ToString().Replace(";", "<br/>"),
                TotalInvestmentsCount = ukAllData[24].ToString(),
                CurrentPortfolio = ukAllData[25].ToString(),
                InvestmentsDuringYear = ukAllData[26].ToString(),
                Exits = ukAllData[27].ToString(),
                MedianRoundVolume = ukAllData[28].ToString(),
                MedianMark = ukAllData[29].ToString(),
                NumberOfProfessionals = ukAllData[30].ToString(),
                PlannedInvestments = ukAllData[31].ToString(),
                PlannedInvestmentsPerCompany = ukAllData[32].ToString(),
                PEVC_FundType = ukAllData[33].ToString(),
                WithGovernment = ukAllData[34].ToString(),
                SeedOrNot = ukAllData[35].ToString(),
                IKTOrNot= ukAllData[36].ToString(),
                CorpOrNot= "",//fix it later

                Agent = ukAllData[37].ToString(),
                LawConsultants = ukAllData[38].ToString(),
                Auditor = ukAllData[39].ToString(),
                Administrator = ukAllData[40].ToString(),
                Etics = ukAllData[41].ToString(),
                HeadOfficeCountry = ukAllData[42].ToString(),
                HeadOfficeAddress = ukAllData[44].ToString(),
                HeadOfficeJurisdiction = ukAllData[43].ToString(),
                AlternateOfficeAddress = ukAllData[45].ToString(),
                Url = ukAllData[46].ToString(),
                Email = ukAllData[47].ToString(),
                Phone = ukAllData[48].ToString(),
                MainDetails_ManagingCompany = ukAllData[57].ToString(),
                MainDetails_FundValue = ukAllData[58].ToString(),
                //MainDetails_DateOfCommitmentFixing { get; set; }
                MainDetails_FundType = ukAllData[59].ToString(),
                MainDetails_FinanceSources = ukAllData[60].ToString().Replace(";", "<br/>"),
                MainDetails_FundrisingStartDate = ukAllData[61].ToString(),
                MainDetails_FundStatus = ukAllData[62].ToString().TrimEnd(';'),
                MainDetails_TotalCapitalForFinalClosing = ukAllData[63].ToString(),
                MainDetails_InvestorExamples = ukAllData[64].ToString().Replace(";", "<br/>"),
            };

            data.InvestHorizont = ukAllData[105].ToString();
            data.InvestPeriod = ukAllData[106].ToString();
            data.FundSpecialization = ukAllData[107].ToString().Replace(";", "<br/>");
            data.ByingSharePreference = ukAllData[108].ToString();
            data.FundNominationCurrency = ukAllData[109].ToString();
            data.CompanySize = ukAllData[110].ToString().Replace(";", "<br/>");
            data.InvestitionPozition = ukAllData[111].ToString();

            data.GeographicOhvat = ukAllData[112].ToString();
            data.GeographicFocus = ukAllData[113].ToString().Replace(";", "<br/>");
            data.GeographyByRegions = ukAllData[114].ToString();

            data.OtraslPreference = ukAllData[115].ToString().Replace(";", "<br/>");
            data.StagePreference = ukAllData[116].ToString().Replace(";", "<br/>");

            return data;
        }

        public static InvestmentData GetInvestmentDataFromDataSource(int recordId)
        {
            DataRow ukAllData = MyExcel.GetDetails("i", recordId);
            InvestmentData data = new InvestmentData()
            {
                id = int.Parse(ukAllData[33].ToString()),
                fund_id = int.Parse(ukAllData[0].ToString()),
                ProjectName = ukAllData[1].ToString(),
                Otrasl = ukAllData[2].ToString(),
                Region = ukAllData[3].ToString(),

                Description = ukAllData[4].ToString(),
                Date = ukAllData[5].ToString(),
                AnouncementDate = ukAllData[6].ToString(),
                InvestmentVolume = ukAllData[7].ToString(),

                Stage = ukAllData[8].ToString(),
                Round = ukAllData[9].ToString(),
                DealType = ukAllData[10].ToString(),
                InvestorName = ukAllData[11].ToString(),
                InvestorType = ukAllData[12].ToString(),
                InvestorLocation = ukAllData[13].ToString(),

                SellerName = ukAllData[14].ToString(),
                SellerType = "",
                SellerLocation = ukAllData[15].ToString(),
                InvestmentInCapital = ukAllData[16].ToString(),
                AquiredShare = ukAllData[17].ToString(),
                TotalInvestorShare = ukAllData[18].ToString(),
                StockSplit = ukAllData[19].ToString(),
                PreMoneyValuation = ukAllData[20].ToString(),
                PostValuation = ukAllData[21].ToString(),
                DealVolume = ukAllData[22].ToString(),
                DealStatus = ukAllData[23].ToString(),
                TotalInvested = ukAllData[24].ToString(),
                Sindicated = ukAllData[25].ToString(),
                FollowOn = ukAllData[26].ToString(),
                Suppliers = ukAllData[27].ToString()
            };
            return data;
        }

        public static CabinetUkData GetDataFromDataSource(int recordId)
        {
            DataRow ukAllData = MyExcel.GetDetails("m", recordId);
            CabinetUkData data = new CabinetUkData()
            {
                id = int.Parse(ukAllData[0].ToString()),
                Title = ukAllData[2].ToString(),
                Jurisdiction = ukAllData[4].ToString(),
                FoundationDate = ukAllData[5].ToString(),
                HeadOfficeCountry = ukAllData[6].ToString(),
            };

            return data;
        }

        public static int MapFundToId(string fundName,int proposedId)
        {
            fundName = fundName.Trim('\n');
            fundName = fundName.Trim(' ');
            int result = proposedId;
            switch (fundName)
            {
                case "Фонд содействия развитию венчурных инвестиций в малые предприятия в научно-технической сфере города Москвы":
                    return 100;
                case "Rusnano Sistema SICAR":
                case "RUSNANO SISTEMA Sicar":
                    return 101;
                case "Дальневосточный Фонд Высоких Технологий":
                    return 102;
                case "Baring Vostok Private Equity Fund IV + Baring Vostok Private Equity Fund IV Supplemental Fund":
                    return 103;
                case "Baring Vostok Private Equity Fund V + Baring Vostok Private Equity Fund V Supplemental Fund":
                    return 104;
            }
            return result;
        }

        public static int MapUKToId(string fundName, int proposedId)
        {
            int result = proposedId;
            switch (fundName)
            {
                case "Фонд содействия развитию венчурных инвестиций в малые предприятия в научно-технической сфере города Москвы":
                    return 100;
                case "ООО УК РОСНАНО":
                    return 101;
                case "Baring Vostok Capital Partners":
                    return 102;
            }
            return result;
        }

        public static int MapUKToId_HAckED(string fundName, int proposedId)
        {
            int result = proposedId;
            switch (fundName)
            {
                case "Фонд содействия развитию венчурных инвестиций в малые предприятия в научно-технической сфере города Москвы":
                    return 100;
                case "ООО УК РОСНАНО":
                case "RN Consulting S.A, \nООО \"Система Консалт\"":
                case "ООО «УК Дальневосточный фонд высоких технологий»":
                    return 101;
                case "Baring Vostok Capital Partners":
                    return 102;
            }
            return result;
        }
    }
};