﻿using SmartElk.Antler.Domain;
using SmartElk.Antler.EntityFramework.Internal;

namespace SmartElk.Antler.EntityFramework
{
    public class EntityFrameworkSessionScopeFactory: ISessionScopeFactory
    {
        private readonly IDataContextFactory _dbContextFactory;
        public EntityFrameworkSessionScopeFactory(IDataContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public ISessionScope Open()
        {            
            return new EntityFrameworkSessionScope(_dbContextFactory);
        }
    }
}
