using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace BLOGBack
{
    public partial class Login:System.Web.UI.Page
    {
        Adminbll bll = new Adminbll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void IBt_Submit_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_UserName.Text.Trim()) && !string.IsNullOrEmpty(txt_Password.Text.Trim()))
            {
                bool blResult = false;

                string strUserName = txt_UserName.Text.Trim();
                string strPassWord = txt_Password.Text.Trim();
                blResult = bll.Exists(strUserName,strPassWord);

                if (blResult)
                {
                    DataSet ds = bll.GetLoginInfo(strUserName);

                    Session["UserName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                    Session["PassWord"] = ds.Tables[0].Rows[0]["PassWord"].ToString();
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Session["UserName"] = string.Empty;
                    Response.Write("<script>alert('用户名或密码错误！')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('请输入用户名和密码！')</script>");
            }
            Response.Redirect("Index.aspx");
        }
    }
}