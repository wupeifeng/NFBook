using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace MVCNFBook.Controllers
{
    public class NavController : Controller
    {
        //返回部分试图
        public PartialViewResult Menu(string category = null)
        {
            CategoryBLL catbll = new CategoryBLL();

            ViewBag.SelectedCategory = category;

            return PartialView(catbll.GetCategory());
        }

    }
}
