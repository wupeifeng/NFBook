using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNFBook.Models
{
    public class LoginPasste
    {
        public string Custons { get; set; }             //登录用户
        public string Cusurl { get; set; }              //登录路径(视图)
        public string CusCll { get; set; }              //登录路径(控制器)

        public string Shopcar { get; set; }             //购物车
        public string Shopurl { get; set; }             //购物车路径(视图)
        public string ShopCll { get; set; }             //购物车路径(控制器)
    }
}