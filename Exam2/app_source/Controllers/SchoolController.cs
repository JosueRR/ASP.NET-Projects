using Microsoft.AspNetCore.Mvc;
using app.Handlers;
using app.Models;

namespace app.Controllers
{
    public class SchoolController : Controller
    {
        // Handles the GET request for Index
        public IActionResult Index()
        {
            SchoolHandler schoolHandler = new SchoolHandler();
            var schools = schoolHandler.ObtenerSchools();
            ViewBag.MainTitle = "List of Schools";
            return View(schools);
        }

        // Handles the GET request for the CrearSchool request, returns view
        [HttpGet]
        public ActionResult CrearSchool()
        {
            return View();
        }

        // Handles the POST request for the CrearSchool request
        [HttpPost]
        public ActionResult CrearSchool(SchoolModel school)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    SchoolHandler schoolHandler = new SchoolHandler();
                    ViewBag.ExitoAlCrear = schoolHandler.CrearSchool(school);

                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "The school " + school.Nombre + " was created succesfully ";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Ups, something went wrong while trying to create a new school. Please try again";
                return View();
            }
        }

        // Handles the GET request for the EditarSchool, receives an identificador parameter to identify the school to edit
        [HttpGet]
        public ActionResult EditarSchool(int? identificador)
        {
            ActionResult vista;
            try 
            {
                var schoolHandler = new SchoolHandler();
                var school = schoolHandler.ObtenerSchools().Find(model => model.Id == identificador);
                if (school == null)
                {
                    vista = RedirectToAction("Index");
                }
                else
                {
                    vista = View(school);
                }
            }
            catch
            {
                ViewBag.Message = "Ups, something went wrong while trying to edit a school. Please try again";
                vista = RedirectToAction("Index");
            }
            return vista;
        }

        // Handles the POST  request for the EditarSchool, receives a modified SchoolModel object as a parameter
        [HttpPost]
        public ActionResult EditarSchool(SchoolModel school)
        {
            try
            {
                var schoolHandler = new SchoolHandler();
                schoolHandler.EditarSchool(school);
                return RedirectToAction("Index", "School");
            }
            catch 
            {
                ViewBag.Message = "Ups, something went wrong while trying to edit a school. Please try again";
                return View();
            }
        }

        // Handles the GET request for the BorrarSchool, receives an id param to identify the school to delete
        [HttpGet]
        public ActionResult BorrarSchool(int? identificador)
        {
            ActionResult vista;
            try
            {
                var schoolHandler = new SchoolHandler();
                var school = schoolHandler.ObtenerSchools().Find(model => model.Id == identificador);
                if(school == null)
                {
                    vista = RedirectToAction("Index");
                } 
                else
                {
                    vista = View(school);
                }
            }
            catch 
            {
                vista = RedirectToAction("Index");
            }
            return vista;
        }

        // Handles the POST request for the BorrarSchool, receives a SchoolModel object as a param
        [HttpPost]
        public ActionResult BorrarSchool(SchoolModel school)
        {
            try
            {
                var schoolHandler = new SchoolHandler();
                schoolHandler.BorrarSchool(school);
                return RedirectToAction("Index", "School");
            }
            catch 
            {
                return View();
            }
        }
    }
}
