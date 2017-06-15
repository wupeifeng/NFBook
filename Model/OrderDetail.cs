using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class OrderDetail
    {
        /// <summary>
        /// 构造：用户创建订单明细对象
        /// </summary>
        public OrderDetail() { }

        /// <summary>
        /// 构造：根据指定参数创建订单明细对象
        /// </summary>
        /// <param name="id">订单明细编号</param>
        /// <param name="orderID">订单编号</param>
        /// <param name="bookID">图书编号</param>
        /// <param name="count">购买数量</param>
        /// <param name="price">价格</param>
        /// <param name="state">状态</param>
        public OrderDetail(string id, string orderID, string bookID, int count, decimal price, int state)
        {
            this.ID = id;
            this.OrderID = orderID;
            this.BookID = bookID;
            this.Count = count;
            this.Price = price;
            this.State = state;
        }

        /// <summary>
        /// 属性：订单明细编号
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 属性：订单编号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 属性：图书编号
        /// </summary>
        public string BookID { get; set; }

        /// <summary>
        /// 属性：购买数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 属性：价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 属性：状态
        /// </summary>
        public int State { get; set; }
    }
}
