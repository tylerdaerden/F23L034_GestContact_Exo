using F23L034_GestContact.Models.Entities;
using F23L034_GestContact.Models.Forms;
using F23L034_GestContact.Models.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Tools.Database;

namespace F23L034_GestContact.Controllers
{
    public class AuthController : Controller
    {
        //CONNECTION_STRING pour VDI
        //const string CONNECTION_STRING = @"Data Source=FORMA-VDI303\TFTIC;Initial Catalog=F23L034_GestContact.Database;Integrated Security=True";
        //CONNECTION_STRING pour ma tour
        const string CONNECTION_STRING = @"Data Source=FORMA-VDI303\TFTIC;Initial Catalog=F23L034_GestContact.Database;Integrated Security=True";


        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            /* Appel à la procédure stockée */
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                dbConnection.Open();
                Utilisateur? utilisateur = dbConnection.ExecuteReader("CSP_Login", dr => dr.ToUtilisateur(), true, new { form.Email, form.Passwd }).SingleOrDefault();

                if(utilisateur is null)
                {
                    ModelState.AddModelError("", "Email ou Mot de passe incorrecte");
                    return View(form);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterForm form)
        {
            if(!ModelState.IsValid)
            {
                return View(form);                
            }
            
            /* Appel à la procédure stockée */
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                dbConnection.Open();
                dbConnection.ExecuteNonQuery("CSP_Register", true, new { form.Nom, form.Prenom, form.Email, form.Passwd });
            }

            return RedirectToAction(nameof(Login));
        }
    }
}
