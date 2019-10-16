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

            //TODO: Необходимо сделать в представлении DropBoxes с выборкой по таблица Department и Position
            DataTable tmpTable = new DataTable();
            ViewModel viewModel = new ViewModel();

            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT Name FROM Department", sqlCon);
                sqlData.Fill(tmpTable);
                sqlCon.Close();
            }

            //enum query = tmpTable.From

            //foreach(Department s in tmpTable) {
            //    viewModel.dep.Id = s.
            //}

            return View(viewModel);
        }
                
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(Employees Emp) {
         //   if (ModelState.IsValid) {
                using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                                       
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO[dbo].[Staff]([Login], [Password], [Name], [Gender], [BirthDate], [EnterDate], [LeaveDate], [Automobile], [Married], [Department], [Position], [EMail], [Comments])" +
                        "VALUES(@login, @password, @name, @gender, @birthdate, @enterdate, @leavedate, @automobile, @married, @department, @position, @email, @comment)", sqlCon);
                cmd.Parameters.AddWithValue("@login", Emp.Login);
                cmd.Parameters.AddWithValue("@password", Emp.Password);
                cmd.Parameters.AddWithValue("@name", Emp.Name);
                cmd.Parameters.AddWithValue("@gender", Emp.Gender);
                cmd.Parameters.AddWithValue("@birthdate", Emp.BirthDate);
                cmd.Parameters.AddWithValue("@enterdate", Emp.EnterDate);
                cmd.Parameters.AddWithValue("@leavedate", Emp.LeaveDate);
                cmd.Parameters.AddWithValue("@automobile", Emp.Automobile);
                cmd.Parameters.AddWithValue("@married", Emp.Married);
                cmd.Parameters.AddWithValue("@department", Emp.Department);
                cmd.Parameters.AddWithValue("@position", Emp.Position);
                cmd.Parameters.AddWithValue("@email", Emp.EMail);
                cmd.Parameters.AddWithValue("@comment", Emp.Comments);

                cmd.ExecuteNonQuery();

                sqlCon.Close();
                }
                ViewBag.Message = "Сотрудник добавлен.";
            //}
            return View(Emp);
        }
    }
}