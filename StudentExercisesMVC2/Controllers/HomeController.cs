using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentExercisesMVC2.Models;
using StudentExercisesMVC2.Models.ViewModels;

namespace StudentExercisesMVC2.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public string _connectionstring = "Server=localhost\\SQLEXPRESS;Database=StudentExercises;Trusted_Connection=True;";

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionstring);
            }
        }
        public ActionResult Index()
        {
            StudentInstructorViewModel model = new StudentInstructorViewModel(_connectionstring);
            return View(model);
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
