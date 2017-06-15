using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class OrderDAL
    {
        //查询最后一个流水号
        public string GetOrder(string date)
        {
            string sqltxt = "select top 1 OrderNo from [Order] where OrderNo link '%" + date + "%' order by OrderNo Desc";
            DataTable dt = DBhelp.FillTable(sqltxt);

            if ((dt != null) && (dt.Rows.Count > 0))
            {
                return dt.Rows[0]["OrderNo"] as string;
            }

            return "";
        }

        public string InsertOrder(Order order, List<OrderDetail> datail)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString))
            {
                //打开连接
                conn.Open();
                //ADO.NET创建事务
                SqlTransaction tran = conn.BeginTransaction();
                //Command对象执行添加操作
                SqlCommand cmd = new SqlCommand();

                //向Order表添加数据，使用的对象是Order
                //添加Order表
                string sqltxt = @"insert into [Order]([ID],[OrderNo],[OrderDate],[TotalPrice],[OrderAddress],[OrderPhone],[CustomerID],[State]) 
                               values('"+order.ID+"','"+order.OrderNo+"','"+order.OrderDate+"','"+order.TotalPrice+"','"+order.OrderAddress+"','"+order.OrderPhone+"','"+order.CustomerID+"','"+order.State+"')";
                
                //设置Command相关属性
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandText = sqltxt;

                //执行操作
                try
                {
                    cmd.ExecuteNonQuery();

                    //获取刚添加成功的订单编号（orderID）
                    //循环操作，依次向OrderDetail表添加数据，使用的对象是detail
                    for (int i = 0; i < datail.Count; i++)
                    {
                        sqltxt = @"insert into [OrderDetail]([ID],[OrderID],[BookID],[Count],[Price],[State]) 
                                values('"+datail[i].ID+"','"+datail[i].OrderID+"','"+datail[i].BookID+"','"+datail[i].Count+"','"+datail[i].Price+"','"+datail[i].State+"')";
                        
                        cmd.CommandText = sqltxt;
                        cmd.ExecuteNonQuery();
                    }
                    //提交事务（ADO.NET事务默认回滚）
                    tran.Commit();

                    return "订单添加成功";
                }
                catch (Exception ex)
                {

                    tran.Rollback();
                    return ex.Message;
                }
            }
        }
    }
}
