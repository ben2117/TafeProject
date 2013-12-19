﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    internal partial class U3AContext : DbContext
    {
        public U3AContext()
            : base("name=U3AContext")
        {
    		Areas = Set<Area>();	
    		Attendances = Set<Attendance>();	
    		ClassGroups = Set<ClassGroup>();	
    		CourseDescriptions = Set<CourseDescription>();	
    		CourseInstances = Set<CourseInstance>();	
    		Members = Set<Member>();	
    		Organizations = Set<Organization>();	
    		Regions = Set<Region>();	
    		Sessions = Set<Session>();	
    		Suburbs = Set<Suburb>();	
    		Venues = Set<Venue>();	
    
    
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        internal DbSet<Area> Areas { get; set; }
        internal DbSet<Attendance> Attendances { get; set; }
        internal DbSet<ClassGroup> ClassGroups { get; set; }
        internal DbSet<CourseDescription> CourseDescriptions { get; set; }
        internal DbSet<CourseInstance> CourseInstances { get; set; }
        internal DbSet<Member> Members { get; set; }
        internal DbSet<Organization> Organizations { get; set; }
        internal DbSet<Region> Regions { get; set; }
        internal DbSet<Session> Sessions { get; set; }
        internal DbSet<Suburb> Suburbs { get; set; }
        internal DbSet<Venue> Venues { get; set; }
    }
}