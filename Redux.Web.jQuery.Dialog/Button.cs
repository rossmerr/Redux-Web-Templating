using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Dialog
{
    public class Button : IDialogButtonSubmit
    {
        public Button(string label)
        {
            Label = label;
        }

        public string Label
        {
            get;
            protected set;
        }

        public string BtnClass
        {
            get;
            protected set;
        }

        public string OnPressCallback
        {
            get
            {
                var sb = new StringBuilder();

                if (IsUsingForm)
                {
                    sb.AppendLine("var $form = $('form', $(this));");
                }

                if (IsValidate)
                {
                    sb.AppendLine("if ($form.valid()) {");
                }

                if (IsSubmit)
                {
                    if (HasFormOptions && string.IsNullOrEmpty(OptionsInternal))
                    {
                        sb.AppendLine("var options = { ");

                        if (!string.IsNullOrEmpty(target))
                        {
                            sb.AppendLine(string.Format("{1}: '{0}', ", target, Resources.Form.Target));
                        }

                        if (!string.IsNullOrEmpty(beforeSubmit))
                        {
                            sb.AppendLine(string.Format("{1}: '{0}', ", beforeSubmit, Resources.Form.Target));
                        }

                        if (!string.IsNullOrEmpty(beforeSubmit))
                        {
                            sb.AppendLine(string.Format("{1}: '{0}', ", success, Resources.Form.Target));
                        }

                        if (DataInternal.Count() > 0)
                        {
                            sb.AppendLine(string.Format("{0} : ", Resources.Form.Data));
                            sb.Append("{");

                            foreach(var item in DataInternal)
                            {
                                sb.AppendLine(string.Format("{0} : {1}", item.Key, item.Value));

                                if (item.Key != DataInternal.Last().Key)
                                {
                                    sb.Append(",");
                                }
                            }

                            sb.AppendLine("},");

                            sb.AppendLine(string.Format("{1}: '{0}', ", success, Resources.Form.Target));
                        }

                        sb.AppendLine("};");
                        
                        sb.AppendLine("$form.ajaxSubmit(options);");                       
                    } 
                    else if (!string.IsNullOrEmpty(OptionsInternal))
                    {
                        sb.AppendLine(string.Format("$form.ajaxSubmit({0});", OptionsInternal)); 
                    }
                    else
                    {
                        sb.AppendLine("$form.ajaxSubmit();");
                    }
                }

                if (!string.IsNullOrEmpty(function))
                {
                    sb.AppendLine(function);
                }

                if (IsReset)
                {
                    sb.AppendLine("$form.resetForm();");
                }

                if (IsClose)
                {
                    sb.AppendLine("$(this).dialog('close');");
                }                

                if (IsValidate)
                {
                    sb.AppendLine("}");
                }

                return sb.ToString();
            }
        }

        public bool IsUsingForm
        {
            get;
            protected set;
        }

        private bool IsValidate
        {
            get;
            set;
        }

        public IDialogButton Validate()
        {
            IsUsingForm = true;
            IsValidate = true;
            return this;            
        }

        IDialogButtonSubmit IDialogButton.Submit()
        {
            IsUsingForm = true;
            IsSubmit = true;
            return this;
        }

        private bool IsSubmit
        {
            get;
            set;
        }

        private bool IsReset
        {
            get; set; 
        }

        public IDialogButton Reset()
        {
            IsUsingForm = true;
            IsReset = true;
            return this;
        }

        private bool IsClose
        {
            get;
            set;
        }

        public IDialogButton Close()
        {
            IsClose = true;
            return this;
        }

        private string function
        {
            get; set; }

        public IDialogButton Function(string function)
        {
            this.function = function;
            return this;
        }

        private bool HasFormOptions { get; set; }

        private string target
        {
            get; set; 
        }

        public IDialogButtonSubmit Target(string value)
        {
            HasFormOptions = true;
            target = value;
            return this;
        }

        private string beforeSubmit
        {
            get;
            set;
        }

        public IDialogButtonSubmit BeforeSubmit(string value)
        {
            HasFormOptions = true;
            beforeSubmit = value;
            return this;
        }

        private string success { get; set; }

        public IDialogButtonSubmit Success(string value)
        {
            HasFormOptions = true;
            success = value;
            return this;
        }

        public IDialogButtonSubmit Data(object value)
        {
            return Data(new RouteValueDictionary(value));
        }

        private RouteValueDictionary DataInternal { get; set; }

        public IDialogButtonSubmit Data(IDictionary<string, object> value)
        {
            HasFormOptions = true;
            DataInternal = (value == null) ? new RouteValueDictionary() : new RouteValueDictionary(value);
            return this;
        }


        private string OptionsInternal { get; set;}

        public IDialogButtonSubmit Options(string value)
        {
            OptionsInternal = value;
            return this;
        }

    }
}
