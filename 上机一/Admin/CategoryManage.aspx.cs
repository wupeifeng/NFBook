using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace 上机一.Admin
{
    public partial class CategoryManage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindCategory();
        }
        protected void BindCategory()
        {
            lstShowData.DataSource =new BLL.CategoryBLL().GetCategory();
            lstShowData.DataBind();
        }

        protected void lstShowData_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            lstShowData.EditIndex = -1;
            BindCategory();
        }

        protected void lstShowData_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lstShowData.EditIndex = e.NewEditIndex;
            BindCategory();
        }

        protected void lstShowData_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            Model.Category ctg = new Model.Category();
            ctg.ID = (int)e.Keys["ID"];
            ctg.CategoryName = e.NewValues[0].ToString();

            if (ctg.ID != -1)
            {
                int count = new BLL.CategoryBLL().UpdateCategory(ctg);
                if (count > 0)
                {
                    lblMsg.Text = "修改成功！";
                }
                else
                {
                    lblMsg.Text = "修改失败！";
                }
            }
            else
            {
                int count = new BLL.CategoryBLL().InsertCategory(ctg);
                if (count > 0)
                {
                    lblMsg.Text = "添加成功！";
                }
                else
                {
                    lblMsg.Text = "添加失败！";
                }
            }
            lstShowData.EditIndex = -1;
            BindCategory();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //在ListView中添加空行
            List<Model.Category> cates = new List<Model.Category>();
            cates = new BLL.CategoryBLL().GetCategory();

            cates.Insert(0, new Model.Category() { ID = -1 });

            lstShowData.DataSource = cates;
            lstShowData.EditIndex = 0;
            lstShowData.DataBind();           
        }

        protected void lstShowData_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

            string id = "'" + e.Keys["ID"].ToString() + "'";
            int count =new BLL.CategoryBLL().DaleteCategory(id);
            if (count > 0)
            {
                lblMsg.Text = "成功删除" + count + "本书";

            }
            else
            {
                lblMsg.Text = "删除失败！";
            }
            BindCategory();
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lstShowData.Items.Count; i++)
            {
                ((CheckBox)lstShowData.Items[i].FindControl("chkSelect")).Checked = ((CheckBox)sender).Checked;
            }
        }
    }
}