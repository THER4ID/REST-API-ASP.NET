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
        public string Index()
        {
            return JsonConvert.SerializeObject(ProduitDAO.getProduits());
        }

        //GET: Produits/Range/1/5
        public string Range(int id, int id_max)
        {
            List<Produit> p = ProduitDAO.getProduits(id, id_max);

            if (p.Count != 0)
            {
                return JsonConvert.SerializeObject(p);
            }

            return JsonConvert.SerializeObject("Erreur les produits en question n'existent pas");
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
                plan = JsonConvert.DeserializeObject<Produit>(json);
                if (plan == null)
                {
                    return "Erreur";
                }

                long result = ProduitDAO.insertProduit(plan);

                if (result == 0)
                {
                    return "Erreur";
                }
                else
                {
                    plan.ID = (int)result;
                    return JsonConvert.SerializeObject(plan);
                }

                
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
        public string Edit(int id)
        {
            try
            {
                // TODO: Add update logic here

                return "non implémenté";
            }
            catch
            {
                return "Erreur";
            }
        }

        //// GET: Produits/Delete/5
        //public string Delete(int id)
        //{
        //    return "pas implémenté";
        //}

        // DELETE : Produits/Delete/5
        [HttpDelete]
        public string Delete(string id)
        {
            int id_real;
            if(!Int32.TryParse(id, out id_real)){
                ProduitDAO.deleteParNomProduit(id);
            }
            else
            {
                ProduitDAO.deleteParID(id_real);
            }

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
