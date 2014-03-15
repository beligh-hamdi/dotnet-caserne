using Caserne.Domaine.Entities;
using Caserne.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Caserne.MVC.Controllers
{
    public class SoldatController : Controller
    {

        private ISoldatService soldatService;
        private IAvionService avionService;
        
        public SoldatController()
        {
            this.soldatService = new SoldatService();
            this.avionService = new AvionService();
        }
        
        
        
        //
        // GET: /Soldat/

        public ActionResult Index()
        {
            var soldats = soldatService.GetSoldats();

            ViewBag.pilotes = soldatService.GetPilotes();
            ViewBag.fantassins = soldatService.GetFantassins();

            ViewBag.NbrPilotes = soldatService.GetPilotes().Count();
            ViewBag.NbrFantassins = soldatService.GetFantassins().Count();

            return View(soldats);
        }

        //
        // GET: /Soldat/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Soldat/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Soldat/Create

        [HttpPost]
        public ActionResult Create(Soldat soldat, FormCollection collection)
        {
            
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(soldat);
                }

                string isFantassin = Convert.ToString(collection["isFantassin"]);

                TempData["DateInscription"] = soldat.DateInscription;
                TempData["Nom"] = soldat.Nom;
                TempData["Prenom"] = soldat.Prenom;
                TempData["Reserve"] = soldat.Reserve;


                if (isFantassin == "true")
                {
                    return RedirectToAction("CreateFantassin");
                }
                if (isFantassin == "false")
                {
                    return RedirectToAction("CreatePilote");
                }
            
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            

        }

        //
        // GET: /Soldat/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Soldat/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Soldat/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Soldat/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateFantassin()
        {
            return View();
        }

        public ActionResult CreatePilote()
        {

            var avions = avionService.GetAvions();
            ViewBag.Avions = new SelectList(avions, "Id", "Modele"); 
   
            return View();
        }

        [HttpPost]
        public ActionResult CreateFantassin(Fantassin f)
        {

            
            /*
            string fff = "{DateInscription=" + date.ToString() + " ,Nom= " + n.ToString() + ",Prenom="
                 + p.ToString() + ",Reserve= " + r.ToString() + ",Arme="
                 + f.Arme + " , NbMunition" + f.NbMunition.ToString() + "}";

            return Content(fff);
            */
           
            DateTime date = (DateTime)TempData["DateInscription"];
            string p = TempData["Prenom"] as string;
            string n = TempData["Nom"] as string;
            bool r = (bool)TempData["Reserve"];
            
            Fantassin fn = new Fantassin
            {
                DateInscription = date,
                Nom = n,
                Prenom = p,
                Reserve = r,
                Arme = f.Arme,
                NbMunition = (int) f.NbMunition
            };
    

            soldatService.CreateFantassin(fn);
            soldatService.SaveSoldat();

            return RedirectToAction("Index");


        }


        [HttpPost]
        public ActionResult CreatePilote(Pilote pilote)
        {
                    

            DateTime date   = (DateTime)TempData["DateInscription"];
            string p        = TempData["Prenom"] as string;
            string n        = TempData["Nom"] as string;
            bool r          = (bool)TempData["Reserve"];

            Pilote pn = new Pilote
            {
                DateInscription = date,
                Nom = n,
                Prenom = p,
                Reserve = r,
                NbHeuresDeVol = (int) pilote.NbHeuresDeVol,
                AvionId = (int) pilote.AvionId,
                Avion = pilote.Avion
            };

            soldatService.CreatePilote(pn);
            soldatService.SaveSoldat();

            return RedirectToAction("Index");


        }





    }
}
