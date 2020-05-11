using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWorker.Excel_model_v3
{
    class ExcelDataPage2
    {
        public RowDataTable table;
        public StatPageSettings settings;

        public ExcelDataPage2(ExcelWorksheet sheet)
        {
            settings = new StatPageSettings(sheet);

            var excelTable = sheet.Tables.Where(x => x.Address.Start.Row >=3).FirstOrDefault();
            //if (sheet.Name == "data-i")
            //    excelTable = sheet.Tables.Where(x => x.Address.Start.Row >= 3).Skip(1).Take(1).FirstOrDefault();

            table = new RowDataTable(excelTable);
        }

    

    }
}
