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
        private IContactRepository _contactRepository;
        private IContactPhoneRepository _contactphoneRepository;

        //Initialize context and services 
        public UnitOfWork(DataverseDbContext context)
        {
            _context = context;
        }

        #region Initialize data repository area

        //Initialze Contacts
        public IContactRepository Contacts
        {
            get
            {
                if (_contactRepository == null)
                {
                    _contactRepository = new ContactRepository(_context);
                }
                return _contactRepository;
            }
        }


        //Initialze ContactPhones
        public IContactPhoneRepository ContactPhones
        {
            get
            {
                if (_contactphoneRepository == null)
                {
                    _contactphoneRepository = new ContactPhoneRepository(_context);
                }
                return _contactphoneRepository;
            }
        }

        #endregion



        //Commit changes
        public int Complete() =>       
             _context.SaveChanges();
        
        //Dispose db context
        public void Dispose() => 
            _context.Dispose();
        
    }
}
