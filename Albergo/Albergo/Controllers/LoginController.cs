using Albergo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Albergo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Gest g)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Gest WHERE Username = @Username AND Password = @Password", conn);
                cmd.Parameters.AddWithValue("Username", g.Username);
                cmd.Parameters.AddWithValue("Password", g.Password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    FormsAuthentication.SetAuthCookie(g.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    conn.Close();
                    ViewBag.AuthError = "Autenticazione non riuscita";
                    return View();

                }
            }
            catch (Exception ex)
            {
                ViewBag.AuthError = "Errore durante l'autenticazione: " + ex.Message;
                
            }
            finally { conn.Close(); }

            return RedirectToAction("Index", "Home");

        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}