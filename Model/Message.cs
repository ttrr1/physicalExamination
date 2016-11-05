using System;
namespace Model
{
	/// <summary>
	/// Message:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Message
	{
		public Message()
		{}
		#region Model
		private int _messageid;
		private int _blogid;
		private int _friendid;
		/// <summary>
		/// 
		/// </summary>
		public int MessageID
		{
			set{ _messageid=value;}
			get{return _messageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int BlogID
		{
			set{ _blogid=value;}
			get{return _blogid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FriendID
		{
			set{ _friendid=value;}
			get{return _friendid;}
		}
		#endregion Model

	}
}

