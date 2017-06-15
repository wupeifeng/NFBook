using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    /// <summary>
    /// 分类信息操作
    /// </summary>
    public class CategoryBLL
    {
        CategoryDAL dal = new CategoryDAL();
        /// <summary>
        /// 获取所有分类信息
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategory()
        {
            return dal.GetCategory(" where [State]=0");
        }
        public Category GetCategory(int id)
        {
            return dal.GetCategory(" where ID="+id)[0];
        }
        public List<Category> GetCategory(int pid = -1, bool isTrue = true)
        {
            if (pid == -1)
                return dal.GetCategory();
            else
                return dal.GetCategory(" where ParentID=" + pid);
        }
        /// <summary>
        /// 添加图书分类
        /// </summary>
        /// <param name="ctg"></param>
        /// <returns></returns>
        public int InsertCategory(Category ctg)
        {
            return dal.InsertCategory(ctg);
        }
        /// <summary>
        /// 更新图书类信息
        /// </summary>
        /// <param name="ctg">图书分类对象</param>
        /// <returns>更新操作结果</returns>
        public int UpdateCategory(Category ctg)
        {
            return dal.UpdateCategory(ctg);
        }
        /// <summary>
        /// 更加编号删除图书分类
        /// </summary>
        /// <param name="id">图书编号</param>
        /// <returns>删除操作结果</returns>
        public int DaleteCategory(string id)
        {
            return dal.DaleteCategory(id);
        }
    }
}
