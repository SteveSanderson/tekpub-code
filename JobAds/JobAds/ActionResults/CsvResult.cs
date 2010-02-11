using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Collections;
using System.Reflection;

namespace JobAds.ActionResults
{
    public class CsvResult<T> : ActionResult
    {
        public IEnumerable<T> Data { get; private set; }
        public Func<T, string>[] Columns { get; private set; }

        public CsvResult(IEnumerable<T> data, params Func<T, string>[] columns)
        {
            Data = data;
            Columns = columns;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "text/csv";
            response.AddHeader("Content-Disposition", "attachment; filename=export.csv");

            foreach (var dataItem in Data)
            {
                foreach (var column in Columns)
                    WriteCsvCell(response, column(dataItem));
                response.Write(Environment.NewLine);
            }
        }

        private void WriteCsvCell(HttpResponseBase response, string text)
        {
            // Surround with quotes + escape quotes within the text
            response.Write("\"" + text.Replace("\"", "\"\"") + "\"");
            response.Write(",");
        }
    }
}
