using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Redux.Web.jQuery.Flexigrid;
using Redux.Web.Templating;

namespace Redux.Web.Html
{
    public class TableWriter
    {
        public static void Writer<TModel>(HtmlHelper htmlHelper, IEnumerable<TModel> collection, Action<IDataTableConfiguration<TModel>> columns, IDictionary<string, object> htmlAttributes, bool header)
        {
            htmlHelper.ViewContext.Writer.Write(Writer(collection, columns, htmlAttributes, header));
        }

        public static string Writer<TModel>(IEnumerable<TModel> collection, Action<IDataTableConfiguration<TModel>> columns, IDictionary<string, object> htmlAttributes, bool header)
        {
            var table = new TagBuilder("table");
            table.MergeAttributes(htmlAttributes);

            if (columns != null)
            {
                var tHead = new TagBuilder("thead");

                var sbHead = new StringBuilder();

                var hRow = new TagBuilder("tr");

                var delegates = GetColumns(columns);
                
                foreach (var column in delegates)
                {
                    var th = new TagBuilder("th") { InnerHtml = column.Value };
                    sbHead.AppendLine(th.ToString(TagRenderMode.Normal));
                }

                if (header)
                {
                    hRow.InnerHtml = sbHead.ToString();
                    tHead.InnerHtml = hRow.ToString(TagRenderMode.Normal);
                    table.InnerHtml = tHead.ToString(TagRenderMode.Normal);
                }

                table.InnerHtml = table.InnerHtml + WriterBody(collection, delegates.Keys);
            }

            return table.ToString(TagRenderMode.Normal);
        }

        public static string Writer<TModel>(IEnumerable<TModel> collection, Action<IDataTableConfiguration<TModel>> columns)
        {
            if (columns != null)
            {
                var delegates = GetColumns(columns);


                return WriterBody(collection, delegates.Keys);
            }

            return string.Empty;
        }

        private static IDictionary<Delegate, string> GetColumns<TModel>(Action<IDataTableConfiguration<TModel>> columns)
        {
            var delegates = new Dictionary<Delegate, string>();

            if (columns != null)
            {
                var dataTable = new DataTable<TModel>();
                columns(dataTable);

                var dataTableColumns = dataTable.GetColumns();
             
                foreach (var column in dataTableColumns)
                {
                    var property = Property.GetExpressFromProperty(column.Property);
                    var dlgText = Property.CreatePropertyDelegate<TModel, object>(property);

                    if (dlgText == null) throw new NullReferenceException("Property not found");

                    delegates.Add(dlgText, property);
                }
            }

            return delegates;
        }

        private static string WriterBody<TModel>(IEnumerable<TModel> collection, IEnumerable<Delegate> delegates)
        {
            var tBody = new TagBuilder("tbody");

            var sbBody = new StringBuilder();

            foreach (var row in collection)
            {
                var bRow = new TagBuilder("tr");

                if (delegates.Count() > 0)
                {
                    bRow.MergeAttribute("id", "row" + delegates.First().DynamicInvoke(row));
                }

                var sbData = new StringBuilder();

                foreach (var dlgText in delegates)
                {
                    var text = dlgText.DynamicInvoke(row).ToString();
                    var td = new TagBuilder("td") { InnerHtml = text };
                    sbData.Append(td.ToString(TagRenderMode.Normal));
                }

                bRow.InnerHtml = sbData.ToString();
                sbBody.AppendLine(bRow.ToString(TagRenderMode.Normal));
            }

            tBody.InnerHtml = sbBody.ToString();

            return tBody.ToString(TagRenderMode.Normal);
        }
    }
}
