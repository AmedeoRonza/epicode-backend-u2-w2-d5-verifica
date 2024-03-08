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
    public class ClientiController : Controller
    {
        // GET: Clienti
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InsertCliente()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult InsertCliente(Clienti clienti)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = "INSERT INTO Clienti (CodFisc, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare) VALUES ( @CodFisc, @Cognome, @Nome, @Citta, @Provincia, @Email, @Telefono, @Cellulare )";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@CodFisc", clienti.CodFisc);
                cmd.Parameters.AddWithValue("@Cognome", clienti.Cognome);
                cmd.Parameters.AddWithValue("@Nome", clienti.Nome);
                cmd.Parameters.AddWithValue("@Citta", clienti.Citta); // ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Provincia", clienti.Provincia);
                cmd.Parameters.AddWithValue("@Email", clienti.Email);
                cmd.Parameters.AddWithValue("@Telefono", clienti.Telefono);
                cmd.Parameters.AddWithValue("@Cellulare", clienti.Cellulare);

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
        public ActionResult Clienti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            List<Clienti> listaClienti = new List<Clienti>();

            try
            {
                conn.Open();
                string query = "SELECT * FROM Clienti";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Clienti cliente = new Clienti();
                    cliente.IdCliente = Convert.ToInt32(reader["idCliente"]);
                    cliente.CodFisc = reader["CodFisc"].ToString();
                    cliente.Cognome = reader["Cognome"].ToString();
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.Citta = reader["Citta"].ToString();
                    cliente.Provincia = reader["Provincia"].ToString();
                    cliente.Email = reader["Email"].ToString();
                    cliente.Telefono = reader["Telefono"].ToString();
                    cliente.Cellulare = reader["Cellulare"].ToString();
                    listaClienti.Add(cliente);
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

            return View(listaClienti);

        }
    }
}