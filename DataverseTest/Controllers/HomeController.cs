using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataverseTest.Models;

namespace DataverseTest.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var q = _unitOfWork.contactRepository.GetAllContacts();
            return View();
        }

        
        public IActionResult Create()
        {
            return RedirectToAction();
        }

        [HttpPost]
        public IActionResult Create(Contact c)
        {
            return RedirectToAction();
        }


        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return View();
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
