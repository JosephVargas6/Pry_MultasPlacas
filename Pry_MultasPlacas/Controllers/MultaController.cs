using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pry_MultasPlacas.Controllers
{
    public class MultaController : Controller
    {
        // GET: Multa
        [AllowAnonymous]
        public ActionResult Index()
        {

            return View();
        }
    }
}