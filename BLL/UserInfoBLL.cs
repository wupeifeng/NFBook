using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class UserInfoBLL
    {
        UserInfoDAL dal = new UserInfoDAL();
        //添加用户
        public int InsertUserInfo(UserInfo uif)
        {
            return dal.InsertUserInfo(uif);
        }
        //查询所有用户信息
        public List<UserInfo> SelectUserInfo()
        {
            return dal.SelectUserInfo();
        }
        //根据用户编号查询用户信息
        public List<UserInfo> SelectUserInfo(string LoginName)
        {
            return dal.SelectUserInfo(" where LoginName='" + LoginName + "'");
        }
        //根据用户帐号和密码登录
        public Model.UserInfo Login(string uid)
        {
            return dal.SelectUserInfo(" where LoginName='" + uid + "'")[0];
        }
        //更新用户信息
        public int UpdateUserInfo(UserInfo uif)
        {
            return dal.UpdateUserInfo(uif);
        }
        ///// <summary>
        ///// 修改密码
        ///// </summary>
        ///// <param name="uif"></param>
        ///// <returns></returns>
        //public bool UpdateUserInfo(UserInfo uif)
        //{
        //    return dal.UpdateUserInfo(uif);
        //}
    }
}
