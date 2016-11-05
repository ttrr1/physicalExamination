using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
using DBUtility;

namespace DAL
{
	/// <summary>
	/// 数据访问类:Blog
	/// </summary>
	public partial class BlogUserdb
	{
		public BlogUserdb()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("BlogID", "BlogUser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int BlogID)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from BlogUser");
			strSql.Append(" where BlogID=@BlogID");
			SqlParameter[] parameters = {
					new SqlParameter("@BlogID", SqlDbType.Int,4)
			};
			parameters[0].Value = BlogID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BlogUser model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into BlogUser(");
			strSql.Append("UserName,PassWord,Sex,ReallyName,Birthday,Address,PostCode,Email,HomePhone,MobilePhone,QQ,ICQ,RegTime,IP)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@PassWord,@Sex,@ReallyName,@Birthday,@Address,@PostCode,@Email,@HomePhone,@MobilePhone,@QQ,@ICQ,@RegTime,@IP)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@ReallyName", SqlDbType.NVarChar,50),
					new SqlParameter("@Birthday", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@HomePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@MobilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@ICQ", SqlDbType.NVarChar,50),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.PassWord;
			parameters[2].Value = model.Sex;
			parameters[3].Value = model.ReallyName;
			parameters[4].Value = model.Birthday;
			parameters[5].Value = model.Address;
			parameters[6].Value = model.PostCode;
			parameters[7].Value = model.Email;
			parameters[8].Value = model.HomePhone;
			parameters[9].Value = model.MobilePhone;
			parameters[10].Value = model.QQ;
			parameters[11].Value = model.ICQ;
            parameters[12].Value = DateTime.Now;
			parameters[13].Value = model.IP;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(BlogUser model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update BlogUser set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("PassWord=@PassWord,");
			strSql.Append("Sex=@Sex,");
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
			strSql.Append("IP=@IP");
			strSql.Append(" where BlogID=@BlogID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@ReallyName", SqlDbType.NVarChar,50),
					new SqlParameter("@Birthday", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@HomePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@MobilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@ICQ", SqlDbType.NVarChar,50),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.NVarChar,20),
					new SqlParameter("@BlogID", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.PassWord;
			parameters[2].Value = model.Sex;
			parameters[3].Value = model.ReallyName;
			parameters[4].Value = model.Birthday;
			parameters[5].Value = model.Address;
			parameters[6].Value = model.PostCode;
			parameters[7].Value = model.Email;
			parameters[8].Value = model.HomePhone;
			parameters[9].Value = model.MobilePhone;
			parameters[10].Value = model.QQ;
			parameters[11].Value = model.ICQ;
			parameters[12].Value = model.RegTime;
			parameters[13].Value = model.IP;
			parameters[14].Value = model.BlogID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int BlogID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from BlogUser ");
			strSql.Append(" where BlogID=@BlogID");
			SqlParameter[] parameters = {
					new SqlParameter("@BlogID", SqlDbType.Int,4)
			};
			parameters[0].Value = BlogID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string BlogIDlist )
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from BlogUser ");
			strSql.Append(" where BlogID in ("+BlogIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public BlogUser GetModel(int BlogID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 BlogID,UserName,PassWord,Sex,ReallyName,Birthday,Address,PostCode,Email,HomePhone,MobilePhone,QQ,ICQ,RegTime,IP from BlogUser ");
			strSql.Append(" where BlogID=@BlogID");
			SqlParameter[] parameters = {
					new SqlParameter("@BlogID", SqlDbType.Int,4)
			};
			parameters[0].Value = BlogID;

			BlogUser model=new BlogUser();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public BlogUser DataRowToModel(DataRow row)
		{
			BlogUser model=new BlogUser();
			if (row != null)
			{
				if(row["BlogID"]!=null && row["BlogID"].ToString()!="")
				{
					model.BlogID=int.Parse(row["BlogID"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["ReallyName"]!=null)
				{
					model.ReallyName=row["ReallyName"].ToString();
				}
				if(row["Birthday"]!=null)
				{
					model.Birthday=row["Birthday"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["PostCode"]!=null)
				{
					model.PostCode=row["PostCode"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["HomePhone"]!=null)
				{
					model.HomePhone=row["HomePhone"].ToString();
				}
				if(row["MobilePhone"]!=null)
				{
					model.MobilePhone=row["MobilePhone"].ToString();
				}
				if(row["QQ"]!=null)
				{
					model.QQ=row["QQ"].ToString();
				}
				if(row["ICQ"]!=null)
				{
					model.ICQ=row["ICQ"].ToString();
				}
				if(row["RegTime"]!=null && row["RegTime"].ToString()!="")
				{
					model.RegTime=DateTime.Parse(row["RegTime"].ToString());
				}
				if(row["IP"]!=null)
				{
					model.IP=row["IP"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select BlogID,UserName,PassWord,Sex,ReallyName,Birthday,Address,PostCode,Email,HomePhone,MobilePhone,QQ,ICQ,RegTime,IP ");
            strSql.Append(" FROM BlogUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" BlogID,UserName,PassWord,Sex,ReallyName,Birthday,Address,PostCode,Email,HomePhone,MobilePhone,QQ,ICQ,RegTime,IP ");
            strSql.Append(" FROM BlogUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM BlogUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.BlogID desc");
			}
            strSql.Append(")AS Row, T.*  from BlogUser T ");
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
			parameters[0].Value = "Blog";
			parameters[1].Value = "BlogID";
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

