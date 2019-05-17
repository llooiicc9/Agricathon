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
    public class HotelDB
    {
        //Permet de lister tous les hotels
        public static List<Hotel> GetAllHotel()
        {
            List<Hotel> results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Hotel";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Hotel>();

                            Hotel hotel = new Hotel();

                            hotel.IdHotel = (int)dr["IdHotel"];                            
                            hotel.Description = (String)dr["Description"];
                            hotel.Location = (String)dr["Location"];
                            hotel.Category = (int)dr["Category"];
                            hotel.HasWifi = (Boolean)dr["HasWifi"];
                            hotel.HasParking = (Boolean)dr["HasParking"];
                            
                            //Test si les champs qui peuvent être null ne le sont pas
                            if (dr["Phone"] != null)
                                hotel.Phone = (String)dr["Phone"];
                            if (dr["Email"] != null)
                                hotel.Email = (String)dr["Email"];
                            if (dr["Website"] != null)
                                hotel.Website = (String)dr["Website"];

                            results.Add(hotel);

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

        //Permet de lister un hotel selon son id
        public static Hotel GetHotelById(int idHotelDesired)
        {
            Hotel results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Hotel WHERE IdHotel = @idHotelDesired";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@idHotelDesired", idHotelDesired);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new Hotel();


                            results.IdHotel = (int)dr["IdHotel"];
                            results.Description = (String)dr["Description"];
                            results.Name = (String)dr["Name"];
                            results.Location = (String)dr["Location"];
                            results.Category = (int)dr["Category"];
                            results.HasWifi = (Boolean)dr["HasWifi"];
                            results.HasParking = (Boolean)dr["HasParking"];

                            //Test si les champs qui peuvent être null ne le sont pas
                            if (dr["Phone"] != null)
                                results.Phone = (String)dr["Phone"];
                            if (dr["Email"] != null)
                                results.Email = (String)dr["Email"];
                            if (dr["Website"] != null)
                                results.Website = (String)dr["Website"];

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
