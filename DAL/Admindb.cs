using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// 数据访问类:Admin
    /// </summary>
    public partial class Admindb
    {
        public Admindb()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Admin");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strUserName,string strPassWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Admin");
            strSql.Append(" where UserName=@UserName and PassWord=@PassWord");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50)};

            parameters[0].Value = strUserName;
            parameters[1].Value = strPassWord;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Admin(");
            strSql.Append("UserName,PassWord,ReallyName,Birthday,Address,PostCode,Email,HomePhone,MobilePhone,QQ,ICQ,RegTime,Sex,IP,BlogID,SuperAdmin)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@PassWord,@ReallyName,@Birthday,@Address,@PostCode,@Email,@HomePhone,@MobilePhone,@QQ,@ICQ,@RegTime,@Sex,@IP,@BlogID,@SuperAdmin)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@ReallyName", SqlDbType.NVarChar,50),
					new SqlParameter("@Birthday", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@HomePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@MobilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@ICQ", SqlDbType.NVarChar,50),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@Sex", SqlDbType.NVarChar,4),
					new SqlParameter("@IP", SqlDbType.NVarChar,20),
					new SqlParameter("@BlogID", SqlDbType.Int,4),
					new SqlParameter("@SuperAdmin", SqlDbType.NVarChar,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.ReallyName;
            parameters[3].Value = model.Birthday;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.PostCode;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.HomePhone;
            parameters[8].Value = model.MobilePhone;
            parameters[9].Value = model.QQ;
            parameters[10].Value = model.ICQ;
            parameters[11].Value = model.RegTime;
            parameters[12].Value = model.Sex;
            parameters[13].Value = model.IP;
            parameters[14].Value = model.BlogID;
            parameters[15].Value = model.SuperAdmin;

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
        public bool Update(Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Admin set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PassWord=@PassWord,");
            strSql.Append("ReallyName=@ReallyName,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("Address=@Address,");
            strSql.Append("PostCode=@PostCode,");
            strSql.Append("Email=@Email,");
            strSql.Append("HomePhone=@HomePhone,");
            strSql.Append("MobilePhone=@MobilePhone,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("ICQ=@ICQ,");
            strSql.Append("RegTime=@RegTime,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("IP=@IP,");
            strSql.Append("BlogID=@BlogID,");
            strSql.Append("SuperAdmin=@SuperAdmin");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@ReallyName", SqlDbType.NVarChar,50),
					new SqlParameter("@Birthday", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@HomePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@MobilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@ICQ", SqlDbType.NVarChar,50),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@Sex", SqlDbType.NVarChar,4),
					new SqlParameter("@IP", SqlDbType.NVarChar,20),
					new SqlParameter("@BlogID", SqlDbType.Int,4),
					new SqlParameter("@SuperAdmin", SqlDbType.NVarChar,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.ReallyName;
            parameters[3].Value = model.Birthday;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.PostCode;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.HomePhone;
            parameters[8].Value = model.MobilePhone;
            parameters[9].Value = model.QQ;
            parameters[10].Value = model.ICQ;
            parameters[11].Value = model.RegTime;
            parameters[12].Value = model.Sex;
            parameters[13].Value = model.IP;
            parameters[14].Value = model.BlogID;
            parameters[15].Value = model.SuperAdmin;
            parameters[16].Value = model.ID;

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
        /// 用户更改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ChangeLoginPassword(Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Admin set ");
            strSql.Append("PassWord=@PassWord");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50)};

            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;

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
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Admin ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Admin ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public Admin GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,PassWord,ReallyName,Birthday,Address,PostCode,Email,HomePhone,MobilePhone,QQ,ICQ,RegTime,Sex,IP,BlogID,SuperAdmin from Admin ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Admin model = new Admin();
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
        public Admin DataRowToModel(DataRow row)
        {
            Admin model = new Admin();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["PassWord"] != null)
                {
                    model.PassWord = row["PassWord"].ToString();
                }
                if (row["ReallyName"] != null)
                {
                    model.ReallyName = row["ReallyName"].ToString();
                }
                if (row["Birthday"] != null)
                {
                    model.Birthday = row["Birthday"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["PostCode"] != null)
                {
                    model.PostCode = row["PostCode"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["HomePhone"] != null)
                {
                    model.HomePhone = row["HomePhone"].ToString();
                }
                if (row["MobilePhone"] != null)
                {
                    model.MobilePhone = row["MobilePhone"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["ICQ"] != null)
                {
                    model.ICQ = row["ICQ"].ToString();
                }
                if (row["RegTime"] != null && row["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(row["RegTime"].ToString());
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["IP"] != null)
                {
                    model.IP = row["IP"].ToString();
                }
                if (row["BlogID"] != null && row["BlogID"].ToString() != "")
                {
                    model.BlogID = int.Parse(row["BlogID"].ToString());
                }
                if (row["SuperAdmin"] != null)
                {
                    model.SuperAdmin = row["SuperAdmin"].ToString();
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
            strSql.Append("select ID,UserName,PassWord,ReallyName,Birthday,Address,PostCode,Email,HomePhone,MobilePhone,QQ,ICQ,RegTime,Sex,IP,BlogID,SuperAdmin ");
            strSql.Append(" FROM Admin ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据用户登录名获取用户数据
        /// </summary>
        /// <param name="strUserName">用户登录名</param>
        /// <returns>DataSet</returns>
        public DataSet GetLoginInfo(string strUserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserName,PassWord FROM Admin");
            if (strUserName.Trim() != "")
            {
                strSql.Append(" where UserName='" + strUserName + "'");
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
            strSql.Append(" ID,UserName,PassWord,ReallyName,Birthday,Address,PostCode,Email,HomePhone,MobilePhone,QQ,ICQ,RegTime,Sex,IP,BlogID,SuperAdmin ");
            strSql.Append(" FROM Admin ");
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
            strSql.Append("select count(1) FROM Admin ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from Admin T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

