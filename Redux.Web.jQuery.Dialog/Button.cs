using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Dialog
{
    public class Button : IDialogButton
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
                    sb.AppendLine("$form.ajaxSubmit();");
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

        private bool IsSubmit
        {
            get;
            set;
        }

        public IDialogButton Submit()
        {
            IsUsingForm = true;
            IsSubmit = true;
            return this;
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

        private string _function;

        private string function
        {
            get { return _function; }
            set { _function = value; }
        }

        public IDialogButton Function(string function)
        {
            this.function = function;
            return this;
        }
    }
}
