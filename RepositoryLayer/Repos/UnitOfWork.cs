﻿using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int CommitChanges()
        {
            return _appDbContext.SaveChanges();
        }
    }
}
