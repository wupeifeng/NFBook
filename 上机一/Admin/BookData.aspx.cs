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
    public partial class BookData : System.Web.UI.Page
    {
        BookBLL bookbll = new BookBLL();
        CategoryBLL cgybll = new CategoryBLL();
        PublisherBLL pbsbll = new PublisherBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategory();
                BindPublisher();

                string id = Request.QueryString["id"];

                if (id != "-1")
                    ShowData(id);
                else
                {
                    txtPrice.Text = "0";
                    txtPublishDate.Text = DateTime.Now.ToShortDateString();
                }
            }
        }
        //获取分类
        protected void BindCategory()
        {
            dropCategory.DataSource =cgybll.GetCategory();
            dropCategory.DataTextField = "CategoryName";
            dropCategory.DataValueField = "ID";
            dropCategory.DataBind();

            dropCategory.Items.Insert(0, new ListItem("请选择类型", "-1"));
        }

        //获取出版社
        protected void BindPublisher()
        {
            dropPublisher.DataSource =pbsbll.GetPublisher();
            dropPublisher.DataTextField = "PublishName";
            dropPublisher.DataValueField = "ID";
            dropPublisher.DataBind();

            dropPublisher.Items.Insert(0, new ListItem("请选择出版社", "-1"));
        }
        //根据ID查询图书信息
        protected void ShowData(string id)
        {
            Book book = bookbll.GetBook(id);

            if (book != null)
            {
                txtTitle.Text = book.Title;
                txtAuthor.Text = book.Author;
                txtPrice.Text = book.Price.ToString();
                txtPublishDate.Text = book.PublishDate.ToShortDateString();
                txtContent.Text = book.Content;
                txtAuthorDesc.Text = book.AuthorDesc;
                txtEditorComment.Text = book.EditorComment;
                imgCover.ImageUrl = "~/Image/BookCover/" + book.ISBN + ".jpg";
                dropCategory.Text = book.CategoryID.ToString();
                dropPublisher.Text = book.PublisherID.ToString();
                txtISBN.Text = book.ISBN;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            Model.Book book =GetBook();

            if (id == "-1")
            {
                if (string.IsNullOrEmpty(imgCover.ImageUrl))//未上传封面
                    UploadImage();

                int count = bookbll.InsertBook(book);
                if (count > 0)
                {
                    lblMsg.Text = "成功添加" + count + "本书";
                }
                else
                {
                    lblMsg.Text = "添加失败";
                }
            }
            else
            {
                int count = bookbll.UpdateBook(book);
                if (count > 0)
                {
                    lblMsg.Text = "成功更新" + count + "本书";
                }
                else
                {
                    lblMsg.Text = "更新失败";
                }
            }
                
        }
        protected Model.Book GetBook()
        {
            Book book = new Book();

            string id = Request.QueryString["id"];
            //用户执行更新操作
            if (id != "-1")
            {
                book.ID = id;

            }
            //用户执行添加操作
            else
            {
                //可能已经有ID，也可能没有
                id = ViewState["ID"] as string;

                if (id == null)
                {
                    book.ID = Guid.NewGuid().ToString();
                    ViewState["ID"] = book.ID;
                }
                else//用户上传了封面
                {
                    book.ID = id;
                }
            }

            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.ISBN = txtISBN.Text;
            book.Price = decimal.Parse(txtPrice.Text);
            book.CategoryID = int.Parse(dropCategory.SelectedValue);
            book.PublisherID = int.Parse(dropPublisher.SelectedValue);
            book.PublishDate = DateTime.Parse(txtPublishDate.Text);
            book.Content = txtContent.Text;
            book.AuthorDesc = txtAuthorDesc.Text;
            book.EditorComment = txtEditorComment.Text;
            book.Clicks = 0;
            book.State = 0;
            book.WordsCount = 0;

            return book;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadImage();
        }
        private void UploadImage()
        {
            string file = FileUpload1.FileName;

            //确保用户选择了文件
            if (!string.IsNullOrEmpty(file))
            {
                string type = file.Substring(file.LastIndexOf(".")).ToUpper();

                if ((type == ".JPG") || (type == ".BMP") || (type == ".PNG"))
                {
                    string path = Server.MapPath("~/Image/BookCover/0000000000.jpg");
                    path = path.Substring(0, path.LastIndexOf("\\") + 1);

                    //创建新GUID作为封面名称
                    string name = Guid.NewGuid().ToString();
                    ViewState["ID"] = name;

                    path = path + name + type;
                    Response.Write(path);

                    FileUpload1.SaveAs(path);
                    imgCover.ImageUrl = "~/Image/BookCover/" + name + type;
                }
            }
        }
    }
}