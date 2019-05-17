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
    public class RoomReservationDB
    {
        //Permet de lister toutes les réservations
        public static List<RoomReservation> GetAllRoomReservation()
        {
            List<RoomReservation> results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from RoomReservation";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<RoomReservation>();

                            RoomReservation roomReservation = new RoomReservation();

                            roomReservation.IdRoomReservation = (int)dr["IdRoomReservation"];
                            roomReservation.IdReservation = (int)dr["IdReservation"];
                            roomReservation.IdRoom = (int)dr["IdRoom"];
                            roomReservation.PriceIncreased = (int)dr["PriceIncreased"]; 


                            results.Add(roomReservation);

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

        //Permet de lister toutes les réervations
        public static RoomReservation GetRoomReservationByIdRoomIdReservation(int idRoom, int idReservation)
        {
            RoomReservation results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from RoomReservation WHERE IdRoom = @idRoom AND IdReservation = @idReservation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idRoom", idRoom);
                    cmd.Parameters.AddWithValue("@idReservation", idReservation);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new RoomReservation();
                            

                            results.IdRoomReservation = (int)dr["IdRoomReservation"];
                            results.IdReservation = (int)dr["IdReservation"];
                            results.IdRoom = (int)dr["IdRoom"];
                            results.PriceIncreased = (int)dr["PriceIncreased"];
                            

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

        //Ajout d'une réservation d'une chambre 
        public static void NewRoomReservation(int IdReservation, int IdRoom, int PriceIncreased )
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into RoomReservation(IdReservation, IdRoom, PriceIncreased) values (@IdReservation, @IdRoom, @PriceIncreased)";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@IdReservation", IdReservation);
                    cmd.Parameters.AddWithValue("@IdRoom", IdRoom); 
                    cmd.Parameters.AddWithValue("@PriceIncreased", PriceIncreased);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                    
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // On supprime une réservation si le client se désiste
        public static void DeleteReservationRoom(int IdReservation)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;
            try
            {

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM RoomReservation WHERE IdReservation = @IdReservation";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@IdReservation", IdReservation);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
