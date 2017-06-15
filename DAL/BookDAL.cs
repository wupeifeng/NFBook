using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{

    public class BookDAL
    {
        
        /// <summary>
        /// 根据条件分页图书
        /// 后台分页
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <returns></returns>
        public List<Book> Show(int startRow, int endRow)
        {
            List<Book> list = new List<Book>();
            if (DBhelp.OpenConn())
            {
                string Sqltxt = "select * from (select ROW_NUMBER() over (Order by ID) as RowID, * from vw_Book) as b where b.RowID between (@startRow*(@endRow-1)+1) and (@startRow*@endRow)";
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@startRow",startRow),
                    new SqlParameter("@endRow",endRow),
                };
                SqlDataReader dr = DBhelp.ExecReader(Sqltxt,CommandType.Text,pa);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Book bk = new Book()
                        {
                            ID = dr["ID"].ToString(),
                            Title = dr["Title"].ToString(),
                            Author = dr["Author"].ToString(),
                            CategoryID = (int)dr["CategoryID"],
                            CategoryName = dr["CategoryName"].ToString(),
                            PublisherID = (int)dr["PublisherID"],
                            PublishDate = (DateTime)dr["PublishDate"],
                            ISBN = dr["ISBN"].ToString(),
                            WordsCount = (int)dr["WordsCount"],
                            Price = (decimal)dr["Price"],
                            Content = dr["ContentDesc"].ToString(),
                            AuthorDesc = dr["AuthorDesc"].ToString(),
                            EditorComment = dr["EditorComment"].ToString(),
                            Clicks = (int)dr["Clicks"],
                            State = (int)dr["State"],
                            Count=1,
                            PublisherName = dr["PublishName"].ToString(),
                        };
                        list.Add(bk);
                    }
                }
                DBhelp.CloseConn();
            }
            return list;
        }
        //计算图书数量
        public int COUNTBook()
        {
            int count = 0;
            if (DBhelp.OpenConn())
            {
                string sqltxt = "select COUNT(*) as 'count' from Book";
                SqlDataReader dr = DBhelp.ExecReader(sqltxt);
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        count = (int)dr["count"];
                    }
                }
                DBhelp.CloseConn();
            }
            return count;
        }
        /// <summary>
        /// 根据条件查询图书
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Book> GetBook(string where = null)
        {
            List<Book> list = new List<Book>();
            if (DBhelp.OpenConn())
            {
                string Sqltxt = "select * from vw_Book " + where;
                SqlDataReader dr = DBhelp.ExecReader(Sqltxt);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Book bk = new Book()
                        {
                            ID = dr["ID"].ToString(),
                            Title = dr["Title"].ToString(),
                            Author = dr["Author"].ToString(),
                            CategoryID = (int)dr["CategoryID"],
                            CategoryName = dr["CategoryName"].ToString(),
                            PublisherID = (int)dr["PublisherID"],
                            PublishDate = (DateTime)dr["PublishDate"],
                            ISBN = dr["ISBN"].ToString(),
                            WordsCount = (int)dr["WordsCount"],
                            Price = (decimal)dr["Price"],
                            Content = dr["ContentDesc"].ToString(),
                            AuthorDesc = dr["AuthorDesc"].ToString(),
                            EditorComment = dr["EditorComment"].ToString(),
                            Clicks = (int)dr["Clicks"],
                            State = (int)dr["State"],
                            Count=1,
                            PublisherName = dr["PublishName"].ToString(),
                        };
                        list.Add(bk);
                    }
                }
                DBhelp.CloseConn();
            }
            return list;
        }
        /// <summary>
        /// 添加图书
        /// </summary>
        /// <param name="book"></param>
        /// <returns>返回受影响行数</returns>
        public int InsertBook(Book book)
        {
            string sqltxt = "insert into Book values(@ID,@Title,@Author,@PublisherID,@CategoryID,@PublishDate,@ISBN,@WordsCount,@Price,@ContentDesc,@AuthorDesc,@EditorComment,@Clicks,@State)";
            SqlParameter[] pa = new SqlParameter[]
            {
                new SqlParameter("@ID",book.ID),
                new SqlParameter("@Title",book.Title),
                new SqlParameter("@Author",book.Author),
                new SqlParameter("@PublisherID",book.PublisherID),
                new SqlParameter("@CategoryID",book.CategoryID),
                new SqlParameter("@PublishDate",book.PublishDate),
                new SqlParameter("@ISBN",book.ISBN),
                new SqlParameter("@WordsCount",book.WordsCount),
                new SqlParameter("@Price",book.Price),
                new SqlParameter("@ContentDesc",book.Content),
                new SqlParameter("@AuthorDesc",book.AuthorDesc),
                new SqlParameter("@EditorComment",book.EditorComment),
                new SqlParameter("@Clicks",book.Clicks),
                new SqlParameter("@State",book.State),
            };
            return DBhelp.ExecQuery(sqltxt, CommandType.Text, pa);
        }
        /// <summary>
        /// 更新图书
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int UpdateBook(Book book)
        {
            string sqltxt = @"update Book set Title=@Title,Author=@Author,PublisherID=@PublisherID,CategoryID=@CategoryID,PublishDate=@PublishDate,ISBN=@ISBN,WordsCount=@WordsCount,Price=@Price,ContentDesc=@ContentDesc,AuthorDesc=@AuthorDesc,EditorComment=@EditorComment,Clicks=@Clicks,State=@State
                            where ID=@ID";
            SqlParameter[] pa = new SqlParameter[]
            {
                new SqlParameter("@ID",book.ID),
                new SqlParameter("@Title",book.Title),
                new SqlParameter("@Author",book.Author),
                new SqlParameter("@PublisherID",book.PublisherID),
                new SqlParameter("@CategoryID",book.CategoryID),
                new SqlParameter("@PublishDate",book.PublishDate),
                new SqlParameter("@ISBN",book.ISBN),
                new SqlParameter("@WordsCount",book.WordsCount),
                new SqlParameter("@Price",book.Price),
                new SqlParameter("@ContentDesc",book.Content),
                new SqlParameter("@AuthorDesc",book.AuthorDesc),
                new SqlParameter("@EditorComment",book.EditorComment),
                new SqlParameter("@Clicks",book.Clicks),
                new SqlParameter("@State",book.State),
            };
            return DBhelp.ExecQuery(sqltxt, CommandType.Text, pa);
        }
        /// <summary>
        /// 删除图书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteBook(string id)
        {
            string sqltxt = "update Book set [State]=1 where [ID] in ("+id+")";
            //SqlParameter[] pa = new SqlParameter[]
            //{
            //    new SqlParameter("@ID",id),
            //};
            return DBhelp.ExecQuery(sqltxt);
        }
    }
}
