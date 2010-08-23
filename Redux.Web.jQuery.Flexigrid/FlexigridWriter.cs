using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Redux.Web.Html;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Flexigrid
{
    public class FlexigridWriter
    {
        public static void Writer<TModel>(HtmlHelper htmlHelper, string target)
        {
            using (var script = new TemplateScript(htmlHelper.ViewContext, htmlHelper.ViewContext.Writer, htmlHelper.ViewContext.FormContext))
            {
                script.WriteLine(string.Format("$('{0}').{1} (", target, Resources.Options.Flexigrid));
                script.WriteLine(");");
            }
        }

        public static void Writer<TModel>(HtmlHelper htmlHelper, string target, FlexigridConfiguration<TModel> flexigridConfiguration)
        {

            using (var script = new TemplateScript(htmlHelper.ViewContext, htmlHelper.ViewContext.Writer, htmlHelper.ViewContext.FormContext))
            {
                script.WriteLine(string.Format("$('{0}').{1} (", target, Resources.Options.Flexigrid));

                using (var optionsArray = new ScriptArray(htmlHelper.ViewContext.Writer))
                {

                    if (flexigridConfiguration.Columns != null)
                    {
                        using (var colMode = new OptionsArray(htmlHelper.ViewContext.Writer, Resources.Options.Columns))
                        {
                            var dataTable = new DataTable<TModel>();
                            flexigridConfiguration.Columns(dataTable);

                            foreach (var column in dataTable.GetColumns())
                            {
                                var columnInternal = (Column<TModel>)column;

                                using (var columnArray = new ScriptArray(htmlHelper.ViewContext.Writer))
                                {
                                    var property = Property.GetExpressFromProperty(column.Property);

                                    if (!string.IsNullOrEmpty(property))
                                        columnArray.Write(Resources.Options.Display, String.Format("'{0}'", property),
                                                          RenderArrayMode.Comma);

                                    if (!string.IsNullOrEmpty(columnInternal.LabelInternal))
                                        columnArray.Write(Resources.Options.Name, String.Format("'{0}'", columnInternal.LabelInternal),
                                                          RenderArrayMode.Comma);

                                    if (columnInternal.WidthInternal.HasValue)
                                        columnArray.Write(Resources.Options.Width, columnInternal.WidthInternal.Value.ToString(),
                                                          RenderArrayMode.Comma);

                                    columnArray.Write(Resources.Options.Sortable, columnInternal.SortableInternal.ToString().ToLower(),
                                                      RenderArrayMode.Comma);

                                    if (!columnInternal.VisibleInternal)
                                        columnArray.Write(Resources.Options.Hide, String.Format("'{0}'", (!columnInternal.VisibleInternal).ToString().ToLower()),
                                                          RenderArrayMode.Comma);

                                    columnArray.Write(Resources.Options.Align, String.Format("'{0}'", columnInternal.AlignInternal),
                                                      RenderArrayMode.Empty);
                                }

                                if (column != dataTable.GetColumns().Last())
                                {
                                    colMode.Write(",");
                                }
                            }
                        }
                        optionsArray.WriteLine(",");
                    }

                    if (flexigridConfiguration.ButtonsInternal != null)
                    {
                        using (
                            var buttonsMode = new OptionsArray(htmlHelper.ViewContext.Writer, Resources.Options.Buttons)
                            )
                        {
                            var buttons = new ButtonToolbar();
                            flexigridConfiguration.ButtonsInternal(buttons);

                            foreach (var column in buttons.GetButtons())
                            {

                                using (var columnArray = new ScriptArray(htmlHelper.ViewContext.Writer))
                                {
                                    if (column is Button)
                                    {
                                        var btn = column as Button;

                                        if (!string.IsNullOrEmpty(btn.BtnClass))
                                            columnArray.Write(Resources.Options.BtnClass,
                                                              String.Format("'{0}'", btn.BtnClass),
                                                              RenderArrayMode.Comma);

                                        if (!string.IsNullOrEmpty(btn.OnPressCallback))
                                            columnArray.Write(Resources.Options.OnPressCallback, btn.OnPressCallback, RenderArrayMode.Comma);

                                        if (!string.IsNullOrEmpty(btn.Label))
                                            columnArray.Write(Resources.Options.Name, String.Format("'{0}'", btn.Label),
                                                              RenderArrayMode.Empty);
                                    }
                                    else
                                    {
                                        columnArray.Write(Resources.Options.Separator, "true", RenderArrayMode.Empty);

                                    }
                                }

                                if (column != buttons.GetButtons().Last())
                                {
                                    buttonsMode.Write(",");
                                }
                            }
                        }
                                                
                        optionsArray.WriteLine(",");
                    }

                    if (flexigridConfiguration.SearchItemsInternal != null)
                    {
                        using (
                            var searchitemMode = new OptionsArray(htmlHelper.ViewContext.Writer,
                                                                  Resources.Options.SearchItems))
                        {
                            var search = new Search<TModel>();
                            flexigridConfiguration.SearchItemsInternal(search);

                            foreach (var fields in search.GetSearchFields())
                            {

                                using (var columnArray = new ScriptArray(htmlHelper.ViewContext.Writer))
                                {
                                    columnArray.Write(Resources.Options.Display, String.Format("'{0}'", fields.Display),
                                                      RenderArrayMode.Comma);
                                    columnArray.Write(Resources.Options.Name, String.Format("'{0}'", fields.Name),
                                                      RenderArrayMode.Empty);
                                    //columnArray.Write(Resources.Options.Isdefault, fields.IsDefault, RenderArrayMode.Empty);
                                }

                                if (fields != search.GetSearchFields().Last())
                                {
                                    searchitemMode.Write(",");
                                }
                            }
                        }
                    }

                    if (flexigridConfiguration.SortInternal != null)
                    {
                        optionsArray.WriteLine(Resources.Options.SortName, String.Format("'{0}'", flexigridConfiguration.SortInternal), RenderArrayMode.Comma);
                    }

                    if (flexigridConfiguration.OrderInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.SortOrder, String.Format("'{0}'", flexigridConfiguration.OrderInternal), RenderArrayMode.Comma);


                    WriteOptions(optionsArray, flexigridConfiguration);
                }

                script.WriteLine(");");
            }


            if (flexigridConfiguration.Columns != null)
            {
                var dataTable = new DataTable<TModel>();
                flexigridConfiguration.Columns(dataTable);

                foreach (var column in dataTable.GetColumns())
                {
                    var columnInternal = (Column<TModel>) column;

                    if (columnInternal.PostRenderDelegate != null)
                    {
                        htmlHelper.ViewContext.Writer.WriteLine(columnInternal.PostRenderDelegate(columnInternal, htmlHelper));
                    }
                }
            }

            htmlHelper.ViewContext.Writer.Flush();
        }

        private static void WriteOptions<TModel>(ScriptArray optionsArray, FlexigridConfiguration<TModel> flexigridConfiguration)
        {
            if (!string.IsNullOrEmpty(flexigridConfiguration.UrlInternal))
                optionsArray.WriteLine(Resources.Options.Url, string.Format("'{0}'", flexigridConfiguration.UrlInternal), RenderArrayMode.Comma);

            if (flexigridConfiguration.DataTypeInternal.HasValue)
                optionsArray.WriteLine(Resources.Options.DataType, string.Format("'{0}'", flexigridConfiguration.DataTypeInternal.Value.ToString().ToLower()), RenderArrayMode.Comma);   

            if (flexigridConfiguration.SingleSelectInternal.HasValue)
                optionsArray.WriteLine(Resources.Options.SingleSelect, flexigridConfiguration.SingleSelectInternal.Value.ToString().ToLower(), RenderArrayMode.Comma);

            if (!string.IsNullOrEmpty(flexigridConfiguration.TitleInternal))
                optionsArray.WriteLine(Resources.Options.Title, string.Format("'{0}'", flexigridConfiguration.TitleInternal), RenderArrayMode.Comma);

            if (flexigridConfiguration.UseRpInternal.HasValue)
                optionsArray.WriteLine(Resources.Options.UseRp, flexigridConfiguration.UseRpInternal.Value.ToString().ToLower(), RenderArrayMode.Comma);

            if (flexigridConfiguration.RpInternal.HasValue)
                optionsArray.WriteLine(Resources.Options.RP, flexigridConfiguration.RpInternal.Value.ToString(), RenderArrayMode.Comma);

            if (flexigridConfiguration.ShowTableToggleBtnInternal.HasValue)
                optionsArray.WriteLine(Resources.Options.ShowTableToggleButton, flexigridConfiguration.ShowTableToggleBtnInternal.Value.ToString().ToLower(), RenderArrayMode.Comma);

            if (flexigridConfiguration.UsePagerInternal.HasValue)
                optionsArray.WriteLine(Resources.Options.UsePager, flexigridConfiguration.UsePagerInternal.ToString().ToLower(), RenderArrayMode.Comma);

            if (flexigridConfiguration.WidthInternal > 0)
            {
                optionsArray.WriteLine(Resources.Options.Width, flexigridConfiguration.WidthInternal.ToString(),
                                       RenderArrayMode.Comma);
            }
            else
            {
                optionsArray.WriteLine(Resources.Options.Width, "'auto'", RenderArrayMode.Comma);
            }

            if (flexigridConfiguration.HeightInternal > 0)
            {
                optionsArray.WriteLine(Resources.Options.Height, flexigridConfiguration.HeightInternal.ToString(),
                                       RenderArrayMode.Empty);
            }
            else
            {
                optionsArray.WriteLine(Resources.Options.Height, "'auto'", RenderArrayMode.Empty);
            }
        }
    }
}
