using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Model;

namespace BLOGBack.ajax
{
    /// <summary>
    /// EditPassword 的摘要说明
    /// </summary>
    public class EditPassword : IHttpHandler
    {
        protected string newpass = string.Empty;
        protected string username = string.Empty;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            username = context.Request.Form["username"].ToString();
            newpass = context.Request.Form["newpass"].ToString();
            context.Response.Write(ChangePassword(newpass, username));
        }

        private string ChangePassword(string newpass, string username)
        {
            Adminbll bll = new Adminbll();
            Admin model = new Admin();
            bool blResult = false;

            model.PassWord = newpass;
            model.UserName = username;

            blResult = bll.ChangeLoginPassword(model);

            if (blResult)
            {
                return newpass;
            }
            else
            {
                return "修改失败";
            }
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