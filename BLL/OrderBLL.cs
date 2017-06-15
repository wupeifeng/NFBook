using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class OrderBLL
    {
        OrderDAL dal = new OrderDAL();

        public string InsertOrder(Order order, List<OrderDetail> details)
        {
            return dal.InsertOrder(order, details);
        }

        public string GetOrder(string date)
        {
            string str = dal.GetOrder(date);

            if (str != "")
            {
                int no = int.Parse(str.Substring(8)) + 1;

                if (no < 10)
                    return date + "000" + no;

                if (no < 100)
                    return date + "00" + no;

                if (no < 1000)
                    return date + "0" + no;

                return date + no;
            }
            else
            {
                return date + "0001";
            }
        }
    }
}
