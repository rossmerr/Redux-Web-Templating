using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Redux.Web.jQuery.SmartTextBox
{
    public interface ISmartTextBoxConfiguration<TModel>
    {
        ISmartTextBoxConfiguration<TModel> Autocomplete(bool value);

        ISmartTextBoxConfiguration<TModel> MinSearchLength(int value);
        ISmartTextBoxConfiguration<TModel> MaxResults(int value);
        ISmartTextBoxConfiguration<TModel> CaseSensitive(bool value);
        ISmartTextBoxConfiguration<TModel> Highlight(bool value);
        ISmartTextBoxConfiguration<TModel> FullSearch(bool value);
        ISmartTextBoxConfiguration<TModel> Placeholder(string value);
        ISmartTextBoxConfiguration<TModel> AutocompleteValues(params string[] value);

        ISmartTextBoxConfiguration<TModel> AutocompleteUrl(object value);
        ISmartTextBoxConfiguration<TModel> AutocompleteUrl(RouteValueDictionary value);

        ISmartTextBoxConfiguration<TModel> OnlyAutocomplete(bool value);
        ISmartTextBoxConfiguration<TModel> UniqueValues(bool value);
        ISmartTextBoxConfiguration<TModel> HideEmptyInputs(bool value);
        ISmartTextBoxConfiguration<TModel> EditOnFocus(bool value);
        ISmartTextBoxConfiguration<TModel> EditOnDoubleClick(bool value);
        ISmartTextBoxConfiguration<TModel> SubmitKeys(params int[] value);
        ISmartTextBoxConfiguration<TModel> SubmitChars(params char[] value);
        ISmartTextBoxConfiguration<TModel> ContainerClass(string value);
        ISmartTextBoxConfiguration<TModel> Separator(char value);
        ISmartTextBoxConfiguration<TModel> UpdateOriginal(bool value);
        ISmartTextBoxConfiguration<TModel> Debug(bool value);
    }
}
