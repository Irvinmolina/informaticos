
using Inv_Informatico.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inv_Informatico.Web.Controllers
{
    public class HardwareController : Controller
    {
        // GET: Hardware
        public ActionResult Index()
        {
            var hardwareBL = new HardwareBL();
            var listadeHardware = hardwareBL.ObtenerHardware();

            return View(listadeHardware);
        }
    }
}   