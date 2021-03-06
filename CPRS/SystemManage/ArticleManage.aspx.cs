﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BLL;
using Model;
using System.Data;

namespace BLOGBack.SystemManage
{
    public partial class ArticleManage : System.Web.UI.Page
    {
        Articlebll bll = new Articlebll();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = string.Empty;

            if (Request.Form["action"] != "")
                action = Request.Form["action"];

            switch (action)
            {
                case "query"://查询数据
                    QueryData();
                    break;
                case "queryone"://查询指定ID 的数据，修改时用
                    QueryOneData();
                    break;
                case "submit"://提交数据，添加或修改
                    UpdateData();
                    break;
                case "del"://删除数据
                    DelData();
                    break;
                default:
                    break;
            }
        }

        #region 删除指定ID 的数据
        /// <summary>
        /// 删除数据
        /// </summary>
        private void DelData()
        {
            string writeMsg = "删除失败！";

            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {
                int delNum = DataHandler.DelData("Article", selectID, "ArticleID");
                if (delNum > 0)
                {
                    writeMsg = string.Format("删除成功，本次共删除{0}条", delNum.ToString());
                }
                else
                {
                    writeMsg = "删除失败！";
                }
            }

            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }
        #endregion

        #region 添加或修改提交的数据
        /// <summary>
        /// 添加或修改数据
        /// </summary>
        private void UpdateData()
        {
            bool blResult = false;
            int id = Request.Form["id"] != "" ? Convert.ToInt32(Request.Form["id"]) : 0;
            Article model = GetData(id);

            string writeMsg = "操作失败！";
            if (model != null)
            {
                if (id < 1)
                {
                    blResult = bll.Add(model);
                    if (blResult)
                    {
                        writeMsg = "增加成功!";
                    }
                    else
                    {
                        writeMsg = "增加失败!";
                    }
                }
                else
                {
                    blResult = bll.Update(model);
                    if (blResult)
                    {
                        writeMsg = "更新成功!";
                    }
                    else
                    {
                        writeMsg = "更新失败!";
                    }

                }
            }
            Response.Clear();
            Response.Write(writeMsg);
            Response.End();
        }

        /// <summary>
        /// 取得数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Article GetData(int id)
        {
            Article model = new Article();
            if (id > 0)
            {
                model = bll.GetModel(id);
            }
            //model.Name = Request.Form["ipt_Name"] != "" ? Request.Form["ipt_Name"] : "";
            //model.Url = Request.Form["ipt_Url"] != "" ? Request.Form["ipt_Url"] : "";
            model.Subject = Request.Form["ipt_Subject"] != "" ? Request.Form["ipt_Subject"] : "";
            model.Author = Request.Form["ipt_Author"] != "" ? Request.Form["ipt_Author"] : "";
            model.Content = Request.Form["ipt_Content"] != "" ? Request.Form["ipt_Content"] : "";
            model.BlogID = null; //Session["UserID"].ToString();
            model.Time = DateTime.Now;

            return model;
        }
        #endregion

        #region 查询指定ID 的数据
        /// <summary>
        /// 获取指定ID的数据
        /// </summary>
        private void QueryOneData()
        {
            int userid = Request.Form["id"] != "" ? Convert.ToInt32(Request.Form["id"]) : 0;
            DataSet ds = bll.GetList(1, "ArticleID=" + userid, "ArticleID ASC");
            string strJSON = JsonHelper.CreateJsonOne(ds.Tables[0], false);
            Response.Clear();
            Response.Write(strJSON);
            Response.End();
        }
        #endregion

        #region 查询数据

        /// <summary>
        /// 查询数据
        /// </summary>
        private void QueryData()
        {
            int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            if (page < 1) return;
            string orderField = sort.Replace("JSON_", "");
            string strWhere = GetWhere();

            DataSet dsUser = DataHandler.GetList("Article", "*", " ArticleID", size, page, false, false, strWhere);
            int count = bll.GetList(strWhere).Tables[0].Rows.Count;//获取总数
            string strJSON = JsonHelper.CreateJsonParameters(dsUser.Tables[0], true, count);

            Response.Write(strJSON);
            Response.End();
        }

        /// <summary>
        /// 组合搜索条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            StringBuilder sb = new StringBuilder("1=1");
            string searchType = Request.Form["search_type"] != "" ? Request.Form["search_type"] : string.Empty;
            string searchValue = Request.Form["search_value"] != "" ? Request.Form["search_value"] : string.Empty;

            if (searchType != null && searchValue != "")
            {
                sb.AppendFormat(" and charindex('{0}',{1})>0", searchValue, searchType);
            }
            else
            {
                sb.AppendFormat("");
            }
            return sb.ToString();
        }

        #endregion
    }
}