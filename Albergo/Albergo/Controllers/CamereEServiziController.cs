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
    public class CamereEServiziController : Controller
    {
        // GET: CamereEServizi
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Camera()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            List<Camera> listaCamere = new List<Camera>();

            try
            {
                conn.Open();
                string query = "SELECT * FROM Camera";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Camera c = new Camera();
                    c.IdCamera = Convert.ToInt32(reader["IdCamera"]);
                    c.Numero = reader["Numero"].ToString();
                    c.Tipo = reader["Tipo"].ToString();
                    c.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    listaCamere.Add(c);
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

            return View(listaCamere);

        }
        public ActionResult Servizio()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            List<Servizio> listaServizi = new List<Servizio>();

            try
            {
                conn.Open();
                string query = "SELECT * FROM Servizio";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Servizio s = new Servizio();
                    s.IdServizio = Convert.ToInt32(reader["IdServizio"]);
                    s.Descrizione = reader["Descrizione"].ToString();
                    s.Prezzo = Convert.ToDecimal(reader["Prezzo"]);
                    s.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    listaServizi.Add(s);
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

            return View(listaServizi);

        }
    }
}