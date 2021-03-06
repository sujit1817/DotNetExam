using ExamQuestion.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamQuestion.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Products> Listproducts = new List<Products>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();

            SqlCommand cmdPrd = new SqlCommand();
            cmdPrd.Connection = cn;
            cmdPrd.CommandType = System.Data.CommandType.Text;
            cmdPrd.CommandText = "Select * from Products ";

            try
            {
                SqlDataReader dr = cmdPrd.ExecuteReader();

                while(dr.Read())
                {
                    Listproducts.Add(new Products { ProductId = (int)dr["ProductId"], ProductName=(string)dr["ProductName"], Rate=(decimal)dr["Rate"], Description=(string)dr["Description"], CategoryName=(string)dr["CategoryName"] });
                }
                dr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return View(Listproducts);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int ? id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();

            SqlCommand cmdEdit = new SqlCommand();
            cmdEdit.Connection = cn;
            cmdEdit.CommandType = System.Data.CommandType.Text;
            cmdEdit.CommandText = "Select * from Products where ProductId=@ProductId";

            Products ob = null;

            try
            {
                SqlDataReader dr = cmdEdit.ExecuteReader();

                while (dr.Read())
                {
                   ob= new Products { ProductId = (int)dr["ProductId"], ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryName = (string)dr["CategoryName"] };
                }
                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return View(ob);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Products ob)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();


            try
            {
                SqlCommand cmdEdit = new SqlCommand();
                cmdEdit.Connection = cn;
                cmdEdit.CommandType = System.Data.CommandType.StoredProcedure;
                cmdEdit.CommandText = "UpdateProducts";

                cmdEdit.Parameters.AddWithValue("@ProductId" , ob.ProductId);
                cmdEdit.Parameters.AddWithValue("@ProductName", ob.ProductName);
                cmdEdit.Parameters.AddWithValue("@Rate", ob.Rate);
                cmdEdit.Parameters.AddWithValue("@Description", ob.Description);
                cmdEdit.Parameters.AddWithValue("@CategoryName", ob.CategoryName);

                cmdEdit.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
