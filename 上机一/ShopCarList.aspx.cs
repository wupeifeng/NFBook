using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 上机一
{
    public partial class ShopCarList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Default.aspx");

            if (!IsPostBack)
                BindRepeater();
        }

        protected void BindRepeater()
        {
            //Repeater控件的数据源使用Session
            rptShowData.DataSource = (List<Model.Book>)Session["ShopCar"];
            rptShowData.DataBind();

            MoneyShow();
            foreach (RepeaterItem item in rptShowData.Items)
            {
                TextBox count = item.FindControl("txtCount") as TextBox;
                Label price = item.FindControl("txtPrice") as Label;
                Label price2 = item.FindControl("Label1") as Label;
                decimal price3 = Convert.ToDecimal(price2.Text);
                price.Text = Convert.ToString(int.Parse(count.Text) * price3);
            }
        }
        protected void MoneyShow()
        {
            //计算总价
            decimal total = 0m;
            //遍历购物车里的所有商品
            for (int i = 0; i < ((List<Model.Book>)Session["ShopCar"]).Count; i++)
            {
               
                total += ((List<Model.Book>)Session["ShopCar"])[i].Price * ((List<Model.Book>)Session["ShopCar"])[i].Count;
            }
            lblTotal.Text = string.Format("{0:C}", total);
        }

        protected void rptShowData_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int count = int.Parse(((TextBox)e.Item.FindControl("txtCount")).Text);

            if (e.CommandName == "Add")
                count += 1;

            if (e.CommandName == "Cut")
                count -= 1;

            if (count < 1)
                count = 1;

            ((TextBox)e.Item.FindControl("txtCount")).Text = count.ToString();

            for (int i = 0; i < ((List<Model.Book>)Session["ShopCar"]).Count; i++)
            {
                if (((List<Model.Book>)Session["ShopCar"])[i].ID == e.CommandArgument.ToString())
                {
                    if (e.CommandName == "Delete")
                        ((List<Model.Book>)Session["ShopCar"]).RemoveAt(i);
                    else
                        ((List<Model.Book>)Session["ShopCar"])[i].Count = count;
                }
            }
            BindRepeater();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (((List<Model.Book>)Session["ShopCar"]).Count > 0)
            {
                Model.Order order = new Model.Order();
                order.ID = Guid.NewGuid().ToString();

                string date = DateTime.Now.Year + "";

                if (DateTime.Now.Month < 10)
                {
                    date += "0" + DateTime.Now.Month;
                }
                else
                {
                    date += DateTime.Now.Month + "";
                }
                if (DateTime.Now.Day < 10)
                {
                    date += "0" + DateTime.Now.Day;
                }
                else
                {
                    date += DateTime.Now.Day + "";
                }

                order.OrderNo = new BLL.OrderBLL().GetOrder(date);

                order.OrderAddress = ((Model.UserInfo)Session["user"]).Address;
                order.OrderPhone = ((Model.UserInfo)Session["user"]).Phone;
                order.CustomerID = ((Model.UserInfo)Session["user"]).ID.ToString();
                order.TotalPrice = decimal.Parse(this.lblTotal.Text.Substring(1));
                order.OrderDate = DateTime.Now;
                order.State = 0;

                List<Model.OrderDetail> datail = new List<Model.OrderDetail>();
                for (int i = 0; i < ((List<Model.Book>)Session["ShopCar"]).Count; i++)
                {
                    Model.OrderDetail od = new Model.OrderDetail();
                    od.ID = Guid.NewGuid().ToString();
                    od.BookID = ((List<Model.Book>)Session["ShopCar"])[i].ID;
                    od.Count = ((List<Model.Book>)Session["ShopCar"])[i].Count;
                    od.OrderID = order.ID;
                    od.Price = ((List<Model.Book>)Session["ShopCar"])[i].Price;
                    od.State = 0;

                    datail.Add(od);
                }

                this.lblMsg.Text = new BLL.OrderBLL().InsertOrder(order, datail);

                Session["ShopCar"] = new List<Model.Book>();
                ((HyperLink)Master.FindControl("HyperLink2")).Text = "购物车[0]";

                BindRepeater();
            }
            else
            {
                this.lblMsg.Text = "没有购买任何商品！";
            }
        }
    }
}