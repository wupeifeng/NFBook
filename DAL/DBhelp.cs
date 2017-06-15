using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace DAL
{
    public class DBhelp
    {
        public static string str = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        //数据库连接对象
        private static SqlConnection conn = null;

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns>是否打开成功</returns>
        public static bool OpenConn()
        {
            //if (conn == null)
                conn = new SqlConnection(str);

            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return true;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void CloseConn()
        {
            try
            {
                conn.Close();
                conn.Dispose();
            }
            catch
            {
                conn.Dispose();
            }
        }

        /// <summary>
        /// 根据命令填充数据表
        /// </summary>
        /// <param name="sqlQuery">所要实行的SQL语句或存储过程名称</param>
        /// <param name="type">命令的类型，默认为SQL语句</param>
        /// <param name="parms">参数集合，默认为无参</param>
        /// <returns>填充的结果</returns>
        public static DataTable FillTable(string sqlQuery, CommandType type = CommandType.Text, SqlParameter[] parms = null)
        {
            //创建数据库链接对象
            using (SqlConnection cn = new SqlConnection(str))
            {
                //创建数据适配器对象并设置相关属性
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, cn);
                da.SelectCommand.CommandType = type;
                
                //添加参数
                if (parms != null)
                {
                    da.SelectCommand.Parameters.AddRange(parms);
                }

                try
                {
                    //填充数据表
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    return null;
                }
                finally
                {
                    //销毁对象
                    dt.Dispose();
                    da.Dispose();
                }
            }
        }
        /// <summary>
        /// 根据命令读取数据库信息
        /// </summary>
        /// <param name="sqlQuery">所要执行的SQL语句或存储过程</param>
        /// <param name="type">命令的类型，默认为SQL语句</param>
        /// <param name="parms">参数集合，默认为无参</param>
        /// <returns>数据库读取对象</returns>
        public static SqlDataReader ExecReader(string sqlQuery, CommandType type = CommandType.Text, SqlParameter[] parms = null)
        {
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.CommandType = type;

            if (parms != null)
            {
                foreach (var item in parms)
                {
                    cmd.Parameters.Add(item);
                }
                //cm.Parameters.AddRange(parms);
            }

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 返回受影响的行数，在此完成所有Insert、Update、Delete类型的操作
        /// </summary>
        /// <param name="sqlQuery">要执行的SQL语句或者存储过程</param>
        /// <param name="type">命令的类型，默认为SQL语句</param>
        /// <param name="parms">参数集合，默认是无参</param>
        /// <returns>受影响的行数
        ///                 -2：表明数据库连接异常
        ///               
        public static int ExecQuery(string sqlQuery, CommandType type = CommandType.Text, SqlParameter[] parms = null)
        {
            //创建数据库连接对象
            using (SqlConnection cn = new SqlConnection(str))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, cn);
                cmd.CommandType = type;

                //设置命令参数
                if (parms != null)
                {
                    cmd.Parameters.AddRange(parms);
                }

                try
                {
                    //打开链接
                    cn.Open();
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        return -1;
                    }
                }
                catch (Exception)
                {

                    return -2;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }
        /// <summary>
        /// 返回首行首列的值，在此完成验证查询和聚合查询
        /// </summary>
        /// <param name="sqlQuery">要执行的SQL语句或存储过程名称</param>
        /// <param name="type">命令的类型，默认为SQL语句</param>
        /// <param name="parms">参数集合，默认为无参</param>
        /// <returns>首行首列的值</returns>
        public static object ExecScalar(string sqlQuery, CommandType type = CommandType.Text, SqlParameter[] parms = null)
        {
            //创建连接对象
            using (SqlConnection cn = new SqlConnection(str))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand(sqlQuery, cn);
                cmd.CommandType = type;

                //设置命令参数
                if (parms != null)
                    cmd.Parameters.AddRange(parms);

                try
                {
                    //打开连接并执行查询
                    cn.Open();
                    return cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    cmd.Dispose();
                }
            }
        }
    }
}
