using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace 上机一
{
    public partial class Default : System.Web.UI.Page
    {
        BookBLL bll = new BookBLL();
        private static int index = 1;
        private static int incount = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //lblIndex.Text = "1";
                //BindRepeater();
                Show(incount, index);
                this.btnProv.Enabled = false;
            }
        }
        
        //分页加载图书
        public void Show(int startRow, int endRow)
        {
            List<Book> list = new List<Book>();
            string categoryID = Request.QueryString["categoryID"] as string;

            if (string.IsNullOrEmpty(categoryID))
            {

                list = bll.Show(startRow, endRow);
            }
            else
            {
                list = bll.GetBook(int.Parse(categoryID));
            }
            if (endRow == 0)
            {
                endRow = 1;
            }
            lblIndex.Text = endRow + "";
            
            //list=bll.Show(startRow, endRow);
            
            rptShowData.DataSource = list;
            rptShowData.DataBind();

            int pageCount;
            int count = bll.COUNTBook();
            if (count % startRow == 0)
            {
                pageCount = count / startRow;
            }
            else
            {
                pageCount = count / startRow + 1;
            }
            this.lblTotal.Text = pageCount+"";
        }
        //BookBLL bookbll = new BookBLL();
        //protected void BindRepeater()
        //{
        //    PagedDataSource pd = new PagedDataSource();
        //    pd.DataSource = bll.GetBook();

        //    pd.AllowPaging = true;
        //    pd.PageSize = 5;
        //    lblTotal.Text = pd.PageCount + "";

        //    int pageIndex = int.Parse(lblIndex.Text) - 1;

        //    if (pageIndex < 0)
        //    {
        //        pd.CurrentPageIndex = 0;
        //        lblIndex.Text = "1";
        //    }

        //    if (pageIndex > pd.PageCount - 1)
        //    {
        //        pd.CurrentPageIndex = pd.PageCount;
        //        lblIndex.Text = pd.PageCount + "";
        //    }

        //    rptShowData.DataSource = pd;
        //    rptShowData.DataBind();
        //}

        protected void btnProv_Click(object sender, EventArgs e)
        {
            //int index = int.Parse(lblIndex.Text);
            //lblIndex.Text = (--index) + "";
            //BindRepeater();
            this.btnNext.Enabled = true;
            int index = int.Parse(lblIndex.Text);
            if (index > 1)
            {
                if (index == 1 + 1)
                {
                    this.btnProv.Enabled = false;
                }
                lblIndex.Text = (--index) + "";
                Show(incount, index);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            this.btnProv.Enabled = true;
            int index = int.Parse(lblIndex.Text);
            int inMax = int.Parse(lblTotal.Text);
            if (index < inMax)
            {
                if (index == inMax - 1)
                {
                    this.btnNext.Enabled = false;
                }
                lblIndex.Text = (++index) + "";
                Show(incount, index);
            }

            //int index = int.Parse(lblIndex.Text);
            //lblIndex.Text = (++index) + "";
            //BindRepeater();
        }

        protected void rptShowData_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            //添加购物车
            //1、保存商品的编号：CommandArgument
            //2、取出编号：e.CommandArgument
            //3、根据编号获取商品信息
            Model.Book book = new BLL.BookBLL().GetBook(e.CommandArgument as string);
            //4、添加购物车：如果不存在则直接添加，否则增加数量
            for (int i = 0; i < ((List<Model.Book>)Session["ShopCar"]).Count; i++)
            {
                //判断是否增加数量
                if (((List<Model.Book>)Session["ShopCar"])[i].ID == e.CommandArgument.ToString())
                {
                    ((List<Model.Book>)Session["ShopCar"])[i].Count += 1;
                    return;
                }
            }

            ((List<Model.Book>)Session["ShopCar"]).Add(book);
            ((HyperLink)Master.FindControl("HyperLink2")).Text = "购物车[" + ((List<Model.Book>)Session["ShopCar"]).Count + "]|";

            //直接添加
            //BLL.BookBLL bookbll = new BLL.BookBLL();
            //Model.Book book = bookbll.GetBook(e.CommandArgument.ToString());
            //((List<Model.Book>)Session["ShopCar"]).Add(book);
            //((HyperLink)Master.FindControl("hyShopCar")).Text = "购物车[" + ((List<Model.Book>)Session["ShopCar"]).Count + "]|";
        }
    }
}