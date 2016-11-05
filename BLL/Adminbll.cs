using System;
using System.Data;
using System.Collections.Generic;
using Model;
using DAL;

namespace BLL
{
	/// <summary>
	/// Admin
	/// </summary>
	public partial class Adminbll
	{
		private readonly Admindb dal=new Admindb();
		public Adminbll()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string strUserName, string strPassWord)
		{
            return dal.Exists(strUserName,strPassWord);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Admin model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Admin model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 用户更改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ChangeLoginPassword(Admin model)
        {
            return dal.ChangeLoginPassword(model);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Admin GetModel(int ID)
		{
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 根据用户登录名获取用户数据
        /// </summary>
        /// <param name="strUserName">用户登录名</param>
        /// <returns>DataSet</returns>
        public DataSet GetLoginInfo(string strUserName)
        {
            return dal.GetLoginInfo(strUserName);
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Admin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Admin> DataTableToList(DataTable dt)
		{
			List<Admin> modelList = new List<Admin>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Admin model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

