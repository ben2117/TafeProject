//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    using System.ComponentModel;
    internal abstract partial class Attendance
    {
    	
    	partial void ObjectPropertyChanged(string propertyName);
    
    	private System.Guid _id;
        public  System.Guid Id 
		{ 
			get
			{ 
				return _id; 
			} 
			set
			{
				_id = value;
				ObjectPropertyChanged("Id");
			}
		}
    	private System.Guid _sessionid;
        public  System.Guid SessionId 
		{ 
			get
			{ 
				return _sessionid; 
			} 
			set
			{
				_sessionid = value;
				ObjectPropertyChanged("SessionId");
			}
		}
    	private int _memberid;
        public  int MemberId 
		{ 
			get
			{ 
				return _memberid; 
			} 
			set
			{
				_memberid = value;
				ObjectPropertyChanged("MemberId");
			}
		}
    
        public virtual Member Member { get; set; }
        public virtual Session Session { get; set; }
    }
}