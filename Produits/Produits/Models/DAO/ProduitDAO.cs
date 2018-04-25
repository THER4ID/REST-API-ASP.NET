using System;
using System.Collections.Generic;
using simoncharlos.DAO;
using MySql.Data.MySqlClient;
using simoncharlos.Model;

namespace simoncharlos.DAO
{
    public class ProduitDAO
    {
        public static Produit getProduit(int id)
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
                catch
                {
                    return null;
                }
            }

            dr.Close();
            cnx.Close();

            return produit;
        }
        public static List<Produit> getProduits()
        {
            var listeProduit = new List<Produit>();
            //Taux taux;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = Config.connectStr; //"Server=127.0.0.1;Uid=root;Pwd=root;Database=magasin;";


            cnx.Open();

            MySqlCommand cmd = new MySqlCommand(); //Ou : MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "select * from Produits";
            cmd.Connection = cnx;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var produit = new Produit();
                produit.ID = dr.GetInt32("id");
                produit.NomProduit = SqlTools.GetSafeString("NomProduit", dr);

                produit.Numero = SqlTools.GetSafeString("numero", dr);
                try
                {
                    produit.Prix = dr.GetDouble("Prix");
                    produit.Quantite = dr.GetInt32("quantite");
                }
                catch { }

                listeProduit.Add(produit);
            }

            dr.Close();
            cnx.Close();

            return listeProduit;
        }
        //Méthode en dev
        public static List<Produit> getProduits(int id_min, int id_max)
        {
            var listeProduit = new List<Produit>();
            //Taux taux;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = Config.connectStr; //"Server=127.0.0.1;Uid=root;Pwd=root;Database=magasin;";


            cnx.Open();

            MySqlCommand cmd = new MySqlCommand(); //Ou : MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "select * from Produits where id between @id and @max_id";
            cmd.Connection = cnx;
            cmd.Parameters.AddWithValue("@id", id_min);
            cmd.Parameters.AddWithValue("@max_id", id_max);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var produit = new Produit();
                produit.ID = dr.GetInt32("id");
                produit.NomProduit = SqlTools.GetSafeString("NomProduit", dr);

                produit.Numero = SqlTools.GetSafeString("numero", dr);
                try
                {
                    produit.Prix = dr.GetDouble("Prix");
                    produit.Quantite = dr.GetInt32("quantite");
                }
                catch { }

                listeProduit.Add(produit);
            }

            dr.Close();
            cnx.Close();

            return listeProduit;
        }

        public static long insertProduit(Produit produit)
        {
            try
            {
                MySqlConnection cnx = new MySqlConnection();
                cnx.ConnectionString = Config.connectStr;

                cnx.Open();

                MySqlCommand cmd = new MySqlCommand(); //Ou : MySqlCommand cmd = cnx.CreateCommand();
                cmd.CommandText = "INSERT INTO produits (prix,numero,nomProduit,quantite) VALUES (@prix,@numero,@nomProduit,@quantite);";

                cmd.Parameters.AddWithValue("@prix", produit.Prix);
                cmd.Parameters.AddWithValue("@numero", produit.Numero);
                cmd.Parameters.AddWithValue("@nomProduit", produit.NomProduit);
                cmd.Parameters.AddWithValue("@quantite", produit.Quantite);

                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
                long returnvalue = cmd.LastInsertedId;
                cnx.Close();
                return returnvalue;



            }
            catch
            {
                return 0;
            }

        }

        //public static Produit getProduitRecherche(string recherche)
        //{
        //    var produit = new Produit();
        //    //Taux taux;
        //    MySqlConnection cnx = new MySqlConnection();
        //    cnx.ConnectionString = Config.connectStr; //"Server=127.0.0.1;Uid=root;Pwd=root;Database=magasin;";


        //    cnx.Open();

        //    MySqlCommand cmd = new MySqlCommand(); //Ou : MySqlCommand cmd = cnx.CreateCommand();
        //    cmd.CommandText = "select * from Produits where id=@id";
        //    cmd.Connection = cnx;
        //    cmd.Parameters.AddWithValue("@id", id);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        produit.ID = dr.GetInt32("id");
        //        produit.NomProduit = SqlTools.GetSafeString("NomProduit", dr);

        //        produit.Numero = SqlTools.GetSafeString("numero", dr);
        //        try
        //        {
        //            produit.Prix = dr.GetDouble("Prix");
        //            produit.Quantite = dr.GetInt32("quantite");
        //        }
        //        catch { }
        //    }

        //    dr.Close();
        //    cnx.Close();

        //    return produit;
        //}

        public static bool deleteParID(int id)
        {


            try
            {
                MySqlConnection cnx = new MySqlConnection();
                cnx.ConnectionString = Config.connectStr;

                cnx.Open();

                MySqlCommand cmd = new MySqlCommand(); //Ou : MySqlCommand cmd = cnx.CreateCommand();
                cmd.CommandText = "DELETE FROM produits WHERE ID = @id;";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.Connection = cnx;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool deleteParNomProduit(string nomProduit)
        {


            try
            {
                MySqlConnection cnx = new MySqlConnection();
                cnx.ConnectionString = Config.connectStr;

                cnx.Open();

                MySqlCommand cmd = new MySqlCommand(); //Ou : MySqlCommand cmd = cnx.CreateCommand();
                cmd.CommandText = "DELETE FROM produits WHERE nomProduit = @nomProduit;";
                cmd.Parameters.AddWithValue("@nomProduit", nomProduit);

                cmd.Connection = cnx;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }



    }
}