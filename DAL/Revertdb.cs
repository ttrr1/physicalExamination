using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// 数据访问类:Revert
    /// </summary>
    public partial class Revertdb
    {
        public Revertdb()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("RevertID", "Revert");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RevertID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Revert");
            strSql.Append(" where RevertID=@RevertID");
            SqlParameter[] parameters = {
					new SqlParameter("@RevertID", SqlDbType.Int,4)
			};
            parameters[0].Value = RevertID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Revert model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Revert(");
            strSql.Append("Subject,Content,ArticleID,BlogID,Time,IP,VisitorID,VisitorName)");
            strSql.Append(" values (");
            strSql.Append("@Subject,@Content,@ArticleID,@BlogID,@Time,@IP,@VisitorID,@VisitorName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Subject", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@BlogID", SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.NVarChar,20),
					new SqlParameter("@VisitorID", SqlDbType.Int,4),
					new SqlParameter("@VisitorName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Subject;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.ArticleID;
            parameters[3].Value = model.BlogID;
            parameters[4].Value = model.Time;
            parameters[5].Value = model.IP;
            parameters[6].Value = model.VisitorID;
            parameters[7].Value = model.VisitorName;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Revert model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Revert set ");
            strSql.Append("Subject=@Subject,");
            strSql.Append("Content=@Content,");
            strSql.Append("ArticleID=@ArticleID,");
            strSql.Append("BlogID=@BlogID,");
            strSql.Append("Time=@Time,");
            strSql.Append("IP=@IP,");
            strSql.Append("VisitorID=@VisitorID,");
            strSql.Append("VisitorName=@VisitorName");
            strSql.Append(" where RevertID=@RevertID");
            SqlParameter[] parameters = {
					new SqlParameter("@Subject", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@BlogID", SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.NVarChar,20),
					new SqlParameter("@VisitorID", SqlDbType.Int,4),
					new SqlParameter("@VisitorName", SqlDbType.NVarChar,50),
					new SqlParameter("@RevertID", SqlDbType.Int,4)};
            parameters[0].Value = model.Subject;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.ArticleID;
            parameters[3].Value = model.BlogID;
            parameters[4].Value = model.Time;
            parameters[5].Value = model.IP;
            parameters[6].Value = model.VisitorID;
            parameters[7].Value = model.VisitorName;
            parameters[8].Value = model.RevertID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RevertID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Revert ");
            strSql.Append(" where RevertID=@RevertID");
            SqlParameter[] parameters = {
					new SqlParameter("@RevertID", SqlDbType.Int,4)
			};
            parameters[0].Value = RevertID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string RevertIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Revert ");
            strSql.Append(" where RevertID in (" + RevertIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Revert GetModel(int RevertID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RevertID,Subject,Content,ArticleID,BlogID,Time,IP,VisitorID,VisitorName from Revert ");
            strSql.Append(" where RevertID=@RevertID");
            SqlParameter[] parameters = {
					new SqlParameter("@RevertID", SqlDbType.Int,4)
			};
            parameters[0].Value = RevertID;

            Revert model = new Revert();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Revert DataRowToModel(DataRow row)
        {
            Revert model = new Revert();
            if (row != null)
            {
                if (row["RevertID"] != null && row["RevertID"].ToString() != "")
                {
                    model.RevertID = int.Parse(row["RevertID"].ToString());
                }
                if (row["Subject"] != null)
                {
                    model.Subject = row["Subject"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["ArticleID"] != null && row["ArticleID"].ToString() != "")
                {
                    model.ArticleID = int.Parse(row["ArticleID"].ToString());
                }
                if (row["BlogID"] != null && row["BlogID"].ToString() != "")
                {
                    model.BlogID = int.Parse(row["BlogID"].ToString());
                }
                if (row["Time"] != null && row["Time"].ToString() != "")
                {
                    model.Time = DateTime.Parse(row["Time"].ToString());
                }
                if (row["IP"] != null)
                {
                    model.IP = row["IP"].ToString();
                }
                if (row["VisitorID"] != null && row["VisitorID"].ToString() != "")
                {
                    model.VisitorID = int.Parse(row["VisitorID"].ToString());
                }
                if (row["VisitorName"] != null)
                {
                    model.VisitorName = row["VisitorName"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.Subject,a.Content,a.Time,a.VisitorName,b.UserName ");
            strSql.Append(" from Revert a ");
            strSql.Append(" join BlogUser b on a.BlogID = b.BlogID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" RevertID,Subject,Content,ArticleID,BlogID,Time,IP,VisitorID,VisitorName ");
            strSql.Append(" FROM Revert ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Revert ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.RevertID desc");
            }
            strSql.Append(")AS Row, T.*  from Revert T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Revert";
            parameters[1].Value = "RevertID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

