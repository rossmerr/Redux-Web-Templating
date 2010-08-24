using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.SmartTextBox
{
    public class SmartTextBoxWriter
    {
        public static void Writer<TModel>(HtmlHelper<TModel> htmlHelper, string target)
        {
            using (var script = new TemplateScript(htmlHelper.ViewContext, htmlHelper.ViewContext.Writer, htmlHelper.ViewContext.FormContext))
            {
                script.WriteLine(string.Format("$('#{0}').{1} (", target, Resources.Options.SmartTextBox));
                script.WriteLine(");");
            }
        }

        public static void Writer<TModel>(HtmlHelper<TModel> htmlHelper, string target, SmartTextBoxConfiguration<TModel> smartTextBoxConfiguration)
        {
            using (var script = new TemplateScript(htmlHelper.ViewContext, htmlHelper.ViewContext.Writer, htmlHelper.ViewContext.FormContext))
            {
                script.WriteLine(string.Format("$('#{0}').{1} (", target, Resources.Options.SmartTextBox));

                using (var optionsArray = new ScriptArray(htmlHelper.ViewContext.Writer))
                {

                    if (smartTextBoxConfiguration.AutocompleteInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.Autocomplete, string.Format("'{0}'", smartTextBoxConfiguration.AutocompleteInternal.Value.ToString().ToLower()), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.MinSearchLengthInternal != 2)
                        optionsArray.WriteLine(Resources.Options.MinSearchLength, string.Format("{0}", smartTextBoxConfiguration.MinSearchLengthInternal), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.MaxResultsInternal != 10)
                        optionsArray.WriteLine(Resources.Options.MaxResults, string.Format("{0}", smartTextBoxConfiguration.MaxResultsInternal), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.CaseSensitiveInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.CaseSensitive, string.Format("'{0}'", smartTextBoxConfiguration.CaseSensitiveInternal.Value.ToString().ToLower()), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.HighlightInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.Highlight, string.Format("'{0}'", smartTextBoxConfiguration.HighlightInternal.Value.ToString().ToLower()), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.FullSearchInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.FullSearch, string.Format("'{0}'", smartTextBoxConfiguration.FullSearchInternal.Value.ToString().ToLower()), RenderArrayMode.Comma);

                    if (!string.IsNullOrEmpty(smartTextBoxConfiguration.PlaceholderInternal))
                        optionsArray.WriteLine(Resources.Options.Placeholder, string.Format("'{0}'", smartTextBoxConfiguration.PlaceholderInternal), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.AutocompleteValuesInternal != null)
                    {
                        var sb = new StringBuilder();

                        foreach(var item in smartTextBoxConfiguration.AutocompleteValuesInternal)
                        {
                            sb.Append(string.Format("\"{0}\"", item));
                            sb.Append(",");
                        }

                        optionsArray.WriteLine(Resources.Options.AutocompleteValues, string.Format("[{0}]", sb.ToString().TrimEnd(',')), RenderArrayMode.Comma);
                    }
                    if (!string.IsNullOrEmpty(smartTextBoxConfiguration.UrlInternal))
                        optionsArray.WriteLine(Resources.Options.AutocompleteUrl, string.Format("'{0}'", smartTextBoxConfiguration.UrlInternal), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.OnlyAutocompleteInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.OnlyAutocomplete, string.Format("'{0}'", smartTextBoxConfiguration.OnlyAutocompleteInternal.Value.ToString().ToLower()), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.UniqueValuesInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.UniqueValues, string.Format("{0}", smartTextBoxConfiguration.UniqueValuesInternal.Value.ToString().ToLower()), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.HideEmptyInputsInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.HideEmptyInputs, string.Format("'{0}'", smartTextBoxConfiguration.HideEmptyInputsInternal.Value), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.EditOnFocusInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.EditOnFocus, string.Format("'{0}'", smartTextBoxConfiguration.EditOnFocusInternal.Value.ToString().ToLower()), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.EditOnDoubleClickInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.EditOnDoubleClick, string.Format("'{0}'", smartTextBoxConfiguration.EditOnDoubleClickInternal.Value.ToString().ToLower()), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.SubmitKeysInternal != null)
                    {
                        var sb = new StringBuilder();

                        foreach (var item in smartTextBoxConfiguration.SubmitKeysInternal)
                        {
                            sb.Append(string.Format("{0}", item));
                            sb.Append(",");
                        }

                        optionsArray.WriteLine(Resources.Options.SubmitKeys,
                                               string.Format("[{0}]", sb.ToString().TrimEnd(',')),
                                               RenderArrayMode.Comma);
                    }
                    if (smartTextBoxConfiguration.SubmitCharsInternal != null)
                    {
                        var sb = new StringBuilder();

                        foreach (var item in smartTextBoxConfiguration.SubmitCharsInternal)
                        {
                            sb.Append(string.Format("\"{0}\"", item));
                            sb.Append(",");
                        }

                        optionsArray.WriteLine(Resources.Options.SubmitChars,
                                               string.Format("[{0}]", sb.ToString().TrimEnd(',')),
                                               RenderArrayMode.Comma);
                    }
                    if (!string.IsNullOrEmpty(smartTextBoxConfiguration.ContainerClassInternal))
                        optionsArray.WriteLine(Resources.Options.ContainerClass, string.Format("'{0}'", smartTextBoxConfiguration.ContainerClassInternal), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.SeparatorInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.Separator, string.Format("'{0}'", smartTextBoxConfiguration.SeparatorInternal.Value), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.UpdateOriginalInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.UpdateOriginal, string.Format("'{0}'", smartTextBoxConfiguration.UpdateOriginalInternal.Value.ToString().ToLower()), RenderArrayMode.Comma);

                    if (smartTextBoxConfiguration.DebugInternal.HasValue)
                        optionsArray.WriteLine(Resources.Options.Debug, string.Format("'{0}'", smartTextBoxConfiguration.DebugInternal.Value.ToString().ToLower()), RenderArrayMode.Comma);

                    
                }
                script.WriteLine(");");
            }
        }
    }
}
