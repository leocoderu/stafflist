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
        private static string connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB;Initial Catalog = RSXB; Integrated Security = True;AttachDBFilename=|DataDirectory|\RSXB.mdf";
        
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
            //IEnumerable<ViewModel> viewModel = new { ViewModel new {DepUser.Id = }}
            
            ViewModel viewModel = new ViewModel();
            viewModel.DepUser.Departments = DepartmentList();

            return View();
        }

        private static List<SelectListItem> DepartmentList() {
            List<SelectListItem> items = new List<SelectListItem>();

            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                string query = "SELECT Id, Name FROM Department";
                using (SqlCommand cmd = new SqlCommand(query)) {
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader()) {
                        while (sdr.Read()) {
                            items.Add(new SelectListItem {
                                Text = sdr["Name"].ToString(),
                                Value = sdr["Id"].ToString()
                            });
                        }
                    }
                    sqlCon.Close();
                }
            }
            return items;
        }
                
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModel viewModel) {
         //   if (ModelState.IsValid) {
                using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                                       
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO[dbo].[Staff]([Login], [Password], [Name], [Gender], [BirthDate], [EnterDate], [LeaveDate], [Automobile], [Married], [Department], [Position], [EMail], [Comments])" +
                        "VALUES(@login, @password, @name, @gender, @birthdate, @enterdate, @leavedate, @automobile, @married, @department, @position, @email, @comment)", sqlCon);
                cmd.Parameters.AddWithValue("@login", viewModel.Emp.Login);
                cmd.Parameters.AddWithValue("@password", viewModel.Emp.Password);
                cmd.Parameters.AddWithValue("@name", viewModel.Emp.Name);
                cmd.Parameters.AddWithValue("@gender", viewModel.Emp.Gender);
                cmd.Parameters.AddWithValue("@birthdate", viewModel.Emp.BirthDate);
                cmd.Parameters.AddWithValue("@enterdate", viewModel.Emp.EnterDate);
                cmd.Parameters.AddWithValue("@leavedate", viewModel.Emp.LeaveDate);
                cmd.Parameters.AddWithValue("@automobile", viewModel.Emp.Automobile);
                cmd.Parameters.AddWithValue("@married", viewModel.Emp.Married);
                cmd.Parameters.AddWithValue("@department", viewModel.DepUser.Id);
                cmd.Parameters.AddWithValue("@position", viewModel.PosUser.Id);
                cmd.Parameters.AddWithValue("@email", viewModel.Emp.EMail);
                cmd.Parameters.AddWithValue("@comment", viewModel.Emp.Comments);

                cmd.ExecuteNonQuery();

                sqlCon.Close();
                }
                ViewBag.Message = "Сотрудник добавлен.";
            //}
            return View();
        }
    }
}