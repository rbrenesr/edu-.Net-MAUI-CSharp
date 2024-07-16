using SQLite;
using SQLiteDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Repositories
{
    public class CustomerRepository
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public CustomerRepository()
        {
            this.conn =
                new SQLiteConnection(Constants.DataBasePath, Constants.Flags);

            conn.CreateTable<Customer>();
        }
        public void Add(Customer customer)
        {
            int result = 0;

            try
            {
                result = conn.Insert(customer);
                StatusMessage = $"{result} row(s) added.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
        public void AddOrUpdate(Customer customer)
        {
            int result = 0;

            try
            {
                //Es una actualización
                if (customer.Id != 0)
                {
                    result = conn.Update(customer);
                    StatusMessage = $"{result} row(s) updated.";
                }
                // Nuevo registro
                else
                {
                    result = conn.Insert(customer);
                    StatusMessage = $"{result} row(s) added.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                customers = conn.Table<Customer>().ToList();
                StatusMessage = "Retrieved all customers";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

            return customers;
        }
        public List<Customer> GetAll2()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                customers = conn.Query<Customer>("SELECT * FROM Customers").ToList();
                StatusMessage = "Retrieved all customers";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

            return customers;
        }
        public Customer Get(int id)
        {
            Customer customer = new Customer();

            try
            {
                customer = conn.Table<Customer>().FirstOrDefault(c => c.Id == id);
                StatusMessage = "Retrieved customer";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

            return customer;
        }
        public void Delete(int id)
        {
            int result = 0;

            try
            {
                var customer = Get(id);

                result = conn.Delete(customer);
                StatusMessage = $"{result} row(s) deleted.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

    }
}
