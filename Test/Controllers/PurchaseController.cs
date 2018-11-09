using Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Npgsql;
using System.Windows.Forms;

namespace Test.Controllers
{
    public class PurchaseController : ApiController
    {
        
        List<Purchase> purchases = new List<Purchase>();

        PurchaseController()
        {
            try
            {
                string connstring = "server=127.0.0.1; port=5432; User Id=postgres; password=08121996; database=TestDB;";
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand("select * from test.purchases", connection);
                NpgsqlDataReader dataReader = command.ExecuteReader();
                for (int i = 0; dataReader.Read(); i++)
                {
                    purchases.Add(new Purchase { PurchaseID = Int32.Parse(dataReader[0].ToString()), ItemID = Int32.Parse(dataReader[1].ToString()), Date = DateTime.Parse(dataReader[2].ToString()), Time = DateTime.Parse(dataReader[3].ToString()) });
                }
                connection.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
        }

        public void PostgreSQL()
        {

        }

        public List<Purchase> GetAllPurchases()
        {
            return purchases;
        }

        public IHttpActionResult GetPurchase(int id)
        {
            var purchase = purchases.FirstOrDefault((p) => p.ItemID == id);
            if (purchase == null)
            {
                return NotFound();
            }
            return Ok(purchase);
        }
    }
}
