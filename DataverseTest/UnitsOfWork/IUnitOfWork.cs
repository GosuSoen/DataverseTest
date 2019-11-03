using DataverseTest.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataverseTest.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();

        IContactRepository Contacts { get; }
        IContactPhoneRepository ContactPhones { get; }
    }
}
