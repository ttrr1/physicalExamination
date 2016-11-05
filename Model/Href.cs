using System;
namespace Model
{
	/// <summary>
	/// Href:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Href
	{
		public Href()
		{}
		#region Model
		private int _hrefid;
		private string _name;
		private string _url;
		/// <summary>
		/// 
		/// </summary>
		public int HrefID
		{
			set{ _hrefid=value;}
			get{return _hrefid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		#endregion Model

	}
}

