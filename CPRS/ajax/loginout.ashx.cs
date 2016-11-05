using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Web.SessionState;

namespace BLOGBack.ajax
{
    /// <summary>
    /// HandlerLogin 的摘要说明
    /// </summary>
    public class loginout : IHttpHandler,IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Session["UserName"] = string.Empty;
            context.Session["PassWord"] = string.Empty;
            context.Session.Clear();
            context.Session.Abandon();
            context.Session.RemoveAll();
            context.Response.Redirect("/Login.aspx");
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