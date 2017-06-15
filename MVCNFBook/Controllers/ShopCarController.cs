using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MVCNFBook.Controllers
{
    public class ShopCarController : Controller
    {

        [HttpGet]
        public ActionResult ShopCarList()
        {
            List<Book> list = (List<Model.Book>)Session["ShopCar"];
            
            //计算总价
            decimal total = 0m;
            
            //遍历购物车里的所有商品
            for (int i = 0; i < ((List<Model.Book>)Session["ShopCar"]).Count; i++)
            {
                
                total += ((List<Model.Book>)Session["ShopCar"])[i].Price * ((List<Model.Book>)Session["ShopCar"])[i].Count;
                
            }
            ViewBag.PriceCount = string.Format("{0:C}", total);
            return View(list);
        }

    }
}
