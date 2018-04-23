using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace simoncharlos.Model
{
    public class Produit
    {
            int id;
            double prix;
            string numero;
            string nomProduit;
            int quantite;


            public Produit() : base() { }


            public int ID { get => id; set => id = value; }
            public double Prix { get => prix; set => prix = value; }
            public string Numero { get => numero; set => numero = value; }
            public string NomProduit { get => nomProduit; set => nomProduit = value; }
            public int Quantite { get => quantite; set => quantite = value; }


            public override string ToString()
            {
                return ID + ";" + Prix + ";" + Numero + ";" + NomProduit + ";" + Quantite + ";";
            }
        }
    }

