﻿using FluentNHibernate.Mapping;
using SmartElk.Antler.Specs.Shared.Entities;

namespace SmartElk.Antler.Hibernate.Specs.Mappings
{
    public class TeamMap : ClassMap<Team>
    {
        public TeamMap()
		{
			Table("STANDARDS_TEAMS");
			
            Id(a => a.Id).GeneratedBy.Native("STANDARDS_TEAMS_ID");
			Map(a => a.Name, "NAME");			
			Map(a => a.BusinessGroup, "BU");			
			HasManyToMany(a => a.Members)
				.Table("TEAMS_MEMBERS_MAP")
				.ParentKeyColumn("TEAM_ID")
				.ChildKeyColumn("MEMBER_GPIN")
				.ExtraLazyLoad();			
		}
    }
}
