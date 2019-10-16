using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using StaffList.Models;

namespace StaffList.Controllers
{
    public class HomeController : Controller
    {
        //string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = RSXB; Integrated Security = True";
        string connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB;Initial Catalog = RSXB; Integrated Security = True;AttachDBFilename=|DataDirectory|\RSXB.mdf";


        [HttpGet]
        public ActionResult Index()
        {
            DataTable Emp = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter(
                    "SELECT s.Id, s.Name, s.BirthDate, d.Name, p.Name, s.Automobile, s.EnterDate, s.LeaveDate, s.Married, s.Comments, s.Gender FROM Staff s LEFT OUTER JOIN Department d ON s.Department = d.Id LEFT OUTER JOIN Position p ON s.Position = p.Id", sqlCon);
                sqlData.Fill(Emp);
                sqlCon.Close();
            }
            return View(Emp);
        }

        public ActionResult Create() {
            return View();
        }

        
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(Employees Emp) {
         //   if (ModelState.IsValid) {
                using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                                       
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO[dbo].[Staff]([Name], [Gender], [BirthDate], [EnterDate], [LeaveDate], [Automobile], [Married], [Department], [Position], [Comments]) " +
                        "VALUES(@name,@gender,@birdate,@enterdadte,@lastdate,@automobile,@married,@department,@position,@comment", sqlCon);
                    cmd.Parameters.AddWithValue("@name", Emp.Name);
                    cmd.Parameters.AddWithValue("@gender", Emp.Gender);
                    cmd.Parameters.AddWithValue("@birdate", Emp.BirthDate);
                    cmd.Parameters.AddWithValue("@enterdadte", Emp.EnterDate);
                    cmd.Parameters.AddWithValue("@lastdate", Emp.LeaveDate);
                    cmd.Parameters.AddWithValue("@automobile", Emp.Automobile);
                    cmd.Parameters.AddWithValue("@married", Emp.Married);
                    cmd.Parameters.AddWithValue("@department", Emp.Department);
                    cmd.Parameters.AddWithValue("@position", Emp.Position);
                    cmd.Parameters.AddWithValue("@comment", Emp.Comments);
                        
                    cmd.ExecuteNonQuery();

                    sqlCon.Close();
                }
                ViewBag.Message = "Сотрудник добавлен.";
           // }
            return View(Emp);
        }
    }
}