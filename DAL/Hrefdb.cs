using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
using DBUtility;

namespace DAL
{
	/// <summary>
	/// 数据访问类:Href
	/// </summary>
	public partial class Hrefdb
	{
		public Hrefdb()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("HrefID", "Href"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int HrefID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Href");
			strSql.Append(" where HrefID=@HrefID");
			SqlParameter[] parameters = {
					new SqlParameter("@HrefID", SqlDbType.Int,4)
			};
			parameters[0].Value = HrefID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Href model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Href(");
			strSql.Append("Name,Url)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Url)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Url", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Url;

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
		public bool Update(Href model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Href set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Url=@Url");
			strSql.Append(" where HrefID=@HrefID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Url", SqlDbType.NVarChar,200),
					new SqlParameter("@HrefID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Url;
			parameters[2].Value = model.HrefID;

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
		public bool Delete(int HrefID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Href ");
			strSql.Append(" where HrefID=@HrefID");
			SqlParameter[] parameters = {
					new SqlParameter("@HrefID", SqlDbType.Int,4)
			};
			parameters[0].Value = HrefID;

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
		public bool DeleteList(string HrefIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Href ");
			strSql.Append(" where HrefID in ("+HrefIDlist + ")  ");
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
		public Href GetModel(int HrefID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 HrefID,Name,Url from Href ");
			strSql.Append(" where HrefID=@HrefID");
			SqlParameter[] parameters = {
					new SqlParameter("@HrefID", SqlDbType.Int,4)
			};
			parameters[0].Value = HrefID;

			Href model=new Href();
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
		public Href DataRowToModel(DataRow row)
		{
			Href model=new Href();
			if (row != null)
			{
				if(row["HrefID"]!=null && row["HrefID"].ToString()!="")
				{
					model.HrefID=int.Parse(row["HrefID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Url"]!=null)
				{
					model.Url=row["Url"].ToString();
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
			strSql.Append("select HrefID,Name,Url ");
			strSql.Append(" FROM Href ");
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
			strSql.Append(" HrefID,Name,Url ");
			strSql.Append(" FROM Href ");
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
			strSql.Append("select count(1) FROM Href ");
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
				strSql.Append("order by T.HrefID desc");
			}
			strSql.Append(")AS Row, T.*  from Href T ");
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
			parameters[0].Value = "Href";
			parameters[1].Value = "HrefID";
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

