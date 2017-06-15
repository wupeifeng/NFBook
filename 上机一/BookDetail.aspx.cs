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
    public partial class BookDetail : System.Web.UI.Page
    {
        BookBLL bll = new BookBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ShowData();
        }
        protected void ShowData()
        {
            string id = Request.QueryString["ID"];
            string where = "where [ID]='" + id + "'";
            List<Book>list=bll.GetBooks(where);

            foreach (Book item in list)
            {
                lblTitle.Text = item.Title;
                lblAuthor.Text = item.Author;
                lblPrice.Text = string.Format("{0:C}", item.Price);
                lblCategoryName.Text = item.CategoryName;
                lblPublisherName.Text = item.PublisherName;
                lblPublishDate.Text = string.Format("{0:D}", item.PublishDate);
                lblContent.Text = item.Content;
                lblAuthorDesc.Text = item.AuthorDesc;
                lblEditorComment.Text = item.EditorComment;
                imgCover.ImageUrl = "~/Image/BookCover/" + item.ISBN + ".jpg";
            }
        }
    }
}