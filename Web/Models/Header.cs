using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api = Web.Areas.Api;

namespace Web.Models
{
    public enum NavItems
    {
        Dashboard,
        Competition,
        Advertising
    }

    public class Header
    {
        public bool HideMenu { get; set; }
        public bool HideNavigation { get; set; }
        public NavItems? ActiveTab { get; set; }
    }
}