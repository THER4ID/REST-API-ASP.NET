using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using simoncharlos.DAO;
using simoncharlos.Model;

namespace Produits.Controllers
{
    public class ProduitsController : Controller
    {
        // GET: Produits
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produits/Details/5
        public string Details(int id)
        {
            Produit p = ProduitDAO.getProduit(id);

            if (p.ID != 0)
            {
                return JsonConvert.SerializeObject(p);
            }

            return JsonConvert.SerializeObject("Erreur le produit en question n'existe pas");
        }

        // GET: Produits/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Produits/Create
        [HttpPost]
        public string Create()
        {
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            Produit plan = null;
            try
            {
                // assuming JSON.net/Newtonsoft library from http://json.codeplex.com/
                plan = JsonConvert.DeserializeObject<Produit>(json);
                if (plan == null)
                {
                    return "Erreur";
                }
                return JsonConvert.SerializeObject(plan);
            }
            catch (Exception ex)
            {
                // Try and handle malformed POST body
                return "Erreur";
            }
        
        }

        // GET: Produits/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produits/Edit/5
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

        //// GET: Produits/Delete/5
        //public string Delete(int id)
        //{
        //    return "pas implémenté";
        //}

        // DELETE : Produits/Delete/5
        [HttpDelete]
        public string Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here

                return "Réussi";
            }
            catch
            {
                return "Erreur : Impossible de supprimer";
            }
        }
    }
}
