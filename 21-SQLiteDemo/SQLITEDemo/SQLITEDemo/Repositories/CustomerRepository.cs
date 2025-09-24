using SQLite;
using SQLITEDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLITEDemo.Repositories
{
    public class CustomerRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public CustomerRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            connection.CreateTable<Customer>();
        }



        public void AddOrUpdate(Customer customer)
        {
            int result = 0;

            try
            {
                if (customer.Id != 0)
                {
                    //Update
                    result = connection.Update(customer);
                    StatusMessage = $"{result} row(s) updated.";
                }
                else
                {
                    //Add
                    result = connection.Insert(customer);
                    StatusMessage = $"{result} row(s) added.";
                }               

            }
            catch (Exception ex)
            {

                StatusMessage = $"Error: {ex.Message}.";
            }
        }
        public Customer Get(int id)
        {


            try
            {
                return connection.Table<Customer>().FirstOrDefault(x => x.Id == id);

            }
            catch (Exception ex)
            {

                StatusMessage = $"Error: {ex.Message}.";
            }

            return null;
        }
        public List<Customer> GetAll()
        {
            

            try
            {
                return connection.Table<Customer>().ToList();

            }
            catch (Exception ex)
            {

                StatusMessage = $"Error: {ex.Message}.";
            }

            return null;
        }
        public List<Customer> GetAll2()
        {


            try
            {
                return connection.Query<Customer>("select * from Customers").ToList();

            }
            catch (Exception ex)
            {

                StatusMessage = $"Error: {ex.Message}.";
            }

            return null;
        }
        public void Del(int id)
        {
            try
            {
                var customer = Get(id);
                connection.Delete(customer);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}.";
            }
            
        }

    }
}
