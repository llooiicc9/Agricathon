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
    public class ReservationDB
    {
        //Permet de lister toutes les reservations
        public static List<Reservation> GetAllReservation()
        {
            List<Reservation> results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Reservation";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Reservation>();

                            Reservation reservation = new Reservation();

                            reservation.IdReservation = (int)dr["IdReservation"];
                            reservation.ClientLastName = (String)dr["ClientLastName"];
                            reservation.ClientFirstName = (String)dr["ClientFirstName"];
                            reservation.CheckIn = (DateTime)dr["CheckIn"];
                            reservation.CheckOut = (DateTime)dr["CheckOut"];

                            results.Add(reservation);                        
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

        //Permet de lister toutes les reservation libre entre deux dates
        public static Reservation GetReservationByIdName(int idReservation, String FirstName, String LastName)
        {
            Reservation results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Reservation WHERE ClientLastName = @LastName AND ClientFirstName = @FirstName AND idReservation = @idReservation";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@idReservation", idReservation);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new Reservation();

                            results.IdReservation = (int)dr["IdReservation"];
                            results.ClientLastName = (String)dr["ClientLastName"];
                            results.ClientFirstName = (String)dr["ClientFirstName"];
                            results.CheckIn = (DateTime)dr["CheckIn"];
                            results.CheckOut = (DateTime)dr["CheckOut"];
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
        
        //Permet de crée une nouvelle réservation en lui indiquand le nom et prénom du client ainsi que les dates du séjour
        public static int NewReservation(String ClientLastName, String ClientFirstName, DateTime CheckIn, DateTime CheckOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;
            int idResultat =0;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Reservation(ClientLastName, ClientFirstName, CheckIn, CheckOut) output inserted.IdReservation values(@ClientLastName, @ClientFirstName, @CheckIn, @CheckOut)";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@ClientLastName", ClientLastName);
                    cmd.Parameters.AddWithValue("@ClientFirstName", ClientFirstName);
                    cmd.Parameters.AddWithValue("@CheckIn", CheckIn);
                    cmd.Parameters.AddWithValue("@CheckOut", CheckOut);

                    cn.Open();

                    idResultat = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return idResultat;
          
        }

        // On supprime une réservation si le client se désiste
        public static void DeleteReservation(int IdReservation)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;
            try
            {

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Reservation WHERE IdReservation = @IdReservation";

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
