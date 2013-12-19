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
    internal partial class ClassGroup
    {
    	
    	partial void ObjectPropertyChanged(string propertyName);
    
        public ClassGroup()
        {
            this.Active = true;
            this.Sessions = new HashSet<Session>();
        }
    
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
    	private int _studentcount;
        public  int StudentCount 
		{ 
			get
			{ 
				return _studentcount; 
			} 
			set
			{
				_studentcount = value;
				ObjectPropertyChanged("StudentCount");
			}
		}
    	private System.Guid _defaultareaid;
        public  System.Guid DefaultAreaId 
		{ 
			get
			{ 
				return _defaultareaid; 
			} 
			set
			{
				_defaultareaid = value;
				ObjectPropertyChanged("DefaultAreaId");
			}
		}
    	private System.Guid _courseinstanceid;
        public  System.Guid CourseInstanceId 
		{ 
			get
			{ 
				return _courseinstanceid; 
			} 
			set
			{
				_courseinstanceid = value;
				ObjectPropertyChanged("CourseInstanceId");
			}
		}
    	private string _classgroupname;
        public  string ClassGroupName 
		{ 
			get
			{ 
				return _classgroupname; 
			} 
			set
			{
				_classgroupname = value;
				ObjectPropertyChanged("ClassGroupName");
			}
		}
    	private bool _active;
        public  bool Active 
		{ 
			get
			{ 
				return _active; 
			} 
			set
			{
				_active = value;
				ObjectPropertyChanged("Active");
			}
		}
    
        public virtual Area Area { get; set; }
        public virtual CourseInstance CourseInstance { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}