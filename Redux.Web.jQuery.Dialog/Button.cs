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
        public string OptionsInternal { get; set; }
        public string FunctionInternal { get; set; }
        public string TargetInternal { get; set; }
        public string BeforeSubmitInternal { get; set; }
        public string SuccessInternal { get; set; }
        public RouteValueDictionary DataInternal { get; set; }

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
                return ButtonWriter.Writer(this);
            }
        }

        public bool IsUsingForm
        {
            get;
            protected set;
        }

        public bool IsValidate
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

        public bool IsSubmit
        {
            get;
            set;
        }

        public bool IsReset
        {
            get; set; 
        }

        public IDialogButton Reset()
        {
            IsUsingForm = true;
            IsReset = true;
            return this;
        }

        public bool IsClose
        {
            get;
            set;
        }

        public IDialogButton Close()
        {
            IsClose = true;
            return this;
        }

        public IDialogButton Function(string function)
        {
            FunctionInternal = function;
            return this;
        }

        public bool HasFormOptions { get; set; }

        public IDialogButtonSubmit Target(string value)
        {
            HasFormOptions = true;
            TargetInternal = value;
            return this;
        }

        public IDialogButtonSubmit BeforeSubmit(string value)
        {
            HasFormOptions = true;
            BeforeSubmitInternal = value;
            return this;
        }

        public IDialogButtonSubmit Success(string value)
        {
            HasFormOptions = true;
            SuccessInternal = value;
            return this;
        }

        public IDialogButtonSubmit Data(object value)
        {
            return Data(new RouteValueDictionary(value));
        }

        public IDialogButtonSubmit Data(IDictionary<string, object> value)
        {
            HasFormOptions = true;
            DataInternal = (value == null) ? new RouteValueDictionary() : new RouteValueDictionary(value);
            return this;
        }
       
        public IDialogButtonSubmit Options(string value)
        {
            OptionsInternal = value;
            return this;
        }
    }
}
