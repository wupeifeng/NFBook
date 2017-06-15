using System;
using System.Web;

namespace 上机一
{
    public class HttpModule : IHttpModule
    {
        HttpApplication app = null;
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此模块
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            app = context;
            context.EndRequest+=context_EndRequest;
        }

        #endregion
        protected void context_EndRequest(object sender, EventArgs e)
        {
            app.Response.Write("<h1>请登录系统后在购买图书！</h1>");
        }
    }
}
