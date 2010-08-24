using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Redux.Web.Html;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Flexigrid
{
    public static class ControllerExtension
    {
        public static FlexigridResult<TModel> FlexigridView<TModel>(this Controller controller, IEnumerable<TModel> collection, int page, int total, Action<IDataTableConfiguration<TModel>> columns)
        {
            var flexigridConfiguration = new FlexigridConfiguration<TModel>(columns);

            var flexigridCollection = new FlexigridCollection<TModel> {page = page, total = total};

            var dataTable = new DataTable<TModel>();
            flexigridConfiguration.Columns(dataTable);

            var dataTableColumns = dataTable.GetColumns();
            var delegates = new List<FlexigridCell<TModel>>();

            Delegate primary = null;
            var primaryColumn = dataTableColumns.Select(p => p.IsPrimary(true)).FirstOrDefault();
            if (primaryColumn != null)
            {
                var prop = Property.GetExpressFromProperty(primaryColumn.Property);
                primary = Property.CreatePropertyDelegate<TModel, object>(prop);
            }

            foreach (var column in dataTableColumns)
            {
                var columnInternal = (Column<TModel>)column;
                var property = Property.GetExpressFromProperty(columnInternal.Property);
                var dlgText = Property.CreatePropertyDelegate<TModel, object>(property);

                var cell = new FlexigridCell<TModel>
                               {
                                   Delegate = dlgText,
                                   Wrapper = "{0}",
                                   Id = columnInternal.PrimaryInternal ? property : string.Empty
                               };

                if (columnInternal.PreRenderDelegate != null)
                {
                    cell.Wrapper = columnInternal.PreRenderDelegate(columnInternal);
                }

                delegates.Add(cell);
            }

            foreach (var row in collection)
            {
                var flexigridRow = new FlexigridRow<TModel>();

                foreach (var dlgText in delegates)
                {
                    var key = primary.DynamicInvoke(row).ToString();

                    var text = dlgText.Delegate.DynamicInvoke(row).ToString();
                    flexigridRow.cell.Add(string.Format(dlgText.Wrapper, text, key));

                    if (!string.IsNullOrEmpty(dlgText.Id))
                    {
                        flexigridRow.id = flexigridRow.cell.Last();
                    }


                }

                flexigridCollection.rows.Add(flexigridRow);
            }

            return new FlexigridResult<TModel>
                             {
                                 Data = flexigridCollection,
                                 ContentType = null,
                                 ContentEncoding = null,
                                 JsonRequestBehavior = JsonRequestBehavior.DenyGet
                             };
        }
    }
}
