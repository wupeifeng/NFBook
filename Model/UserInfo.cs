using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class UserInfo
    {
        /// <summary>
        /// 构造：用于创建用户对象
        /// </summary>
        public UserInfo() { }

        /// <summary>
        /// 构造：根据给定的数据创建用户对象
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="loginName">用户登录名</param>
        /// <param name="password">用户登录密码</param>
        /// <param name="customerName">用户姓名</param>
        /// <param name="state">用户状态</param>
        /// <param name="email">电子邮箱地址</param>
        /// <param name="question">密保问题</param>
        /// <param name="answer">密保答案</param>
        /// <param name="lastLogDate">最后一次登录时间</param>
        /// <param name="phone">联系电话</param>
        /// <param name="qqmsn">QQ或MSN</param>
        /// <param name="gender">性别</param>
        /// <param name="birthday">年龄</param>
        /// <param name="address">通信地址</param>
        public UserInfo(int id, string loginName, string password, string UsertName, int state, string email, string question, string answer, DateTime lastLogDate, string phone, string qqmsn, string gender, int birthday, string address) 
        {
            this.ID = id;
            this.LoginName = loginName;
            this.Password = password;
            this.UsertName = UsertName;
            this.State = state;
            this.Email = email;
            this.Question = question;
            this.Answer = answer;
            this.LastLogDate = lastLogDate;
            this.Phone = phone;
            this.QQMSN = qqmsn;
            this.Gender = gender;
            this.Birthday = birthday;
            this.Address = address;
        }

        /// <summary>
        /// 属性：用户编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 属性：用户登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 属性：用户登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 属性：用户姓名
        /// </summary>
        public string UsertName { get; set; }

        /// <summary>
        /// 属性：用户状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 属性：登录信息
        /// </summary>
        public string LoginInfo { get; set; }

        /// <summary>
        /// 属性：电子邮箱地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 属性：密保问题
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// 属性：密保答案
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// 属性：最后一次登录时间
        /// </summary>
        public DateTime LastLogDate { get; set; }

        /// <summary>
        /// 属性：联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 属性：QQ号码或MSN帐号
        /// </summary>
        public string QQMSN { get; set; }

        /// <summary>
        /// 属性：性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 属性：年龄
        /// </summary>
        public int Birthday { get; set; }

        /// <summary>
        /// 属性：通信地址
        /// </summary>
        public string Address { get; set; }
    }
}
