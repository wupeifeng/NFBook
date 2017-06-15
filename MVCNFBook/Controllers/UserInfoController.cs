using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace MVCNFBook.Controllers
{
    public class UserInfoController : Controller
    {
        //登录
        [HttpGet]
        public ActionResult Login()
        {
            //if (Request.Cookies.Count > 0)
            //{
            //    ViewBag.Name = Request.Cookies["LoginName"].Value as string;
            //}
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection forms)
        {
            string name = forms["txtUid"];
            string pwd = GetMD5(forms["txtPwd"]);
            List<UserInfo> uif = new BLL.UserInfoBLL().SelectUserInfo(name);
            string str = "";
            if (uif .Count!=0)
            {
                if (uif[0].Password == pwd)
                {
                    //创建用户登录对象
                    Session["UserInfo"] = uif;
                    //创建购物车
                    Session["ShopCar"] = new List<Model.Book>();

                    return RedirectToAction("Default", "Books");
                }
                else
                {
                    str = "密码错误";
                }
            }
            else
            {
                str = "帐号不存在";
            }
            ViewBag.Msg = str;
            return View();
        }

        //用户注册
        [HttpGet]
        public ActionResult CustomerRegist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerRegist(Model.UserInfo uif)
        {
            if (string.IsNullOrEmpty(uif.LoginName))
            {
                ModelState.AddModelError("LoginName", "帐号不能为空！");
                return View();
            }

            if (string.IsNullOrEmpty(uif.Password))
            {
                ModelState.AddModelError("Password", "密码不能为空！");
                return View();
            }


            if (string.IsNullOrEmpty(uif.Email))
            {
                ModelState.AddModelError("Email", "电子邮箱不能为空！");
                return View();
            }


            //判断帐号是否已存在
            List<UserInfo> list = new UserInfoBLL().SelectUserInfo(uif.LoginName);

            string str = "";
            if (list.Count > 0)
            {
                str = "您输入的帐号已经存在！" + "\t" + "请重新选择";
            }
            else
            {
                uif.Password = GetMD5(uif.Password);
                uif.State = 0;
                uif.UsertName = uif.LoginName;
                int count =new UserInfoBLL().InsertUserInfo(uif);
                //判断结果
                switch (count)
                {
                    case -2:
                        str = "数据库链接异常！请联系你的管理员";
                        break;
                    case -1:
                        str = "数据操作异常，请检查你的数据！";
                        break;
                    case 0:
                        str = "没有添加任何数据";
                        break;
                    default:
                        str = "注册成功！您可以开始购物或完善个人资料";
                        break;
                }
            }
            ViewBag.Msg = str;
            return View();
        }

        public PartialViewResult LoginMeun()
        {
            MVCNFBook.Models.LoginPasste login = new Models.LoginPasste();
            login.Custons = "登录|";
            login.Cusurl = "Login";
            login.CusCll = "UserInfo";

            login.Shopcar = "购物车[0]";
            login.Shopurl = "Login";
            login.ShopCll = "UserInfo";


            if (Session["UserInfo"] != null)
            {
                login.Custons = ((List<UserInfo>)Session["UserInfo"])[0].LoginName + "|";
                login.Cusurl = "Supplement";
            }
            if (Session["ShopCar"] != null)
            {
                login.Shopcar = "购物车[" + ((List<Book>)Session["ShopCar"]).Count + "]|";
                login.Shopurl = "ShopCarList";
                login.ShopCll = "ShopCar";
            }

            return PartialView(login);
        }
        //基本资料
        [HttpGet]
        public ActionResult Supplement()
        {
            if(Session["UserInfo"]==null)
                return RedirectToAction("Login", "UserInfo");

            string name = ((List<UserInfo>)Session["UserInfo"])[0].LoginName as string;
            Model.UserInfo uif = new BLL.UserInfoBLL().Login(name);

            return View(uif);
        }

        [HttpPost]
        public ActionResult Supplement(Model.UserInfo uif)
        {
            if (string.IsNullOrEmpty(uif.UsertName))
                ModelState.AddModelError("UsertName", "用户姓名不能为空！");

            if (uif.Birthday < 18)
                ModelState.AddModelError("Birthday", "年龄超出范围！");

            if (ModelState.IsValid)
                ViewBag.Msg = "验证通过";
            else
                ViewBag.Msg = "未通过验证";
            uif.LoginName = ((List<UserInfo>)Session["UserInfo"])[0].LoginName as string;
                
            int sql = new BLL.UserInfoBLL().UpdateUserInfo(uif);

            if (sql > 0)
            {
                ViewBag.Msg = "保存成功";
            }
            else
            {
                ViewBag.Msg = "保存失败！";
            }
            return View();
        }
        //联系方式
        [HttpGet]
        public ActionResult Contact()
        {
            string name = ((List<UserInfo>)Session["UserInfo"])[0].LoginName as string;
            Model.UserInfo uif = new BLL.UserInfoBLL().Login(name);
            ViewBag.Msg = "";
            return View(uif);
        }

        [HttpPost]
        public ActionResult Contact(Model.UserInfo uif)
        {
            if (string.IsNullOrEmpty(uif.Phone))
                ModelState.AddModelError("Phone", "联系电话不能为空！");

            if (string.IsNullOrEmpty(uif.QQMSN))
                ModelState.AddModelError("QQMSN", "QQ/微信不能为空！");

            if (string.IsNullOrEmpty(uif.Address))
                ModelState.AddModelError("Address", "通讯地址不能为空！");

            if (ModelState.IsValid)
                ViewBag.Msg = "验证通过";
            else
                ViewBag.Msg = "未通过验证";

            uif.LoginName = ((List<UserInfo>)Session["UserInfo"])[0].LoginName as string;

            int sql = new BLL.UserInfoBLL().UpdateUserInfo(uif);

            if (sql > 0)
            {
                ViewBag.Msg = "保存成功";
            }
            else
            {
                ViewBag.Msg = "保存失败！";
            }

            return View();
        }

        //密码保护
        [HttpGet]
        public ActionResult PasswordProtection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasswordProtection(Model.UserInfo uif)
        {
            if (string.IsNullOrEmpty(uif.Question))
                ModelState.AddModelError("Question", "密保问题不能为空！");

            if (string.IsNullOrEmpty(uif.Answer))
                ModelState.AddModelError("Answer", "答案不能为空！");


            if (ModelState.IsValid)
                ViewBag.Msg = "验证通过";
            else
                ViewBag.Msg = "未通过验证";

            uif.LoginName = ((List<UserInfo>)Session["UserInfo"])[0].LoginName as string;

            int sql = new BLL.UserInfoBLL().UpdateUserInfo(uif);

            if (sql > 0)
            {
                ViewBag.Msg = "保存成功";
            }
            else
            {
                ViewBag.Msg = "保存失败！";
            }

            return View();
        }

        //找回密码
        [HttpGet]
        public ActionResult GetBackPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetBackPassword(FormCollection forms, Model.UserInfo uif)
        {
            if (forms["txtUid"] != "")
            {
                string name = forms["txtUid"];
                Model.UserInfo LoginName = new BLL.UserInfoBLL().Login(name);
                string str = "";
                if (LoginName != null)
                {
                    //保存对象
                    Session["Name"] = LoginName;
                }
                else
                {
                    str = "帐号不存在";
                }
                ViewBag.Question ="密保问题："+ ((UserInfo)Session["Name"]).Question as string+"？";
                ViewBag.Text = str;
            }
            if (uif != null)
            {
                string Answer=((UserInfo)Session["Name"]).Answer as string;

                if ((string.IsNullOrEmpty(uif.Answer)) || (uif.Answer != Answer))
                {
                    ModelState.AddModelError("Answer", "密保答案错误！");
                    return View();
                }

                if (ModelState.IsValid)
                    ViewBag.Msg = "验证通过";
                else
                    ViewBag.Msg = "未通过验证";

                uif.Password = GetMD5("1234");

                uif.LoginName = ((UserInfo)Session["Name"]).LoginName as string;

                int sql = new BLL.UserInfoBLL().UpdateUserInfo(uif);

                if (sql > 0)
                {
                    ViewBag.Msg = "密码重置成功！" + "\n" + "为了您的帐号安全，请立即使用初始密码重新登录";
                }
                else
                {
                    ViewBag.Msg = "重置失败！";
                }
            }
            

            return View();
        }

        private string GetMD5(string pwd)
        {
            byte[] result = Encoding.Default.GetBytes(pwd);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string encryptResult = BitConverter.ToString(output).Replace("-", "");
            return encryptResult;
        }
    }
}
