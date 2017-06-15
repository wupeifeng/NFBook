using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class BookBLL
    {
        BookDAL dal = new BookDAL();
        /// <summary>
        /// 获取全部图书
        /// </summary>
        /// <returns></returns>
        public List<Model.Book> GetBook()
        {
            return dal.GetBook(" where [State]=0");
        }
        public List<Book> GetBook(int categoryID)
        {
            return dal.GetBook(" where CategoryID=" + categoryID);
        }
        //根据条件获取图书信息
        public List<Book> GetBooks(string where)
        {
            return dal.GetBook(where);
        }
        //后台分页
        public List<Book> Show(int startRow, int endRow)
        {
            return dal.Show(startRow, endRow);
        }
        //根据ID获取图书信息
        public Model.Book GetBook(string id)
        {
            return new DAL.BookDAL().GetBook(" where [ID]='" + id + "'")[0];
        }
        //添加图书
        public int InsertBook(Book book)
        {
            return dal.InsertBook(book);
        }
        //更新图书
        public int UpdateBook(Book book)
        {
            return dal.UpdateBook(book);
        }
        //删除图书
        public int DeleteBook(string id)
        {
            return dal.DeleteBook(id);
        }
        //计算图书数量
        public int COUNTBook()
        {
            return dal.COUNTBook();
        }
    }
}
