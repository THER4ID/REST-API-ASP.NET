using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;

namespace simoncharlos.DAO
{
    public static class SqlTools
    {

        public static string GetSafeString(string name, MySqlDataReader reader)
        {
            try
            {

            
            if( reader[name].GetType() != typeof(DBNull)){
                return reader.GetString(name);
            }
            else
            {
                return "";
            }
            }
            catch (IndexOutOfRangeException)
            {
                return "";
            }
        }

        public static int GetSafeInt(string name, MySqlDataReader reader)
        {
            try
            {


                if (reader[name].GetType() != typeof(DBNull))
                {
                    return reader.GetInt32(name);
                }
                else
                {
                    return 0;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }

        public static double GetSafeDouble(string name, MySqlDataReader reader)
        {
            try
            {


                if (reader[name].GetType() != typeof(DBNull))
                {
                    return reader.GetDouble(name);
                }
                else
                {
                    return 0;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }

        public static DateTime GetSafeDateTime(string name, MySqlDataReader reader)
        {
            try
            {


                if (reader[name].GetType() != typeof(DBNull))
                {
                    return reader.GetDateTime(name);
                }
                else
                {
                    return DateTime.Now;
                }
            }
            catch 
            {

                return DateTime.Now;
            }
        }

        public static Guid GetSafeGuid(string name, MySqlDataReader reader)
        {
            try
            {
                Guid guid;

                if (reader[name].GetType() != typeof(DBNull))
                {
                    if (Guid.TryParse(reader.GetString(name), out guid)){
                        return guid;
                    }
                    else
                    {
                        return Guid.Empty;
                    }
                }
                else
                {
                    return Guid.Empty;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return Guid.Empty;
            }
        }


    }
}