using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataverseTest.Models;
using DataverseTest.UnitsOfWork;

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
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Contact c)
        {
            if(ModelState.IsValid)           
                _unitOfWork.Contacts.AddContact(c);
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        //Edit Contact View
        [HttpPost]
        public IActionResult Edit(Contact c)
        {
            if (ModelState.IsValid)
                _unitOfWork.Contacts.UpdateContact(c);

            return View();
        }

        //Delete Contact action and show first page
        [HttpPost]
        public IActionResult Delete(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        //Delete Phone for a specific Contact
        [HttpPost]
        public IActionResult DeleteContactPhone(int contactId, int contatPhoneId)
        {
            return RedirectToAction(nameof(Index));
        }


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
