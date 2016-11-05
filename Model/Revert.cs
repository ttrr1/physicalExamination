using System;
namespace Model
{
	/// <summary>
	/// Revert:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Revert
	{
		public Revert()
		{}
		#region Model
		private int _revertid;
		private string _subject;
		private string _content;
		private int? _articleid;
		private int? _blogid;
		private DateTime? _time;
		private string _ip;
		private int? _visitorid;
		private string _visitorname;
		/// <summary>
		/// 
		/// </summary>
		public int RevertID
		{
			set{ _revertid=value;}
			get{return _revertid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subject
		{
			set{ _subject=value;}
			get{return _subject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ArticleID
		{
			set{ _articleid=value;}
			get{return _articleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BlogID
		{
			set{ _blogid=value;}
			get{return _blogid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VisitorID
		{
			set{ _visitorid=value;}
			get{return _visitorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VisitorName
		{
			set{ _visitorname=value;}
			get{return _visitorname;}
		}
		#endregion Model

	}
}

