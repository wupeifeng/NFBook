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
    public partial class Supplement : System.Web.UI.Page
    {
        UserInfoBLL bll = new UserInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            //string date=(Convert.ToInt32(TextBox2.Text) - dt.Year).ToString();
            UserInfo uf = new UserInfo()
            {
                LoginName = ((Model.UserInfo)Session["user"]).LoginName as string,
                UsertName = this.TextBox1.Text,
                Gender =RadioButton1.Checked?"男":"女",
                Birthday = int.Parse(this.TextBox2.Text),
            };
            int sql = bll.UpdateUserInfo(uf);
            if (sql > 0)
            {
                Label1.Text = "保存成功！";
            }
            else
            {
                Label1.Text = "保存失败！";
            }
        }
    }
}