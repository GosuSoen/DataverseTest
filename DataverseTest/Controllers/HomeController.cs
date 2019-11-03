using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataverseTest.Models;
using DataverseTest.UnitsOfWork;
using DataverseTest.ViewModels;

namespace DataverseTest.Controllers
{
    public class HomeController : Controller
    {
        //Intanciate db context and unit of work
        private readonly DataverseDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //initialize 
        public HomeController(DataverseDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        //First view with the list of contacts
        public IActionResult Index()
        {
            ICollection<Contact> _contacts =  _unitOfWork.Contacts.GetAllContacts();
            return View(_contacts);
        }

        //Create new contact View
        public IActionResult Create() => View();
         

        [HttpPost]
        public IActionResult Create(ContactViewModel cvm)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Contacts.AddContact(cvm.Contact);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(cvm);
        }

        //Build ContactViewModel baased on
        public IActionResult Edit(int id)
        {
            Contact ct = _unitOfWork.Contacts.GetSingleContactById(id);
            return View(new ContactViewModel { Contact = ct });
        }

        //Edit Contact View
        [HttpPost]
        public IActionResult Edit(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Contacts.UpdateContact(cvm.Contact);
                _unitOfWork.Complete();
            }
            return View(cvm);
        }

        //We add a Phone To a Contact view ViewModel
        [HttpPost]
        public IActionResult AddContactPhone(ContactViewModel cvm)
        {       
            Contact ct = _unitOfWork.Contacts.GetSingleContactById(cvm.Contact.Id);
            ct.ContactPhones.Add(new ContactPhone { Contact = ct, PhoneNumber = cvm.PhoneNumber });
            _unitOfWork.Contacts.UpdateContact(ct);
            _unitOfWork.Complete();            
            return RedirectToAction(nameof(Edit), new { id = cvm.Contact.Id });
        }

        //Delete Contact action and show first page
        [HttpPost]
        public IActionResult Delete(int contactId)
        {
            _unitOfWork.Contacts.DeleteContact(contactId);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        //Delete Phone. We just need to pass the id of the contact and the id of the contact number
        [HttpPost]
        public IActionResult DeleteContactPhone(int contactId, int phoneId)
        {
            Contact ct = _unitOfWork.Contacts.GetSingleContactById(contactId);
            ContactPhone cp = ct.ContactPhones.FirstOrDefault(a=>a.Id == phoneId);
            _unitOfWork.ContactPhones.DeleteContactPhone(cp);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Edit), new { id = contactId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
