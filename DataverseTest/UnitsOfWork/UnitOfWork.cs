using DataverseTest.IRepositories;
using DataverseTest.Models;
using DataverseTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataverseTest.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //Context Intantiation
        private readonly DataverseDbContext _context;

        //Intanciate data repositories
        private readonly IContactRepository contactRepository;
        private readonly IContactPhoneRepository contactphoneRepository;

        public UnitOfWork(DataverseDbContext context)
        {
            _context = context;
            contactRepository = new ContactRepository(_context);
            contactphoneRepository = new ContactPhoneRepository(_context);
        }
    }
}
