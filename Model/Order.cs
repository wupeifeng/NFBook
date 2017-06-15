using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Order
    {
        /// <summary>
        /// 构造：创建订单对象
        /// </summary>
        public Order() { }

        /// <summary>
        /// 构造：根据参数创建订单
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <param name="orderNo">订单流水号</param>
        /// <param name="customerID">客户编号</param>
        /// <param name="orderDate">订购日期</param>
        /// <param name="totalPrice">总价格</param>
        /// <param name="address">送货地址</param>
        /// <param name="phone">联系人电话</param>
        /// <param name="state">状态</param>
        public Order(string id, string orderNo, string customerID, DateTime orderDate, decimal totalPrice, string address, string phone, int state)
        {
            this.ID = id;
            this.OrderNo = orderNo;
            this.CustomerID = customerID;
            this.OrderDate = orderDate;
            this.TotalPrice = totalPrice;
            this.OrderAddress = address;
            this.OrderPhone = phone;
            this.State = state;
        }

        /// <summary>
        /// 属性：订单编号
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 属性：订单流水号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 属性：客户编号
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 属性：订购日期
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 属性：总价格
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 属性：送货地址
        /// </summary>
        public string OrderAddress { get; set; }

        /// <summary>
        /// 属性：联系人电话
        /// </summary>
        public string OrderPhone { get; set; }

        /// <summary>
        /// 属性：状态
        /// </summary>
        public int State { get; set; }
    }
}
