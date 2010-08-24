using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redux.Web.jQuery.Flexigrid;
using Redux.Web.jQuery.SmartTextBox;
using Redux.Web.jQuery.Text.Models;
using Redux.Web.jQuery.Flexigrid.Html;
using Redux.Web.jQuery.Jeditable;

namespace Redux.Web.jQuery.Text.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Example1()
        {
            var obj = new List<TestObject>()
                          {
                              new TestObject()
                                  {
                                      One = "test",
                                      Two = "two"
                                  },
                              new TestObject()
                                  {
                                      One = "test",
                                      Two = "two"
                                  }
                          };

            return View(obj);        
        }

        public ActionResult Example2()
        {
            var obj = new List<TestObject>()
                          {
                              new TestObject()
                                  {
                                      One = "test",
                                      Two = "two"
                                  },
                              new TestObject()
                                  {
                                      One = "test",
                                      Two = "two"
                                  }
                          };

            return View(obj);
        }


        public JsonResult Example3Json()
        {

            var obj = new List<string>()
                          {
                              "test",
                              "test23"
                          };


            return this.SmartTextBoxView(obj);
        }

        public ActionResult Example3()
        {
            return View(new TestObject()
                            {
                                One = string.Empty,
                                Two = "two"
                            });
        }

        public ActionResult Example4()
        {
            var obj = new List<TestObject>()
                          {
                              new TestObject()
                                  {
                                      One = "test",
                                      Two = "two"
                                  },
                              new TestObject()
                                  {
                                      One = "test",
                                      Two = "two"
                                  }
                          };

            return View(obj);
        }

        [HttpPost]
        public JsonResult Example4(FlexigridViewModel flexigridViewModel)
        {
            var obj = new List<TestObject>()
                          {
                              new TestObject()
                                  {
                                      One = "test1",
                                      Two = "two1"
                                  },
                              new TestObject()
                                  {
                                      One = "test2",
                                      Two = "two3"
                                  }
                          };

          
            return this.FlexigridView(obj, 1, 2, columns =>
                                                     {
                                                         columns.AddColumn(p => p.One).Editable("edit").IsPrimary(true);
                                                         columns.AddColumn(p => p.Two);
                                                     });
        }

        [HttpPost]
        public string EditCell(JeditableCell cell)
        {

            return cell.ToString();
        }

        public ActionResult Index()
        {


           return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
