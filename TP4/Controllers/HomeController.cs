using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;
using TP4.Data;
using TP4.Models;

namespace TP4.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // UniversityContext.Instantiate_UniversityContext();
            // UniversityContext.Instantiate_UniversityContext();
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            List<Student> s = universityContext.Student.ToList();
            foreach (Student student in s)
            {
                Debug.WriteLine("id: {0}, first_name: {1}, last_name: {2}, phone_number: {3}", student.id, student.first_name, student.last_name, student.phone_number);
            }
            return View();
        }

        public IActionResult Privacy(string id)
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}