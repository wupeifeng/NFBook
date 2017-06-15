using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using Model;
using BLL;

namespace 上机一
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        UserInfoBLL bll = new UserInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        //MD5加密方法
        
        private string GetMD5(string pwd)
        {
            byte[] result = Encoding.Default.GetBytes(pwd);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string encryptResult = BitConverter.ToString(output).Replace("-", "");
            return encryptResult;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string name = this.txtName.Text;
            string pwd = GetMD5(this.txtPwd.Text);
            Model.UserInfo uif = bll.Login(name);

            if (uif != null)
            {
                if (uif.Password == pwd)
                {
                    //保存用户信息
                    Master.Session["user"] = uif;
                    //创建购物车
                    Session["ShopCar"] = new List<Model.Book>();

                    Response.Redirect("Default.aspx", true);
                    // Master.HyperLinkload.Text = item.LoginName;

                    Master.HyperLinkload.NavigateUrl = "~/Supplement.aspx";
                }
                this.lblText.Text = "密码错误";
            }
            else
            {
                this.lblText.Text = "帐号不存在";
            }

        }   
    }
}