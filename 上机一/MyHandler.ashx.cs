using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

namespace 上机一
{
    /// <summary>
    /// MyHandler 的摘要说明
    /// </summary>
    public class MyHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //为图片动态添加水印
            //1、把图片加载到内存中
            //获取图片的名称
            string name = context.Request.QueryString["name"];
            //通过图片名称获取其物理路径
            string path = context.Server.MapPath("~/Image/BookCover/" + name + ".jpg");
            //将图片加载到内存中
            Image img = Image.FromFile(path);
            //2、创建画板对象
            Graphics g = Graphics.FromImage(img);
            //3、创建绘画工具
            SolidBrush sb = new SolidBrush(Color.Gray);
            Font f = new Font("华文彩云", 14);
            //4、完成水印
            g.DrawString("南方图书网", f, sb, 20, 20);
            img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}