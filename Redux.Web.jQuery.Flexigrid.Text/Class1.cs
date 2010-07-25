using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Redux.Web.jQuery.Flexigrid.Html;
using Redux.Web.Templating;

namespace Redux.Web.jQuery.Flexigrid.Text
{
    public class Class1
    {
        static void Main(string[] args)
        {
            var htmlHelper = new HtmlHelper<TestObject>(null, null);

            var coll = new List<TestObject>();

            FlexigridExtension.FlexigridFor(htmlHelper, coll,
                                            columns =>
                                                {
                                                    columns.AddColumn(p => p.One, true, 100,
                                                                                  Align.Left);
                                                    columns.AddColumn(p => p.Two, true, 100,
                                                                                  Align.Left);
                                                },
                                            buttons =>
                                                {
                                                    buttons.AddButton("test", "test", "action");
                                                    buttons.AddSeparator();
                                                    buttons.AddButton("test2", "test2", "action2");
                                                },
                                            searchFields =>
                                                {
                                                    searchFields.AddField(p => p.One, "one");
                                                },
                                            sort => sort.One,
                                            SortOrder.Ascending,
                                            true,
                                            true,
                                            "grid",
                                            true,
                                            0,
                                            true,
                                            100,
                                            100);
        }
    }
}
