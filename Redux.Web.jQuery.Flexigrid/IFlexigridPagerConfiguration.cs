using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redux.Web.jQuery.Flexigrid
{
    public interface IFlexigridPagerConfiguration<TModel> : IFlexigridConfiguration<TModel>
    {
        IFlexigridPagerConfiguration<TModel> UseRp(bool rp);
        IFlexigridPagerConfiguration<TModel> Rp(int rp);
    }
}
