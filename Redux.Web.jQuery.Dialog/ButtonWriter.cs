using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redux.Web.jQuery.Dialog
{
    public class ButtonWriter
    {
        public static string Writer(Button btn)
        {
            var sb = new StringBuilder();
            
            if (btn.IsUsingForm)
            {
                sb.AppendLine("var $form = $('form', $(this));");
            }

            if (btn.IsValidate)
            {
                sb.AppendLine("if ($form.valid()) {");
            }

            if (btn.IsSubmit)
            {
                if (btn.HasFormOptions && string.IsNullOrEmpty(btn.OptionsInternal))
                {
                    sb.AppendLine("var options = { ");

                    if (!string.IsNullOrEmpty(btn.TargetInternal))
                    {
                        sb.AppendLine(string.Format("{1}: '{0}', ", btn.TargetInternal, Resources.Form.Target));
                    }

                    if (!string.IsNullOrEmpty(btn.BeforeSubmitInternal))
                    {
                        sb.AppendLine(string.Format("{1}: '{0}', ", btn.BeforeSubmitInternal, Resources.Form.Target));
                    }

                    if (!string.IsNullOrEmpty(btn.BeforeSubmitInternal))
                    {
                        sb.AppendLine(string.Format("{1}: '{0}', ", btn.SuccessInternal, Resources.Form.Target));
                    }

                    if (btn.DataInternal.Count() > 0)
                    {
                        sb.AppendLine(string.Format("{0} : ", Resources.Form.Data));
                        sb.Append("{");

                        foreach (var item in btn.DataInternal)
                        {
                            sb.AppendLine(string.Format("{0} : {1}", item.Key, item.Value));

                            if (item.Key != btn.DataInternal.Last().Key)
                            {
                                sb.Append(",");
                            }
                        }

                        sb.AppendLine("},");

                        sb.AppendLine(string.Format("{1}: '{0}', ", btn.SuccessInternal, Resources.Form.Target));
                    }

                    sb.AppendLine("};");

                    sb.AppendLine("$form.ajaxSubmit(options);");
                }
                else if (!string.IsNullOrEmpty(btn.OptionsInternal))
                {
                    sb.AppendLine(string.Format("$form.ajaxSubmit({0});", btn.OptionsInternal));
                }
                else
                {
                    sb.AppendLine("$form.ajaxSubmit();");
                }
            }

            if (!string.IsNullOrEmpty(btn.FunctionInternal))
            {
                sb.AppendLine(btn.FunctionInternal);
            }

            if (btn.IsReset)
            {
                sb.AppendLine("$form.resetForm();");
            }

            if (btn.IsClose)
            {
                sb.AppendLine("$(this).dialog('close');");
            }

            if (btn.IsValidate)
            {
                sb.AppendLine("}");
            }

            return sb.ToString();
        }
    }
}
