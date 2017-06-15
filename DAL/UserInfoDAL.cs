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
    public class UserInfoDAL
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="uif"></param>
        /// <returns></returns>
        public int InsertUserInfo(UserInfo uif)
        {

            string sqltxt = "insert into UserInfo([LoginName],[Password],[UsertName],[State],[Email]) values(@LoginName,@Password,@UsertName,@State,@Email)";
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@LoginName",uif.LoginName),
                new SqlParameter("@Password",uif.Password),
                new SqlParameter("@UsertName",uif.UsertName),
                new SqlParameter("@State",uif.State),
                new SqlParameter("@Email",uif.Email),
            };
            int count = DBhelp.ExecQuery(sqltxt, CommandType.Text, p);

            return count;
        }
        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public List<UserInfo> SelectUserInfo(string where=null)
        {
            List<UserInfo> list = new List<UserInfo>();
            if (DBhelp.OpenConn())
            {
                string sqltxt = "select * from UserInfo "+where;
                
                SqlDataReader dr = DBhelp.ExecReader(sqltxt, CommandType.Text,null);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        UserInfo uif = new UserInfo();
                        uif.ID = (int)dr["ID"];
                        uif.LoginName = dr["LoginName"].ToString();
                        uif.Password = dr["Password"].ToString();
                        uif.UsertName = dr["UsertName"].ToString();
                        uif.State = (int)dr["State"];
                        uif.Email = dr["Email"].ToString();
                        uif.Question = dr["Question"].ToString();
                        uif.Answer = dr["Answer"].ToString();
                        uif.LastLogDate = DateTime.Now;
                        uif.Phone = dr["Phone"].ToString();
                        uif.QQMSN = dr["QQMSN"].ToString();
                        uif.Gender = dr["Gender"].ToString();

                        uif.Birthday = (int)dr["Birthday"];
                        uif.Address = dr["Address"].ToString();
                        list.Add(uif);
                    }
                }

                DBhelp.CloseConn();
            }
            return list;
        }
        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="uif">会员信息</param>
        /// <returns>更新操作结果</returns>
        public int UpdateUserInfo(UserInfo uif)
        {
            string sqltxt = "update [UserInfo] set";

            //如果会员密码不为空则更新
            if (!string.IsNullOrEmpty(uif.Password))
            {
                sqltxt += " [Password]='" + uif.Password + "',";
            }
            //如果用户姓名不为空则更新
            if (!string.IsNullOrEmpty(uif.UsertName))
            {
                sqltxt += "[UsertName]='" + uif.UsertName + "',";
            }
            //如果用户电子邮箱不为空则更新
            if (!string.IsNullOrEmpty(uif.Email))
            {
                sqltxt += "[Email]='" + uif.Email + "',";
            }
            //如果用户密保问题不为空则更新
            if (!string.IsNullOrEmpty(uif.Question))
            {
                sqltxt += "[Question]='" + uif.Question + "',";
            }
            //如果用户密保问题答案不为空则更新
            if (!string.IsNullOrEmpty(uif.Answer))
            {
                sqltxt += "[Answer]='" + uif.Answer + "',";
            }
            //如果用户最后登录时间改变则更新
            if (uif.LastLogDate.Year != 1)
            {
                sqltxt += "[LastLogDate]='" + uif.LastLogDate + "',";
            }
            //如果用户电话号码不为空则更新
            if (!string.IsNullOrEmpty(uif.Phone))
            {
                sqltxt += "[Phone]='" + uif.Phone + "',";
            }
            //如果用户QQ或微信不为空则更新
            if (!string.IsNullOrEmpty(uif.QQMSN))
            {
                sqltxt += "[QQMSN]='" + uif.QQMSN + "',";
            }
            //如果用户性别不为空则更新
            if (!string.IsNullOrEmpty(uif.Gender))
            {
                sqltxt += "[Gender]='" + uif.Gender + "',";
            }
            //如果用户出生日期改变则更新
            if (uif.Birthday>= 18)
            {
                sqltxt += "[Birthday]='" + uif.Birthday + "',";
            }
            //如果用户通讯地址不为空则更新
            if (!string.IsNullOrEmpty(uif.Address))
            {
                sqltxt += "[Address]='" + uif.Address + "',";
            }


            //合成SQL语句
            sqltxt = sqltxt.Substring(0, sqltxt.Length - 1) + " where [LoginName]='" + uif.LoginName + "'";

            //执行更新操作并返回操作结果
            int count = DBhelp.ExecQuery(sqltxt);
            return count;
        }
        
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="uif"></param>
        /// <returns></returns>
        //public bool UpdateUserInfo(UserInfo uif)
        //{
        //    bool boo = false;
        //    string sqltxt = "update UserInfo set Password=@Password where LoginName=@LoginName";
        //    SqlParameter[] pa = new SqlParameter[]
        //    {
        //        new SqlParameter("@Password",uif.Password),
        //        new SqlParameter("@LoginName",uif.LoginName),
        //    };
        //    int count = DBhelp.ExecQuery(sqltxt, CommandType.Text, pa);
        //    if (count > 0)
        //    {
        //        boo = true;
        //    }
        //    return boo;
        //}
    }
}
