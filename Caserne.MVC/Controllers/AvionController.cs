using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Caserne.Service;
using Caserne.Domaine;
using Caserne.Domaine.Entities;

namespace Caserne.MVC.Controllers
{
    public class AvionController : Controller
    {

        private IAvionService avionService;
        
        public AvionController()
        {
            this.avionService = new AvionService();
        }
        
        //
        // GET: /Avion/

        public ActionResult Index()
        {

            var avions = avionService.GetAvions();

            ViewBag.NbrAvions = avionService.GetNbAvion();
            ViewBag.QueryAvions = avionService.QueryAvions();
            return View(avions);
        }

        //
        // GET: /Avion/Details/5

        public ActionResult Details(int id)
        {
            var av = avionService.GetAvion(id);
            return View(av);
        }

        //
        // GET: /Avion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Avion/Create

        [HttpPost]
        public ActionResult Create(Avion av, FormCollection collection)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(av);
                }

                avionService.CreateAvion(av);
                avionService.SaveAvion();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Avion/Edit/5

        public ActionResult Edit(int id)
        {
            var av = avionService.GetAvion(id);
            return View(av);
        }

        //
        // POST: /Avion/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, Avion av)
        {
            try
            {
             
                if (!ModelState.IsValid)
                {
                    return View();
                }

                avionService.UpdateAvionDetached(av);
                avionService.SaveAvion();

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Avion/Delete/5

        public ActionResult Delete(int id)
        {
            var av = avionService.GetAvion(id);
            return View(av);
 
        }

        //
        // POST: /Avion/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                avionService.DeleteAvion(id);
                avionService.SaveAvion();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
