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
             _context.ContactPhones.ToList();


        //find list of contacts by filter expression
        public ICollection<ContactPhone> GetContactPhonesWithExpressionFilter(Expression<Func<ContactPhone, bool>> filterExpression) =>
             _context.ContactPhones.ToList();

        //Find contact by id
        public ContactPhone GetSingleContactPhoneById(int id) =>
             _context.ContactPhones.FirstOrDefault(a => a.Id == id);

        //find contact by filter expression
        public ContactPhone GetContactPhoneWithExpressionFilter(Expression<Func<ContactPhone, bool>> filterExpression) =>
             _context.ContactPhones.Find(filterExpression);

        //Add New Contact
        public void AddContactPhone(ContactPhone cp) =>
            _context.ContactPhones.Add(cp);

        //Update existing Contact
        public void UpdateContactPhone(ContactPhone cp) =>
            _context.ContactPhones.Update(cp);

        //Delete Contact
        public void DeleteContactPhone(ContactPhone cp) =>
            _context.ContactPhones.Remove(cp);
    }
}
