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
    public class RoomDB
    {
        //Permet de lister toutes les chambres de tout les hotels
        public static List<Room> GetAllRoom()
        {
            List<Room> results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Room";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Room>();

                            Room room = new Room();

                            room.IdRoom = (int)dr["IdRoom"];
                            room.Number = (int)dr["Number"];
                            room.Description = (String)dr["Description"];
                            room.Type = (int)dr["Type"];
                            room.Price = (Decimal)dr["Price"];
                            room.HasTV = (Boolean)dr["HasTV"];
                            room.HasHairDryer = (Boolean)dr["HasHairDryer"];
                            room.IdHotel = (int)dr["IdHotel"];
                 
                            results.Add(room);
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

        //Choisir une chambre par rapport a des dates
        public static List<Room> GetRoomByDate(DateTime checkInDesired, DateTime checkOutDesired, String location, int nbCustomer)
        {
            List<Room> results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT *"+
                                    " FROM Room as Ro, Hotel as Ho" +
                                    " WHERE Ro.IdRoom NOT IN" +
                                    " (" +
                                      " SELECT Ro.IdRoom FROM Room as Ro, RoomReservation as Rr, Reservation as Re" +
                                        " WHERE (Ro.IdRoom=Rr.idRoom AND Rr.idReservation=Re.IdReservation )" +
                                        " AND ((Re.CheckIn <= @checkInDerired AND Re.CheckOut >= @checkInDerired)" +
                                        " OR(Re.CheckIn < @checkOutDesired AND Re.CheckOut  >= @checkOutDesired)" +
                                        " OR(@checkInDerired <= Re.CheckIn AND @checkOutDesired >= Re.CheckIn))" +
                                    " ) AND Ho.IdHotel= Ro.IdHotel AND Ho.Location = @location AND Ro.Type >= @nbCustomer ";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@checkInDerired", checkInDesired);
                    cmd.Parameters.AddWithValue("@checkOutDesired", checkOutDesired);
                    cmd.Parameters.AddWithValue("@location", location);
                    cmd.Parameters.AddWithValue("@nbCustomer", nbCustomer);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Room>();

                            Room room = new Room();

                            room.IdRoom = (int)dr["IdRoom"];
                            room.Number = (int)dr["Number"];
                            room.Description = (String)dr["Description"];
                            room.Type = (int)dr["Type"];
                            room.Price = (Decimal)dr["Price"];
                            room.HasTV = (Boolean)dr["HasTV"];
                            room.HasHairDryer = (Boolean)dr["HasHairDryer"];
                            room.IdHotel = (int)dr["IdHotel"];
                            
                            results.Add(room);
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

        //Choisir une chambre par rapport a des dates
        public static List<Room> GetRoomByDateRequestAdd(DateTime checkInDesired, DateTime checkOutDesired, String location, int nbCustomer, String requestAdd)
        {
            List<Room> results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT *" +
                                    " FROM Room as Ro, Hotel as Ho" +
                                    " WHERE Ro.IdRoom NOT IN" +
                                    " (" +
                                      " SELECT Ro.IdRoom FROM Room as Ro, RoomReservation as Rr, Reservation as Re" +
                                        " WHERE (Ro.IdRoom=Rr.idRoom AND Rr.idReservation=Re.IdReservation )" +
                                        " AND ((Re.CheckIn <= @checkInDerired AND Re.CheckOut >= @checkInDerired)" +
                                        " OR(Re.CheckIn < @checkOutDesired AND Re.CheckOut  >= @checkOutDesired)" +
                                        " OR(@checkInDerired <= Re.CheckIn AND @checkOutDesired >= Re.CheckIn))" +
                                    " ) AND Ho.IdHotel= Ro.IdHotel AND Ho.Location = @location AND Ro.Type >= @nbCustomer ";
                    query += requestAdd;

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@checkInDerired", checkInDesired);
                    cmd.Parameters.AddWithValue("@checkOutDesired", checkOutDesired);
                    cmd.Parameters.AddWithValue("@location", location);
                    cmd.Parameters.AddWithValue("@nbCustomer", nbCustomer);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Room>();

                            Room room = new Room();

                            room.IdRoom = (int)dr["IdRoom"];
                            room.Number = (int)dr["Number"];
                            room.Description = (String)dr["Description"];
                            room.Type = (int)dr["Type"];
                            room.Price = (Decimal)dr["Price"];
                            room.HasTV = (Boolean)dr["HasTV"];
                            room.HasHairDryer = (Boolean)dr["HasHairDryer"];
                            room.IdHotel = (int)dr["IdHotel"];

                            results.Add(room);
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

        //Choisir une chambre par rapport son ID
        public static Room GetRoomById(int IdRoom)
        {
            Room results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = " SELECT * FROM Room WHERE IdRoom = @IdRoom ";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@IdRoom", IdRoom);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new Room();

                            results.IdRoom = (int)dr["IdRoom"];
                            results.Number = (int)dr["Number"];
                            results.Description = (String)dr["Description"];
                            results.Type = (int)dr["Type"];
                            results.Price = (Decimal)dr["Price"];
                            results.HasTV = (Boolean)dr["HasTV"];
                            results.HasHairDryer = (Boolean)dr["HasHairDryer"];
                            results.IdHotel = (int)dr["IdHotel"];

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
        //Choisir une chambre par rapport a idHotel
        public static int countRoomByIdHotel(int IdHotel, DateTime checkInDesired, DateTime checkOutDesired, String location, int nbCustomer)
        {
            
            nbCustomer = 1;
            

            double results = 0;
            double nbRoomReserved = 0;
            double TotalRooms = 0;
            double AvailableRooms = 0;

            int priceIncreased = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = " SELECT count(*) as resu FROM Room as Ro WHERE IdHotel = @IdHotel ";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@IdHotel", IdHotel);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            TotalRooms = (int)dr["resu"];

                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

           try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT count(*) as resu" +
                                    " FROM Room as Ro, Hotel as Ho" +
                                    " WHERE Ro.IdRoom NOT IN" +
                                    " (" +
                                      " SELECT Ro.IdRoom FROM Room as Ro, RoomReservation as Rr, Reservation as Re" +
                                        " WHERE (Ro.IdRoom=Rr.idRoom AND Rr.idReservation=Re.IdReservation )" +
                                        " AND ((Re.CheckIn <= @checkInDerired AND Re.CheckOut >= @checkInDerired)" +
                                        " OR(Re.CheckIn < @checkOutDesired AND Re.CheckOut  >= @checkOutDesired)" +
                                        " OR(@checkInDerired <= Re.CheckIn AND @checkOutDesired >= Re.CheckIn))" +
                                    " ) AND Ho.IdHotel= Ro.IdHotel AND Ho.Location = @location AND Ro.Type >= @nbCustomer AND Ro.IdHotel = @IdHotel ";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@checkInDerired", checkInDesired);
                    cmd.Parameters.AddWithValue("@checkOutDesired", checkOutDesired);
                    cmd.Parameters.AddWithValue("@location", location);
                    cmd.Parameters.AddWithValue("@nbCustomer", nbCustomer);
                    cmd.Parameters.AddWithValue("@IdHotel", IdHotel);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            AvailableRooms = (int)dr["resu"];

                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            nbRoomReserved = TotalRooms - AvailableRooms;
            results = nbRoomReserved / TotalRooms ;

            if(results>0.7)
                priceIncreased = 1;

            return priceIncreased;
        }

        //Choisir une liste de chambre par rapport l ID de la reservation
        public static List<Room> GetRoomByIdReservation(int IdReservation)
        {
            List<Room> results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = " SELECT * FROM Room as Ro, RoomReservation as Rr WHERE Ro.IdRoom = Rr.IdRoom AND Rr.IdReservation = @IdReservation ";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@IdReservation", IdReservation);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Room>();

                            Room room = new Room();

                            room.IdRoom = (int)dr["IdRoom"];
                            room.Number = (int)dr["Number"];
                            room.Description = (String)dr["Description"];
                            room.Type = (int)dr["Type"];
                            room.Price = (Decimal)dr["Price"];
                            room.HasTV = (Boolean)dr["HasTV"];
                            room.HasHairDryer = (Boolean)dr["HasHairDryer"];
                            room.IdHotel = (int)dr["IdHotel"];

                            results.Add(room);
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

        //Permet de supprimer la TV si pas hasard elle n'est plus fonctionnel
        public static void ModifiyHasTV(Boolean HasTv, int IdRoomDesired)
        {            

            string connectionString = ConfigurationManager.ConnectionStrings["DB_Python_Booking"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Room SET HasTV = @HasTv WHERE IdRoom = @IdRoomDesired";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@HasTv", HasTv);
                    cmd.Parameters.AddWithValue("@IdRoomDesired", IdRoomDesired);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        //Permet de modifier la requete en cas de recherche avancée
        public static String RequestEdit(int hasHairDryer, int hasTv, int hasWifi, int hasParking)
        {
            string requestAdd = " ";

            if (hasHairDryer != 0)
            {
                if (hasHairDryer == 1)
                    requestAdd += " AND Ro.HasHairDryer = 'true' ";
                else
                    requestAdd += " AND Ro.HasHairDryer = 'false' ";
            }
            if (hasTv != 0)
            {
                if (hasTv == 1)
                    requestAdd += " AND Ro.HasTV = 'true' ";
                else
                    requestAdd += " AND Ro.HasTV = 'false' ";
            }
            if (hasWifi != 0)
            {
                if (hasWifi == 1)
                    requestAdd += " AND Ho.HasWifi = 'true' ";
                else
                    requestAdd += " AND Ho.HasWifi = 'false' ";
            }
            if (hasParking != 0)
            {
                if (hasParking == 1)
                    requestAdd += " AND Ho.HasParking = 'true' ";
                else
                    requestAdd += " AND Ho.HasParking = 'false' ";
            }

            return requestAdd;
        }
    }
}
