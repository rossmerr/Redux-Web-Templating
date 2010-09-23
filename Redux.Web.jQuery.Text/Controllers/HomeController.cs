using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redux.Web.jQuery.Flexigrid;
using Redux.Web.jQuery.SmartTextBox;
using Redux.Web.jQuery.Text.Models;
using Redux.Web.jQuery.Jeditable;

namespace Redux.Web.jQuery.Text.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Example1()
        {
            return View();        
        }

        public ActionResult Partial()
        {
            return PartialView(new TestObject());
        }

        [HttpPost]
        public ActionResult Partial(TestObject id)
        {
            return PartialView(id);
        }



        public ActionResult PartialTwo()
        {
            return PartialView(new TestObject());
        }



        [HttpPost]
        public ActionResult PartialTwo(TestObject id)
        {
            return PartialView(id);
        }

        [HttpGet]
        public string PartialThree()
        {
            return string.Empty;
        }

        public ActionResult Example2()
        {

            return View(new TestObject()
            {
                One = "test",
                Two = "two"
            });
        }


        public JsonResult Example3Json()
        {

            var obj = new List<string>()
                          {
                              "",
                              DateTime.UtcNow.ToString()
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
                                      One = "<span class='btn-edit'>Edit </span>",
                                      Two = "two"
                                  },
                              new TestObject()
                                  {
                                      One = "<span class='btn-edit'>Edit </span>",
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

        public ActionResult Combobox()
        {
            var obj = new ComboboxModel
                          {
                              ListOne = new List<SelectListItem>()
                                            {
                                                new SelectListItem() {Text = "test", Value = "1", Selected = false}
                                            },

                              ListTwo = new List<SelectListItem>()
                                            {
                                                new SelectListItem() {Text = "test1", Value = "1"},
                                                new SelectListItem() {Text = "test2", Value = "2"}
                                            }
                          };

            return View(obj);
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
