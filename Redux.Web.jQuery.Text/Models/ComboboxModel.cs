using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redux.Web.jQuery.Text.Models
{
    public class ComboboxModel
    {
        [DisplayName("A List")]
        public IList<SelectListItem> ListOne { get; set; }

        [DisplayName("Second List")]
        public IList<SelectListItem> ListTwo { get; set; }
    }
}