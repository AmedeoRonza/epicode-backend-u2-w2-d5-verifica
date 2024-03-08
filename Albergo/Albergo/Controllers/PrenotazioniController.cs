using Albergo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Albergo.Controllers
{
    [Authorize]
    public class PrenotazioniController : Controller
    {
        // GET: Prenotazioni
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InsertPrenotazioni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertPrenotazioni(Prenotazioni p)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = "INSERT INTO Prenotazioni (DataPrenotazione, DataCheckIn, DataCheckOut, Anticipo, Nome, Cognome, Prezzo, IdCliente, IdCamera, IdServizio) VALUES ( @DataPrenotazione, @DataCheckIn, @DataCheckOut, @Anticipo, @Nome, @Cognome, @Prezzo, @IdCliente, @IdCamera, @IdServizio )";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@DataPrenotazione", p.DataPrenotazione);
                cmd.Parameters.AddWithValue("@DataCheckIn", p.DataCheckIn);
                cmd.Parameters.AddWithValue("@DataCheckOut", p.DataCheckOut);
                cmd.Parameters.AddWithValue("@Anticipo", p.Anticipo); // ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Nome", p.Nome);
                cmd.Parameters.AddWithValue("@Cognome", p.Cognome);
                cmd.Parameters.AddWithValue("@Prezzo", p.Prezzo);
                cmd.Parameters.AddWithValue("@IdCliente", p.IdCliente);
                cmd.Parameters.AddWithValue("@IdCamera", p.IdCamera);
                cmd.Parameters.AddWithValue("@IdServizio", p.IdServizio != 0 ? p.IdServizio : (object)DBNull.Value);



                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return View();
        }
        public ActionResult Prenotazioni()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            List<Prenotazioni> listaPrenotazioni = new List<Prenotazioni>();

            try
            {
                conn.Open();
                string query = "SELECT * FROM Prenotazioni";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Prenotazioni prenotazione = new Prenotazioni();
                    prenotazione.IdPrenotazione = Convert.ToInt32(reader["IdPrenotazione"]);
                    prenotazione.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);
                    prenotazione.DataCheckIn = Convert.ToDateTime(reader["DataCheckIn"]);
                    prenotazione.DataCheckOut = Convert.ToDateTime(reader["DataCheckOut"]);
                    prenotazione.Anticipo = Convert.ToDecimal(reader["Anticipo"]);
                    prenotazione.Nome = reader["Nome"].ToString();
                    prenotazione.Cognome = reader["Cognome"].ToString();
                    prenotazione.Prezzo = Convert.ToDecimal(reader["Prezzo"]);
                    prenotazione.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    prenotazione.IdCamera = Convert.ToInt32(reader["IdCamera"]);
                    prenotazione.IdServizio = Convert.ToInt32(reader["IdServizio"]);
                    listaPrenotazioni.Add(prenotazione);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return View(listaPrenotazioni);

        }
    }
}