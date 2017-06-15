using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //分类信息
    public class Category
    {
        /// <summary>
        /// 构造：用户创建分类信息对象
        /// </summary>
        public Category() { }

        /// <summary>
        /// 构造：用于创建分类信息对象
        /// </summary>
        /// <param name="id">分类编号</param>
        /// <param name="name">分类名称</param>
        /// <param name="pid">父类型编号</param>
        /// <param name="pname">父类型名称</param>
        /// <param name="img">图片路径</param>
        /// <param name="remark">说明</param>
        /// <param name="state">状态</param>
        public Category(int id, string name, int pid, string pname, string img, string remark, int state)
        {
            this.ID = id;
            this.CategoryName = name;
            this.ParentID = pid;
            this.ParentName = pname;
            this.ImageUrl = img;
            this.Remark = remark;
            this.State = state;
        }

        /// <summary>
        /// 属性：分类编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 属性：分类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 属性：父类型编
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 属性：父类型名称
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 属性：图片路径
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 属性：说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 属性：状态
        /// </summary>
        public int State { get; set; }
    }
}
