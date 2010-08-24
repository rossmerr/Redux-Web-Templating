using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Redux.Web.jQuery.SmartTextBox
{
    public class SmartTextBoxConfiguration<TModel> : ISmartTextBoxConfiguration<TModel>
    {
        public bool? AutocompleteInternal { get; protected set; }

        public int? MinSearchLengthInternal { get; protected set; }
        public int? MaxResultsInternal { get; protected set; }
        public bool? CaseSensitiveInternal { get; protected set; }
        public bool? HighlightInternal { get; protected set; }
        public bool? FullSearchInternal { get; protected set; }
        public string PlaceholderInternal { get; protected set; }
        public List<string> AutocompleteValuesInternal { get; protected set; }

        public bool? OnlyAutocompleteInternal { get; protected set; }
        public bool? UniqueValuesInternal { get; protected set; }
        public bool? HideEmptyInputsInternal { get; protected set; }
        public bool? EditOnFocusInternal { get; protected set; }
        public bool? EditOnDoubleClickInternal { get; protected set; }
        public List<int> SubmitKeysInternal { get; protected set; }
        public List<char> SubmitCharsInternal { get; protected set; }
        public string ContainerClassInternal { get; protected set; }
        public char? SeparatorInternal { get; protected set; }
        public bool? UpdateOriginalInternal { get; protected set; }
        public bool? DebugInternal { get; protected set; }

        public string Target { get; protected set; }
        
        protected RouteValueDictionary _url { get; set; }
        protected HtmlHelper<TModel> _htmlHelper { get; set; }

        public SmartTextBoxConfiguration(HtmlHelper<TModel> htmlHelper, string target)
        {
            MinSearchLengthInternal = 2;
            MaxResultsInternal = 10;

            _htmlHelper = htmlHelper;
            Target = target;
        }

        public string UrlInternal
        {
            get
            {
                if (_url != null)
                {
                    var urlHelper = new UrlHelper(_htmlHelper.ViewContext.RequestContext);
                    return urlHelper.RouteUrl(_url);
                }
                return string.Empty;
            }
        }

        public ISmartTextBoxConfiguration<TModel> Autocomplete(bool value)
        {
            AutocompleteInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> MinSearchLength(int value)
        {
            MinSearchLengthInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> MaxResults(int value)
        {
            MaxResultsInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> CaseSensitive(bool value)
        {
            CaseSensitiveInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> Highlight(bool value)
        {
            HighlightInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> FullSearch(bool value)
        {
            FullSearchInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> Placeholder(string value)
        {
            PlaceholderInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> AutocompleteValues(params string[] value)
        {
            AutocompleteValuesInternal = value.ToList();
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> AutocompleteUrl(object value)
        {
            return AutocompleteUrl(new RouteValueDictionary(value));
        }

        public ISmartTextBoxConfiguration<TModel> AutocompleteUrl(RouteValueDictionary value)
        {
            _url = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> OnlyAutocomplete(bool value)
        {
            OnlyAutocompleteInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> UniqueValues(bool value)
        {
            UniqueValuesInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> HideEmptyInputs(bool value)
        {
            HideEmptyInputsInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> EditOnFocus(bool value)
        {
            EditOnFocusInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> EditOnDoubleClick(bool value)
        {
            EditOnDoubleClickInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> SubmitKeys(params int[] value)
        {
            SubmitKeysInternal = value.ToList();
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> SubmitChars(params char[] value)
        {
            SubmitCharsInternal = value.ToList();
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> ContainerClass(string value)
        {
            ContainerClassInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> Separator(char value)
        {
            SeparatorInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> UpdateOriginal(bool value)
        {
            UpdateOriginalInternal = value;
            return this;
        }

        public ISmartTextBoxConfiguration<TModel> Debug(bool value)
        {
            DebugInternal = value;
            return this;
        }

        public override string ToString()
        {
            SmartTextBoxWriter.Writer(_htmlHelper, Target, this);
            return string.Empty;
        }
    }
}
