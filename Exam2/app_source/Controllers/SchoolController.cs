using Microsoft.AspNetCore.Mvc;
using app.Handlers;
using app.Models;
using laboratorio6.Handlers;

namespace app.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            SchoolHandler schoolHandler = new SchoolHandler();
            var schools = schoolHandler.ObtenerSchools();
            ViewBag.MainTitle = "Lista de Escuelas";
            return View(schools);
        }

        [HttpGet]
        public ActionResult CrearSchool()
        {
            return View();
        }

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
                        ViewBag.Message = "La escuela " + school.Nombre + " fue creada con éxito. ";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no se pudo crear la escuela";
                return View();
            }
        }

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
                vista = RedirectToAction("Index");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult EditarSchool(SchoolModel school)
        {
            try
            {
                var schoolHandler = new SchoolHandler();
                schoolHandler.EditarSchool(school);
                return RedirectToAction("Index", "School");
            }
            catch { return View(); }
        }

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
