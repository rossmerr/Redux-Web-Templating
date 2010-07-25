using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Redux.Web.jQuery.Flexigrid
{
    public class FlexigridResult<TModel> : JsonResult
    {
        public FlexigridResult<TModel> Sort(Expression<Func<TModel, object>> sort)
        {

            return this;
        }
    }
}
