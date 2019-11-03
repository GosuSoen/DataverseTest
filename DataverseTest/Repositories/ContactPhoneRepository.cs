using DataverseTest.IRepositories;
using DataverseTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataverseTest.Repositories
{
    public class ContactPhoneRepository : IContactPhoneRepository
    {
        private readonly DataverseDbContext _context;

        public ContactPhoneRepository(DataverseDbContext context)
        {
            _context = context;
        }

        public ICollection<ContactPhone> GetAllContactPhones() =>
             _context.Set<ContactPhone>().ToList();


        //find list of contacts by filter expression
        public ICollection<ContactPhone> GetContactPhonesWithExpressionFilter(Expression<Func<bool, string>> filterExpression) =>
             _context.Set<ContactPhone>().ToList();


        //Find contact by id
        public ContactPhone GetSingleContactPhoneById(int id) =>
             _context.Set<ContactPhone>().FirstOrDefault(a => a.Id == id);


        //find contact by filter expression
        public ContactPhone GetContactPhoneWithExpressionFilter(Expression<Func<bool, string>> filterExpression) =>
             _context.Set<ContactPhone>().Find(filterExpression);


        //Add New Contact
        public void AddContactPhone(ContactPhone cp) =>
            _context.Set<ContactPhone>().Add(cp);


        //Update existing Contact
        public void UpdateContactPhone(ContactPhone cp) =>
            _context.Set<ContactPhone>().Update(cp);


        //Delete Contact
        public void DeleteContactPhone(ContactPhone cp) =>
            _context.Set<ContactPhone>().Remove(cp);
    }
}
