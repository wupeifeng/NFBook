using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using Webdiyer.WebControls.Mvc;

namespace MVCNFBook.Controllers
{
    public class BooksController : Controller
    {

        int pageCount;      //总页数
        int bookcount = 10;      //显示数据
        
        List<Book> list = new List<Book>();

        List<Book> book = new List<Book>();
        //分页图书
        public ActionResult Default(int indexs=1)
        {

            List<Book> Getbooks = new BLL.BookBLL().GetBook();
            PagedList<Book> mPage = Getbooks.AsQueryable().ToPagedList(indexs, 5);
            return View(mPage);

            //if ((id == "0") || (id == null))
            //{
            //    int count = new BLL.BookBLL().GetBook().Count;

            //    if (count % 10 == 0)
            //    {
            //        count = count / 10;
            //    }
            //    else
            //    {
            //        count = count / 10 + 1;
            //    }
            //    if (ind == 0)
            //    {
            //        ind = 1;
            //    }
            //    if (ind == count+1)
            //    {
            //        ind = count;
            //    }
            //    list = new BLL.BookBLL().Show(10, ind);
            //    foreach (var item in list)
            //    {
            //        item.Index = ind;
            //    }
            //    ViewBag.Id ="0";
            //    ViewBag.PagenIndex = ind;
            //    ViewBag.count = count;
            //}
            //else
            //{
            //    book = new BLL.BookBLL().GetBook();
            //    book = book.Where(b => b.CategoryID == int.Parse(id)).ToList();
            //    if (book.Count % 10 == 0)
            //    {
            //        pageCount = book.Count / bookcount;
            //    }
            //    else
            //    {
            //        pageCount = book.Count / bookcount + 1;
            //    }
            //    if (ind == 0)
            //    {
            //        ind = 1;
            //    }
            //    if (ind == book.Count+1)
            //    {
            //        ind = book.Count;
            //    }

            //    ViewBag.Id = id;
            //    ViewBag.PagenIndex = ind;
            //    ViewBag.count = pageCount;
            //    ShowInfo(ind);
            //}
            
        }
        public void ShowInfo(int ind)
        {
            list = book.Skip((ind - 1) * bookcount).Take(bookcount).ToList();
            foreach (var item in list)
            {
                item.Index = ind;
            }
        }

        [HttpPost]
        public ActionResult Default(FormCollection forms)
        {
            if(Session["UserInfo"]==null)
                return RedirectToAction("Login", "UserInfo");

            string ID = forms["BookID"];
            int Index = Convert.ToInt32(forms["Index"]);

            Model.Book book = new BLL.BookBLL().GetBook(ID);
            //4、添加购物车：如果不存在则直接添加，否则增加数量
            for (int i = 0; i < ((List<Model.Book>)Session["ShopCar"]).Count; i++)
            {
                //判断是否增加数量
                if (((List<Model.Book>)Session["ShopCar"])[i].ID == ID)
                {
                    ((List<Model.Book>)Session["ShopCar"])[i].Count += 1;
                    return RedirectToAction("Default", new { id = 0, ind =Index});
                }
            }

            ((List<Model.Book>)Session["ShopCar"]).Add(book);
            return RedirectToAction("Default", new { id = 0, ind = Index });
        }

        //图书详细信息
        public ActionResult BookDetail(string id)
        {
            string where = "where [ID]='" + id + "'";
            List<Book> list =new BLL.BookBLL().GetBooks(where);
            return View(list);
        }
    }
}
