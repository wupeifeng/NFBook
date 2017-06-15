using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace 上机一.Admin
{
    public partial class BookList : System.Web.UI.Page
    {
        BookBLL bll = new BookBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindList();
        }
        protected void BindList()
        {
            lstDataList.DataSource = bll.GetBook();
            lstDataList.DataBind();
        }
        //删除
        protected void lstDataList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            string id ="'"+ e.Keys["ID"].ToString()+"'";
            int count = 0;
            count = bll.DeleteBook(id);
            if (count > 0)
            {
                lblMsg.Text = "成功删除" + count + "本书";
            }
            else
            {
                lblMsg.Text = "删除失败！";
            }
            BindList();
        }
        //批量删除
        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            string id = "";
            int count = 0;
            for (int i = 0; i < lstDataList.Items.Count; i++)
            {
                if (((CheckBox)lstDataList.Items[i].FindControl("chkSelect")).Checked)
                    id += "'"+lstDataList.DataKeys[i].Value + "',";
            }
            id = id.Substring(0, id.Length - 1);
            
            count = bll.DeleteBook(id);
            if (count > 0)
            {
                lblMsg.Text = "成功删除" + count + "本书";
            }
            else
            {
                lblMsg.Text = "删除失败！";
            }
            BindList();
        }
        //全选
        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lstDataList.Items.Count; i++)
            {
                ((CheckBox)lstDataList.Items[i].FindControl("chkSelect")).Checked = ((CheckBox)sender).Checked;
            }
        }

        //添加按钮
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //执行添加图书操作
            //图书没有编号
            //特殊值表示添加状态
            Response.Redirect("BookData.aspx?id=-1");
        }
        
    }
}