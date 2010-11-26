using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Flexigrid
{
    public class FlexigridConfiguration<TModel> : IFlexigridConfiguration<TModel>, IFlexigridPagerConfiguration<TModel>
    {
        public Action<IDataTableConfiguration<TModel>> Columns { get; protected set; }

        public Action<IFlexigridToolbarConfiguration> ButtonsInternal { get; protected set; }
        public Action<ISearchConfiguration<TModel>> SearchItemsInternal { get; protected set; }
        protected RouteValueDictionary _url { get; set; }
        public DataType? DataTypeInternal { get; protected set; }
        public Expression<Func<TModel, object>> SortInternal { get; protected set; }
        public SortOrder? OrderInternal { get; protected set; }
        public bool? UsePagerInternal { get; protected set; }
        public bool? ShowTableToggleBtnInternal { get; protected set; }
        public int WidthInternal { get; protected set; }
        public int HeightInternal { get; protected set; }
        public bool? SingleSelectInternal { get; protected set; }
        public bool? UseRpInternal { get; protected set; }
        public int? RpInternal { get; protected set; }
        public string TitleInternal { get; protected set;  }
        public int? PageInteral { get; protected set; }
        public bool? ShowToggleBtnInternal { get; protected set; }
        public string Target { get; protected set; }
        public string OnDragColInternal { get; protected set; }
        public string OnToggleColInternal { get; protected set; }
        public string OnChangeSortInternal { get; protected set; }
        public string OnSuccessInternal { get; protected set; }
        public string OnErrorInternal { get; protected set; }
        public string OnSubmitInteral { get; protected set; }
        public string OnReloadInternal { get; protected set; }
        public string OnLoadedInternal { get; protected set; }

        protected HtmlHelper _htmlHelper { get; set; }



        public FlexigridConfiguration(HtmlHelper htmlHelper, string target, Action<IDataTableConfiguration<TModel>> columns)
        {
            _htmlHelper = htmlHelper;
            Columns = columns;
            Target = target;
        }

        public FlexigridConfiguration(Action<IDataTableConfiguration<TModel>> columns)
        {
            Columns = columns;
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

        public IFlexigridConfiguration<TModel> Buttons(Action<IFlexigridToolbarConfiguration> buttons)
        {
            ButtonsInternal = buttons;
            return this;
        }

        public IFlexigridConfiguration<TModel> SearchItems(Action<ISearchConfiguration<TModel>> searchItems)
        {
            SearchItemsInternal = searchItems;
            return this;
        }

        public IFlexigridConfiguration<TModel> Url(object url)
        {
            return this.Url(new RouteValueDictionary(url),Templating.DataType.Json);
        }

        public IFlexigridConfiguration<TModel> Url(object url, DataType dataType)
        {
            return this.Url(new RouteValueDictionary(url), dataType);
        }

        public IFlexigridConfiguration<TModel> Url(RouteValueDictionary url, DataType dataType)
        {
            _url = url;
            DataTypeInternal = dataType;
            return this;
        }

        public IFlexigridConfiguration<TModel> Sort(Expression<Func<TModel, object>> sort, SortOrder order)
        {
            SortInternal = sort;
            OrderInternal = order;
            return this;
        }

        public IFlexigridPagerConfiguration<TModel> UsePager()
        {
            UsePagerInternal = true;
            return this;
        }

        public IFlexigridConfiguration<TModel> ShowTableToggleBtn()
        {
            ShowTableToggleBtnInternal = true;
            return this;
        }

        public IFlexigridConfiguration<TModel> Width(int width)
        {
            WidthInternal = width;
            return this;
        }

        public IFlexigridConfiguration<TModel> Height(int height)
        {
            HeightInternal = height;
            return this;
        }

        public IFlexigridConfiguration<TModel> SingleSelect(bool singleSelect)
        {
            SingleSelectInternal = singleSelect;
            return this;
        }

        public IFlexigridConfiguration<TModel> Title(string title)
        {
            TitleInternal = title;
            return this;
        }

        public IFlexigridConfiguration<TModel> DataType(DataType dataType)
        {
            DataTypeInternal = dataType;
            return this;
        }

        public IFlexigridConfiguration<TModel> Page(int value)
        {
            PageInteral = value;
            return this;
        }

        public IFlexigridConfiguration<TModel> ShowToggleBtn(bool value)
        {
            ShowToggleBtnInternal = value;
            return this;
        }

        public IFlexigridConfiguration<TModel> OnDragCol(string title)
        {
            OnDragColInternal = title;
            return this;
                 
        }

        public IFlexigridConfiguration<TModel> OnToggleCol(string title)
        {
            OnToggleColInternal = title;
            return this;
        }

        public IFlexigridConfiguration<TModel> OnChangeSort(string title)
        {
            OnChangeSortInternal = title;
            return this;
        }

        public IFlexigridConfiguration<TModel> OnSuccess(string title)
        {
            OnSuccessInternal = title;
            return this;
        }

        public IFlexigridConfiguration<TModel> OnError(string title)
        {
            OnErrorInternal = title;
            return this;
        }

        public IFlexigridConfiguration<TModel> OnSubmit(string title)
        {
            OnSubmitInteral = title;
            return this;
        }

        public IFlexigridConfiguration<TModel> OnLoaded(string title)
        {
            OnLoadedInternal = title;
            return this;
        }

        public IFlexigridConfiguration<TModel> OnReloaded(string title)
        {
            OnReloadInternal = title;
            return this;
        }


        public IFlexigridPagerConfiguration<TModel> UseRp(bool rp)
        {
            UseRpInternal = rp;
            return this;
        }

        public IFlexigridPagerConfiguration<TModel> Rp(int rp)
        {
            RpInternal = rp;
            return this;
        }

        public override string ToString()
        {
            FlexigridWriter.Writer(_htmlHelper, Target, this);
            return string.Empty;
        }
    }
}
