using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 上机一
{
    public partial class MyFilmMsater : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                HyperLink1.Text = ((Model.UserInfo)Session["user"]).LoginName as string;
                HyperLink1.NavigateUrl = "~/Supplement.aspx";
            }
            else
            {
                HyperLink1.Text = "登录";
            }
            if (Session["ShopCar"] != null)
            {
                this.HyperLink2.Text = "购物车[" + ((List<Model.Book>)Session["ShopCar"]).Count + "]|"; 
            }
        }
        public HyperLink HyperLinkload
        {
            get {return HyperLink1;}
            set { HyperLink1 = value; }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           // Session["user"] = null;
           // HyperLink1.Text = "登录";
            Session.RemoveAll();
            Response.Redirect("Login.aspx", true);
            Response.Write("<script>alert('您已安全退出系统！')window.top.location='Login.aspx';</script>");
        }
    }
}