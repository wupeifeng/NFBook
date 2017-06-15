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
    /// 分类信息操作类
    /// </summary>
    public class CategoryDAL
    {
        /// <summary>
        /// 根据条件查询分类信息列表
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>分类信息列表</returns>
        public List<Category> GetCategory(string where = null)
        {
            List<Category> list = new List<Category>();
            if (DBhelp.OpenConn())
            {
                string sqltxt = "select * from [Category] ";
                SqlDataReader dr = DBhelp.ExecReader(sqltxt);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Category cgy = new Category()
                        {
                            ID = (int)dr["ID"],
                            CategoryName = dr["CategoryName"].ToString(),
                            ParentID = (int)dr["ParentID"],
                            ImageUrl = dr["ImageUrl"].ToString(),
                            Remark = dr["Remark"].ToString(),
                            State = (int)dr["State"],
                        };
                        list.Add(cgy);
                    }
                }
                DBhelp.CloseConn();
            }
            return list;
        }
        /// <summary>
        /// 添加分类信息
        /// </summary>
        /// <param name="ctg"></param>
        /// <returns></returns>
        public int InsertCategory(Category cate)
        {
            return DBhelp.ExecQuery("insert into [Category]([CategoryName],[ParentID],[ImageUrl],[Remark],[State]) values('" + cate.CategoryName + "'," + cate.ParentID + ",'" + cate.ImageUrl + "','" + cate.Remark + "'," + cate.State + ")");
        }
        /// <summary>
        /// 更新图书类信息
        /// </summary>
        /// <param name="ctg">图书分类对象</param>
        /// <returns>更新操作结果</returns>
        public int UpdateCategory(Category ctg)
        {
            string sqltxt = "update [Category] set";

            //如果分类名称不为空则更新
            if (!string.IsNullOrEmpty(ctg.CategoryName))
            {
                sqltxt += " [CategoryName]='" + ctg.CategoryName + "',";
            }
            //如果父类型编号大于零，则更新
            if (ctg.ParentID > 0)
            {
                sqltxt += " [ParentID]='" + ctg.ParentID + "',";
            }
            //如果图片路径不为空，则更新
            if (!string.IsNullOrEmpty(ctg.ImageUrl))
            {
                sqltxt += " [ImageUrl]='" + ctg.ImageUrl + "',";
            }
            //如果说明不为空则更新
            if (!string.IsNullOrEmpty(ctg.Remark))
            {
                sqltxt += " [Remark]='" + ctg.Remark + "',";
            }
            //如果状态不为零则更新
            if (ctg.State != 0)
            {
                sqltxt += " [State]='" + ctg.State + "',";
            }

            sqltxt = sqltxt.Substring(0, sqltxt.Length - 1) + " where [ID]=" + ctg.ID;

            return DBhelp.ExecQuery(sqltxt);
        }
        /// <summary>
        /// 更加编号删除图书分类
        /// </summary>
        /// <param name="id">图书编号</param>
        /// <returns>删除操作结果</returns>
        public int DaleteCategory(string id)
        {
            return DBhelp.ExecQuery("update [Category] set [State]=1 where [ID] in (" + id + ")");
        }
    }
}
