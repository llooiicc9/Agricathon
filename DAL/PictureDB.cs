using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PictureDB
    {
        //Permet de lister toutes les photos
        public static List<Picture> getAllPicture()
        {
            List<Picture> results = null;
            
            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Picture";
                    SqlCommand cmd = new SqlCommand(query, cn);               

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Picture>();

                            Picture picture = new Picture();

                            picture.IdPicture = (int)dr["IdPicture"];
                            picture.Url = (String)dr["Url"];
                            picture.IdRoom = (int)dr["IdRoom"];
                            
                            results.Add(picture);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }
       
        //Permet de lister toutes les photos selon un id
        public static List<Picture> getAllPictureByIdroom(int idRoom)
        {
            List<Picture> results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Picture WHERE IdRoom = @idRoom";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idRoom", idRoom);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Picture>();

                            Picture picture = new Picture();

                            picture.IdPicture = (int)dr["IdPicture"];
                            picture.Url = (String)dr["Url"];
                            picture.IdRoom = (int)dr["IdRoom"];

                            results.Add(picture);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        //Sélectionne une photo de chambre selon un id
        public static Picture getOnePictureByIdroom(int idRoom)
        {
            Picture results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 1 * FROM Picture WHERE IdRoom = @idRoom";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idRoom", idRoom);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            if (results == null)
                                results = new Picture();

                            results.IdPicture = (int)dr["IdPicture"];
                            results.Url = (String)dr["Url"];
                            results.IdRoom = (int)dr["IdRoom"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        
    }
}
