using DataverseTest.IRepositories;
using DataverseTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataverseTest.Repositories
{
    public class ContactRepository : IContactRepository
    {

        private readonly DataverseDbContext _context;

        public ContactRepository(DataverseDbContext context) =>      
            _context = context;
        

        public ICollection<Contact> GetAllContacts() =>       
             _context.Contacts.ToList(); 
        
        //find list of contacts by filter expression
        public ICollection<Contact> GetContactsWithExpressionFilter(Expression<Func<Contact, bool>> filterExpression) =>     
             _context.Contacts.ToList();
            
        //Find contact by id
        public Contact GetSingleContactById(int id) =>  
             _context.Contacts.Include(a=>a.ContactPhones).FirstOrDefault(a=>a.Id == id);
        
        //find contact by filter expression
        public Contact GetContactWithExpressionFilter(Expression<Func<Contact, bool>> filterExpression) =>     
             _context.Contacts.Find(filterExpression);
        

        //Add New Contact
        public void AddContact(Contact ct) =>       
            _context.Contacts.Add(ct);


        //Update existing Contact
        public void UpdateContact(Contact ct)
        {
            _context.Set<Contact>().Update(ct);
        }


        //Delete Contact
        public void DeleteContact(int Id)
        {
            Contact ct = _context.Set<Contact>().FirstOrDefault(a=>a.Id == Id);
            _context.Set<Contact>().Remove(ct);
        }
        
    }


}
