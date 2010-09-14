using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Dialog
{
    public class DialogConfiguration : IDialogConfiguration
    {
        public bool? DisabledInternal { get; protected set; }
        public bool? AutoOpenInternal { get; protected set; }
        public Action<IDialogButtonConfiguration> ButtonsInternal { get; protected set; }
        public bool? CloseOnEscapeInternal { get; protected set; }
        public string CloseTextInternal { get; protected set; }
        public string DialogClassInternal { get; protected set; }
        public bool? DraggableInternal { get; protected set; }
        public int? HeightInternal { get; protected set; }
        public bool? HideInternal { get; protected set; }
        public int? MaxHeightInternal { get; protected set; }
        public int? MaxWidthInternal { get; protected set; }
        public int? MinHeightInternal { get; protected set; }
        public int? MinWidthInternal { get; protected set; }
        public bool? ModalInternal { get; protected set; }
        public string PositionInternal { get; protected set; }
        public bool? ResizableInternal { get; protected set; }
        public string ShowInternal { get; protected set; }
        public bool? StackInternal { get; protected set; }
        public string TitleInternal { get; protected set; }
        public int? WidthInternal { get; protected set; }
        public int? ZIndexInternal { get; protected set; }

        public string OpenInternal { get; protected set; }
        public string CloseInternal { get; protected set; }
        protected RouteValueDictionary _openUrl { get; set; }
        protected RouteValueDictionary _closeUrl { get; set; }

        protected RouteValueDictionary _url { get; set; }
        public string Target { get; protected set; }
        protected Postback _postback { get; set; }
        protected HtmlHelper _htmlHelper { get; set; }

        public DialogConfiguration(HtmlHelper htmlHelper, string target)
        {
            _htmlHelper = htmlHelper;
            Target = target;
        }

        public DialogConfiguration(HtmlHelper htmlHelper, string target, RouteValueDictionary url)
        {
            _url = url;
            _htmlHelper = htmlHelper;
            Target = target;
        }

        public DialogConfiguration(HtmlHelper htmlHelper, string target, RouteValueDictionary url, Postback postback)
        {
            _postback = postback;
            _url = url;
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

        public string OpenUrlInternal
        {
            get
            {
                if (_openUrl != null)
                {
                    var urlHelper = new UrlHelper(_htmlHelper.ViewContext.RequestContext);
                    return urlHelper.RouteUrl(_openUrl);
                }
                return string.Empty;
            }
        }

        public string CloseUrlInternal
        {
            get
            {
                if (_closeUrl != null)
                {
                    var urlHelper = new UrlHelper(_htmlHelper.ViewContext.RequestContext);
                    return urlHelper.RouteUrl(_closeUrl);
                }
                return string.Empty;
            }
        }

        public IDialogConfiguration Disabled(bool value)
        {
            DisabledInternal = value;
            return this;
        }

        public IDialogConfiguration AutoOpen(bool value)
        {
            AutoOpenInternal = value;
            return this;
        }

        public IDialogConfiguration Buttons(Action<IDialogButtonConfiguration> buttons)
        {
            ButtonsInternal = buttons;
            return this;
        }

        public IDialogConfiguration CloseOnEscape(bool value)
        {
            CloseOnEscapeInternal = value;
            return this;
        }

        public IDialogConfiguration CloseText(string value)
        {
            CloseTextInternal = value;
            return this;
        }

        public IDialogConfiguration DialogClass(string value)
        {
            DialogClassInternal = value;
            return this;
        }

        public IDialogConfiguration Draggable(bool value)
        {
            DraggableInternal = value;
            return this;
        }

        public IDialogConfiguration Height(int value)
        {
            HeightInternal = value;
            return this;
        }

        public IDialogConfiguration Hide(bool value)
        {
            HideInternal = value;
            return this;
        }

        public IDialogConfiguration MaxHeight(int value)
        {
            MaxHeightInternal = value;
            return this;
        }

        public IDialogConfiguration MaxWidth(int value)
        {
            MaxWidthInternal = value;
            return this;
        }

        public IDialogConfiguration MinHeight(int value)
        {
            MinHeightInternal = value;
            return this;
        }

        public IDialogConfiguration MinWidth(int value)
        {
            MinWidthInternal = value;
            return this;
        }

        public IDialogConfiguration Modal(bool value)
        {
            ModalInternal = value;
            return this;
        }

        public IDialogConfiguration Position(string value)
        {
            PositionInternal = value;
            return this;
        }

        public IDialogConfiguration Resizable(bool value)
        {
            ResizableInternal = value;
            return this;
        }

        public IDialogConfiguration Show(string value)
        {
            ShowInternal = value;
            return this;
        }

        public IDialogConfiguration Stack(bool value)
        {
            StackInternal = value;
            return this;
        }

        public IDialogConfiguration Title(string value)
        {
            TitleInternal = value;
            return this;
        }

        public IDialogConfiguration Width(int value)
        {
            WidthInternal = value;
            return this;
        }

        public IDialogConfiguration ZIndex(int value)
        {
            ZIndexInternal = value;
            return this;
        }

        public IDialogConfiguration OnOpen(string value)
        {
            OpenInternal = value;
            return this;
        }

        public IDialogConfiguration OnOpen(object routeValues)
        {
            return OnOpen(new RouteValueDictionary(routeValues));
        }

        public IDialogConfiguration OnOpen(RouteValueDictionary routeValues)
        {
            _openUrl = routeValues;
            return this;
        }

        public IDialogConfiguration OnClose(string value)
        {
            CloseInternal = value;
            return this;
        }

        public IDialogConfiguration OnClose(object routeValues)
        {
            return OnClose(new RouteValueDictionary(routeValues));
        }

        public IDialogConfiguration OnClose(RouteValueDictionary routeValues)
        {
            _closeUrl = routeValues;
            return this;
        }

        public override string ToString()
        {
            DialogWriter.Writer(_htmlHelper, Target, this);
            return string.Empty;
        }
    }
}
