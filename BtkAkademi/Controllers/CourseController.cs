using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BtkAkademi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BtkAkademi.Controllers
{
    // [Route("[controller]")]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View(model);
        }

        public IActionResult Apply()
        {
            return View();
        }    

        [HttpPost]    
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm] Candidate candidate)
        {
            //Bu sorguda daha önceden böyle bir email kayýtlý ise modele hata veriyor
            if (Repository.Applications.Any(p => p.Email.Equals(candidate.Email)))
            {
                ModelState.AddModelError("", "Sizin için zaten bir baþvuru var");
            }
            //Bu sorguda model durumunu kontrol ediyor hata yoksa iþlemleri yapýyor
            if(ModelState.IsValid)
            {
                Repository.Add(candidate);
                return View("FeedBack", candidate);
            }
            //Sorguda hata varsa ilgili viewi döndürüyor
            return View();
        }        
    }
}