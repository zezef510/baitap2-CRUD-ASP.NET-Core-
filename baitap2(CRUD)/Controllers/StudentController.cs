using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


namespace baitap2_CRUD_.Controllers
{
    public class StudentController : Controller
    {
        // 
        // GET: /Student/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /Student/Welcome/ 

        // Requires using System.Text.Encodings.Web;
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}