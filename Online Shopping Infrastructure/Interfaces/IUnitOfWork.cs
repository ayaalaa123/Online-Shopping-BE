using Online_Shopping_Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Infrastructure.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        ApplicationContext Context { get; }
        void Commit();
    }
}
