using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;

namespace WebAPP.Controllers
{
    public class HomeController : Controller
    {
        private void CreateDatabase()
        {
            System.Data.SqlClient.SqlConnection tmpConn;
            string sqlCreateDBQuery;
            tmpConn = new SqlConnection();
            tmpConn.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = myData; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            sqlCreateDBQuery = "CREATE TABLE User"+"(FirstName CHAR(50),LastName CHAR(50),EmailAddress CHAR(100))";
            SqlCommand myCommand = new SqlCommand(sqlCreateDBQuery, tmpConn);
            try
            {
                tmpConn.Open();
                myCommand.ExecuteNonQuery();
                Trace.WriteLine("Table created");
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            finally
            {
                tmpConn.Close();
            }
            return;
        }
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            Models.User model = new Models.User();
            return View(model);
        }

        [HttpPost]
        public ActionResult Signup(Models.User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                Trace.WriteLine(model.FirstName);
                CreateDatabase();
                
            }
            return RedirectToAction("Index");
        }
    }
}