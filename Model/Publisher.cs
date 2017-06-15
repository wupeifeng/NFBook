using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /// <summary>
    /// 出版社信息
    /// </summary>
    [Serializable]
    public class Publisher
    {
        /// <summary>
        /// 构造：用于创建出版社对象
        /// </summary>
        public Publisher() { }

        /// <summary>
        /// 构造：用户创建出版社对象
        /// </summary>
        /// <param name="id">出版社编号</param>
        /// <param name="name">出版社名称</param>
        /// <param name="imageUrl">图片路径</param>
        /// <param name="webUrl">网址</param>
        /// <param name="state">状态</param>
        public Publisher(int id, string name, string imageUrl, string webUrl, int state)
        {
            this.ID = id;
            this.PublishName = name;
            this.ImageUrl = imageUrl;
            this.WebUrl = webUrl;
            this.State = state;
        }

        /// <summary>
        /// 属性：出版社编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 属性：出版社名称
        /// </summary>
        public string PublishName { get; set; }

        /// <summary>
        /// 属性：图片路径
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 属性：网址
        /// </summary>
        public string WebUrl { get; set; }

        /// <summary>
        /// 属性：状态
        /// </summary>
        public int State { get; set; }
    }
}
