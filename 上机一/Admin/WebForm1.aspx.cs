using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 上机一.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //WinForn11.OnBtnClick += new WinForn1.BtnClick(WinForn11_OnBtnClick);
        }
        protected void WinForn11_OnBtnClick(int id, string text)
        {
            
            //Label1.Text = "您选择的类型名称是：" + text + "<br/>";
            //Label1.Text += "您选择的类型编号是：" + id.ToString();
        }
    }
}