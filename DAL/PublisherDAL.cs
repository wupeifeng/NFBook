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
    /// <summary>
    /// 出版社信息操作类
    /// </summary>
    public class PublisherDAL
    {
        /// <summary>
        /// 根据条件查询出版社信息
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>出版社信息列表</returns>
        public List<Publisher> GetPublisher(string where = null)
        {
            List<Publisher> list = new List<Publisher>();
            if (DBhelp.OpenConn())
            {
                string sqltxt = "select * from [Publisher] ";
                SqlDataReader dr = DBhelp.ExecReader(sqltxt);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Publisher lbs = new Publisher()
                        {
                            ID = (int)dr["ID"],
                            PublishName = dr["PublishName"].ToString(),
                            ImageUrl = dr["ImageUrl"].ToString(),
                            WebUrl = dr["WebUrl"].ToString(),
                            State = (int)dr["State"],
                        };
                        list.Add(lbs);
                    }
                }
                DBhelp.CloseConn();
            }
            return list;
        }
        /// <summary>
        /// 新增出版社
        /// </summary>
        /// <param name="pbs"></param>
        /// <returns></returns>
        public int InsertPublisher(Publisher pbs)
        {
            string sqltxt = "insert into [Publisher](PublishName,ImageUrl,WebUrl,State) values('" + pbs.PublishName + "','" + pbs.ImageUrl + "','" + pbs.WebUrl + "','" + pbs.State + "')";
            return DBhelp.ExecQuery(sqltxt);
        }
        /// <summary>
        /// 更新出版社信息
        /// </summary>
        /// <param name="pbs"></param>
        /// <returns></returns>
        public int UpdatePublisher(Publisher pbs)
        {
            string sqltxt = "update Publisher set";
            //如果出版社名称不为空则更新
            if (!string.IsNullOrEmpty(pbs.PublishName))
            {
                sqltxt += " [PublishName]='" + pbs.PublishName + "',";
            }
            //如果图片路径不为空，则更新
            if (!string.IsNullOrEmpty(pbs.ImageUrl))
            {
                sqltxt += " [ImageUrl]='" + pbs.ImageUrl + "',";
            }
            //如果网址不为空，则更新
            if (!string.IsNullOrEmpty(pbs.WebUrl))
            {
                sqltxt += " [WebUrl]='" + pbs.WebUrl + "',";
            }
            //如果状态不为零，则更新
            if (pbs.State != 0)
            {
                sqltxt += " [State]=" + pbs.State + ",";
            }
            sqltxt = sqltxt.Substring(0, sqltxt.Length - 1) + " where ID=" + pbs.ID;

            return DBhelp.ExecQuery(sqltxt);
        }
        /// <summary>
        /// 删除出版社信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeletePublisher(string id)
        {
            string sqltxt = "update Publisher set [State]=1 where [ID] in (" + id + ")";
            return DBhelp.ExecQuery(sqltxt);
        }
    }
}
