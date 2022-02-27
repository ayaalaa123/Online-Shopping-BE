using Online_Shopping_Domain;
using Online_Shopping_Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Infrastructure.Repositories
{
   public class UnitOfWork : IUnitOfWork
    {
        public ApplicationContext Context { get; }

        public UnitOfWork(ApplicationContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
