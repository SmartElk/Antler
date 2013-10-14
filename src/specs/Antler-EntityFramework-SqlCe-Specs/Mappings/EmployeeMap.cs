﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SmartElk.Antler.Specs.Shared.Entities;

namespace SmartElk.Antler.EntityFramework.Sqlite.Specs.Mappings
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            ToTable("EmployeeTable");

            HasKey(c => c.Id).Property(c => c.Id).HasColumnName("GPIN").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Email).HasColumnName("EMAIL");
            Property(p => p.FirstName).HasColumnName("FIRST_NAME");
            Property(p => p.LastName).HasColumnName("LAST_NAME");
            Property(p => p.JobTitle).HasColumnName("BUS_TITLE");

            HasRequired(d => d.LineManager).WithRequiredPrincipal(t => t.LineManager).Map(x => x.MapKey("SUPERVISOR_ID")); //???
            
            HasMany(d => d.Teams).WithMany(t => t.Members).Map(m =>
                {
                    m.ToTable("TEAMS_MEMBERS_MAP");
                    m.MapLeftKey("TEAM_ID");
                    m.MapRightKey("MEMBER_GPIN");
                });                                                   
        }        
    }
}
