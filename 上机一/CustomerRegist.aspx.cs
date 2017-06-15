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
    public partial class CustomerRegist : System.Web.UI.Page
    {

        UserInfoBLL bll = new UserInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

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
            List<UserInfo> list = new List<UserInfo>();
            list = bll.SelectUserInfo(this.txtID.Text);
            if (list.Count > 0)
            {
                this.lblTxt.Text = "您输入的帐号已经存在！"+"</br>"+"请重新选择";
                return;
            }
            else
            {
                UserInfo uif = new UserInfo()
                {
                    LoginName = this.txtID.Text,
                    Password = GetMD5(this.txtPwd.Text),
                    UsertName = this.txtID.Text,
                    State=0,
                    Email = this.txtEamil.Text,
                };
                int count = bll.InsertUserInfo(uif);
                //判断结果
                switch (count)
                {
                    case -2:
                        this.lblTxt.Text = "数据库链接异常！请联系你的管理员";
                        break;
                    case -1:
                        this.lblTxt.Text = "数据操作异常，请检查你的数据！";
                        break;
                    case 0:
                        this.lblTxt.Text = "没有添加任何数据";
                        break;
                    default:
                        this.lblTxt.Text = "注册成功！您可以" + "<a href='Default.aspx'>开始购物</a>" + "或" + "<a href='Login.aspx'>完善个人资料</a>";
                        break;
                }
            }
        }
    }
}