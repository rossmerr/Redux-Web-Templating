using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Dialog
{
    public class DialogWriter
    {
        public static void Writer(HtmlHelper htmlHelper, string target, DialogConfiguration dialogConfiguration)
        {
            using (var script = new TemplateScript(htmlHelper.ViewContext, htmlHelper.ViewContext.Writer, htmlHelper.ViewContext.FormContext))
            {

                if (!string.IsNullOrEmpty(dialogConfiguration.UrlInternal))
                {
                    script.WriteLine(string.Format("function {0}(content){1}", Resources.Options.CallbackFunction, "{"));
                    script.WriteLine(string.Format(" var $dialog = $('{0}').html(content);", target));
                    script.WriteLine("$('form', $dialog).validate();");
                    script.WriteLine("};");
                    script.WriteLine(string.Format("$.get('{0}', {1}, {2});", dialogConfiguration.UrlInternal, "{}",
                                                   Resources.Options.CallbackFunction));
                }

                script.WriteLine(string.Format("$('{0}').{1} (", target, Resources.Options.Dialog));

                using (var optionsArray = new ScriptArray(htmlHelper.ViewContext.Writer))
                {
                    if (dialogConfiguration.DisabledInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.Disabled, string.Format("{0}", dialogConfiguration.DisabledInternal.ToString().ToLower()), RenderArrayMode.Comma);

                    if (dialogConfiguration.AutoOpenInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.AutoOpen, string.Format("{0}", dialogConfiguration.AutoOpenInternal.ToString().ToLower()), RenderArrayMode.Comma);

                    if (dialogConfiguration.CloseOnEscapeInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.CloseOnEscape, string.Format("{0}", dialogConfiguration.CloseOnEscapeInternal.ToString().ToLower()), RenderArrayMode.Comma);

                    if (!string.IsNullOrEmpty(dialogConfiguration.CloseTextInternal))
                        optionsArray.WriteLine(Resources.Options.CloseText, string.Format("'{0}'", dialogConfiguration.CloseTextInternal), RenderArrayMode.Comma);

                    if (!string.IsNullOrEmpty(dialogConfiguration.DialogClassInternal))
                        optionsArray.WriteLine(Resources.Options.DialogClass, string.Format("'{0}'", dialogConfiguration.DialogClassInternal), RenderArrayMode.Comma);

                    if (dialogConfiguration.DraggableInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.Draggable, string.Format("{0}", dialogConfiguration.DraggableInternal.ToString().ToLower()), RenderArrayMode.Comma);

                    if (dialogConfiguration.HeightInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.Height, string.Format("{0}", dialogConfiguration.HeightInternal), RenderArrayMode.Comma);

                    if (dialogConfiguration.HideInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.Hide, string.Format("{0}", dialogConfiguration.HideInternal.ToString().ToLower()), RenderArrayMode.Comma);

                    if (dialogConfiguration.MaxHeightInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.MaxHeight, string.Format("{0}", dialogConfiguration.MaxHeightInternal), RenderArrayMode.Comma);

                    if (dialogConfiguration.MaxWidthInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.MaxWidth, string.Format("{0}", dialogConfiguration.MaxWidthInternal), RenderArrayMode.Comma);

                    if (dialogConfiguration.MinHeightInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.MinHeight, string.Format("{0}", dialogConfiguration.MinHeightInternal), RenderArrayMode.Comma);

                    if (dialogConfiguration.MinWidthInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.MinWidth, string.Format("{0}", dialogConfiguration.MinWidthInternal), RenderArrayMode.Comma);

                    if (dialogConfiguration.ModalInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.Modal, string.Format("{0}", dialogConfiguration.ModalInternal), RenderArrayMode.Comma);

                    if (!string.IsNullOrEmpty(dialogConfiguration.PositionInternal))
                        optionsArray.WriteLine(Resources.Options.Position, string.Format("'{0}'", dialogConfiguration.PositionInternal.ToLower()), RenderArrayMode.Comma);

                    if (dialogConfiguration.ResizableInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.Resizable, string.Format("{0}", dialogConfiguration.ResizableInternal.ToString().ToLower()), RenderArrayMode.Comma);

                    if (!string.IsNullOrEmpty(dialogConfiguration.ShowInternal))
                        optionsArray.WriteLine(Resources.Options.Show, string.Format("'{0}'", dialogConfiguration.ShowInternal.ToLower()), RenderArrayMode.Comma);

                    if (dialogConfiguration.StackInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.Stack, string.Format("{0}", dialogConfiguration.StackInternal.ToString().ToLower()), RenderArrayMode.Comma);

                    if (!string.IsNullOrEmpty(dialogConfiguration.TitleInternal))
                        optionsArray.WriteLine(Resources.Options.Title, string.Format("'{0}'", dialogConfiguration.TitleInternal), RenderArrayMode.Comma);

                    if (dialogConfiguration.WidthInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.Width, string.Format("{0}", dialogConfiguration.WidthInternal), RenderArrayMode.Comma);

                    if (dialogConfiguration.ZIndexInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.ZIndex, string.Format("{0}", dialogConfiguration.ZIndexInternal), RenderArrayMode.Comma);

                    if (dialogConfiguration.ButtonsInternal != null)
                    {
                        using (var buttonsMode = new OptionsArray(htmlHelper.ViewContext.Writer, Resources.Options.Buttons))
                        {
                            var buttons = new ButtonToolbar();
                            dialogConfiguration.ButtonsInternal(buttons);

                            buttonsMode.Write(Resources.Options.Buttons  + ": {");

                            foreach (var column in buttons.GetButtons())
                            {
                                using (var columnArray = new ScriptArray(htmlHelper.ViewContext.Writer))
                                {
                                    var btn = column as Button;

                                    if (!string.IsNullOrEmpty(btn.Label))
                                        columnArray.WriteLine(String.Format("'{0}': {1}", btn.Label, btn.OnPressCallback));
                                }

                                if (column != buttons.GetButtons().Last())
                                {
                                    buttonsMode.Write(",");
                                }
                            }

                            buttonsMode.Write("}");
                        }

                        optionsArray.WriteLine(",");
                    }

                    // Removes the last comma
                    if (optionsArray.Length > 4)
                    {
                        optionsArray.Remove((optionsArray.Length - 4), 1);
                    }
                }

                script.WriteLine(");");
            }
        }
    }
}
