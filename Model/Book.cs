using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Book
    {
        /// <summary>
        /// 构造：用于创建图书对象
        /// </summary>
        public Book() { }

        /// <summary>
        /// 构造：用于创建图书对象
        /// </summary>
        /// <param name="id">图书编号</param>
        /// <param name="title">图书名称</param>
        /// <param name="author">作者</param>
        /// <param name="categoryID">类型编号</param>
        /// <param name="categoryName">类型名称</param>
        /// <param name="publisherID">出版社编号</param>
        /// <param name="publicherName">出版社名称</param>
        /// <param name="publishDate">出版日期</param>
        /// <param name="price">价格</param>
        /// <param name="count">购买数量</param>
        /// <param name="content">内容简介</param>
        /// <param name="cover">封面路径</param>
        /// <param name="isbn">书号</param>
        /// <param name="wordsCount">总字数</param>
        /// <param name="authorDesc">作者简介</param>
        /// <param name="editorComment">编辑推介</param>
        /// <param name="clicks">点击次数</param>
        /// <param name="state">状态</param>
        public Book(string id, string title, string author, int categoryID, string categoryName, int publisherID, string publicherName, DateTime publishDate, decimal price, int count, string content, string cover, string isbn, int wordsCount, string authorDesc, string editorComment, int clicks, int state,int index)
        {
            this.ID = id;
            this.Title = title;
            this.Author = author;
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;
            this.PublisherID = publisherID;
            this.PublisherName = PublisherName;
            this.PublishDate = publishDate;
            this.Price = price;
            this.Count = count;
            this.Cover = cover;
            this.Content = content;
            this.ISBN = isbn;
            this.WordsCount = wordsCount;
            this.AuthorDesc = authorDesc;
            this.EditorComment = editorComment;
            this.Clicks = clicks;
            this.State = state;
            this.Index = index;
        }




        public string ID { get; set; }                      //图书编号
        public string Title { get; set; }                   //图书名称
        public string Author { get; set; }                  //作者
        public int CategoryID { get; set; }                 //类型编号
        public string CategoryName { get; set; }            //类型名称
        public int PublisherID { get; set; }                //出版社编号
        public string PublisherName { get; set; }           //出版社名称
        public DateTime PublishDate { get; set; }           //出版日期
        public decimal Price { get; set; }                  //价格
        public int Count { get; set; }                      //购买数量
        public string Content { get; set; }                 //内容简介
        public string Cover { get; set; }                   //反面路径
        public string ISBN { get; set; }                    //书号
        public int WordsCount { get; set; }                 //总字数
        public string AuthorDesc { get; set; }              //作者简介
        public string EditorComment { get; set; }           //编辑推介
        public int Clicks { get; set; }                     //点击次数
        public int State { get; set; }                      //状态
        public int Index { get; set; }                      //当前页数
    }
}
