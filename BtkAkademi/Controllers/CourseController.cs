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
            //Bu sorguda daha �nceden b�yle bir email kay�tl� ise modele hata veriyor
            if (Repository.Applications.Any(p => p.Email.Equals(candidate.Email)))
            {
                ModelState.AddModelError("", "Sizin i�in zaten bir ba�vuru var");
            }
            //Bu sorguda model durumunu kontrol ediyor hata yoksa i�lemleri yap�yor
            if(ModelState.IsValid)
            {
                Repository.Add(candidate);
                return View("FeedBack", candidate);
            }
            //Sorguda hata varsa ilgili viewi d�nd�r�yor
            return View();
        }        
    }
}