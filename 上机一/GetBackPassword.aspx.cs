using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Security.Cryptography;
using System.Text;

namespace 上机一
{
    public partial class GetBackPassword : System.Web.UI.Page
    {

        UserInfoBLL bll = new UserInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private static List<UserInfo> list;
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            list = bll.SelectUserInfo(this.txtUid.Text);
            if (list.Count== 0)
            {
                this.lblText.Text = "帐号不存在！";
                this.lblSecurityName.Visible = false;
            }
            else
            {

                this.lblSecurityName.Visible = true;
                this.lblSecurityName.Text = "密保问题 ： " + list[0].Question + "？";
                this.lblText.Text = "";
            }
        }
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
            if (this.txtSecretAnswer.Text == list[0].Answer)
            {
                UserInfo uf = new UserInfo()
                {
                    LoginName = ((Model.UserInfo)Session["user"]).LoginName as string,
                    Password = GetMD5("123"),
                };
                int sql = bll.UpdateUserInfo(uf);
                if (sql > 0)
                {

                    this.lblText.Text = "密码重置成功！" + "</br>" + "为了您的帐号安全，请立即使用初始密码" + "<a href='Login.aspx'>重新登录</a>" + "系统" + "</br>" + "并尽快修改密码！";
                }

            }
            else
            {
                this.lblText.Text = "答案错误";
            }
        }
    }
}