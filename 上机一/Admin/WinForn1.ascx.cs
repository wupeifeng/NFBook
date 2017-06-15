using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;


namespace 上机一.Admin
{
    public partial class WinForn1 : System.Web.UI.UserControl
    {

        //public delegate void BtnClick(int id, string text);
        //public event BtnClick OnBtnClick;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMenu();
        }
        protected void LoadMenu()
        {
            List<Category> list = new BLL.CategoryBLL().GetCategory();

            foreach (Category item in list)
            {
                HyperLink link = new HyperLink();
                link.Text = item.CategoryName;
                link.NavigateUrl = ("~/Default.aspx?CategoryID=" + item.ID.ToString());

                this.Controls.Add(link);

                Label lbl = new Label();
                lbl.Text = "<br/>";
                this.Controls.Add(lbl);
            }
        }
    }
}