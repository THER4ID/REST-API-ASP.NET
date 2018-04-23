using System;
using System.Collections.Generic;
using simoncharlos.DAO;
using MySql.Data.MySqlClient;
using simoncharlos.Model;

namespace simoncharlos.DAO
{
    public class ProduitDAO
    {


        public static Produit getProduit (int id)
        {
            var produit = new Produit();
            //Taux taux;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = Config.connectStr; //"Server=127.0.0.1;Uid=root;Pwd=root;Database=magasin;";


            cnx.Open();

            MySqlCommand cmd = new MySqlCommand(); //Ou : MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "select * from Produits where id=@id";
            cmd.Connection = cnx;
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) { 
                produit.ID = dr.GetInt32("id");
                produit.NomProduit = SqlTools.GetSafeString("NomProduit", dr);

                produit.Numero = SqlTools.GetSafeString("numero",dr);
                try
                {
                    produit.Prix = dr.GetDouble("Prix");
                    produit.Quantite = dr.GetInt32("quantite");
                }
                catch{}
            }

            dr.Close();
            cnx.Close();

            return produit;
        }

        //Méthode en dev
        public static Produit getProduits(int id_min, int id_max)
        {
            var produit = new Produit();
            //Taux taux;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = Config.connectStr; //"Server=127.0.0.1;Uid=root;Pwd=root;Database=magasin;";


            cnx.Open();

            MySqlCommand cmd = new MySqlCommand(); //Ou : MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "select * from Produits where id=@id";
            cmd.Connection = cnx;
            //cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                produit.ID = dr.GetInt32("id");
                produit.NomProduit = SqlTools.GetSafeString("NomProduit", dr);

                produit.Numero = SqlTools.GetSafeString("numero", dr);
                try
                {
                    produit.Prix = dr.GetDouble("Prix");
                    produit.Quantite = dr.GetInt32("quantite");
                }
                catch { }
            }

            dr.Close();
            cnx.Close();

            return produit;
        }

        public static Produit getProduitRecherche(int id)
        {
            var produit = new Produit();
            //Taux taux;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = Config.connectStr; //"Server=127.0.0.1;Uid=root;Pwd=root;Database=magasin;";


            cnx.Open();

            MySqlCommand cmd = new MySqlCommand(); //Ou : MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "select * from Produits where id=@id";
            cmd.Connection = cnx;
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                produit.ID = dr.GetInt32("id");
                produit.NomProduit = SqlTools.GetSafeString("NomProduit", dr);

                produit.Numero = SqlTools.GetSafeString("numero", dr);
                try
                {
                    produit.Prix = dr.GetDouble("Prix");
                    produit.Quantite = dr.GetInt32("quantite");
                }
                catch { }
            }

            dr.Close();
            cnx.Close();

            return produit;
        }




    }
}