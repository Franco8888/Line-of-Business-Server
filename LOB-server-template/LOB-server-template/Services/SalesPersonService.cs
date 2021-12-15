using LOB_server_template.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static LOB_server_template.Services.SalesPersonService;

namespace LOB_server_template.Services
{
    public interface ISalesPersonService
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(string customerId);
        string AddCustomer(DTO_IN_Customer customerData);
        string AddCustomers(List<DTO_IN_Customer> customersData);
        string UpdateCustomer(string customerId, DTO_IN_Customer update);
        string DeleteCustomer(string customerId);
    }

    public class SalesPersonService: ISalesPersonService
    {

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // Service Field Variables
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        private readonly IDataBaseService db;

        public SalesPersonService(
            IDataBaseService databaseService
            )
        {
            db = databaseService;
        }

        public List<Customer> GetCustomers()
        {
            try
            {
                var result = db.CustomerCollection.Find(customer => true).ToList();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Customer GetCustomer(string customerId)
        {
            try
            {
                var result = db.CustomerCollection.Find(customer => customer.Id == customerId).FirstOrDefault();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string AddCustomer(DTO_IN_Customer customerData)
        {
            var customer = new Customer
            {
                Email = customerData.Email,
                Name = customerData.Name,
                Surname = customerData.Surname,
                TelephoneNumber = customerData.TelephoneNumber
            };

            try
            {
                db.CustomerCollection.InsertOne(customer);
                return "Successfully inserted Customer";
            }
            catch (Exception e)
            {
                return $"Error inserting Customer. Message: {e}";
            }

        }

        public string AddCustomers(List<DTO_IN_Customer> customersData)
        {
            var customers = new List<Customer>();

            foreach (var customer in customersData)
            {
                customers.Add(new Customer
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    TelephoneNumber = customer.TelephoneNumber
                });
            }

            IEnumerable<Customer> customerIE = customers;

            try
            {
                db.CustomerCollection.InsertMany(customerIE);
                return "Successfully inserted customers";
            }
            catch (Exception e)
            {
                return $"Failed to insert customers. Reason: {e}";
            }
        }


        public string UpdateCustomer(string customerId, DTO_IN_Customer update)
        {

            var customerUpdateDefinition = Builders<Customer>.Update
                .Set(c => c.Name, update.Name)
                .Set(c => c.Email, update.Email)
                .Set(c => c.TelephoneNumber, update.TelephoneNumber);

            try
            {
                //customerCollection.FindOneAndUpdate();
                db.CustomerCollection.UpdateOne<Customer>(customer => customer.Id == customerId, customerUpdateDefinition);
                return "Successfully updated Customer";
            }
            catch (Exception e)
            {
                return $"Error updating Customer. Message: {e}";
            }

        }

        public string DeleteCustomer(string customerId)
        {
            try
            {
                db.CustomerCollection.DeleteOne<Customer>(customer => customer.Id == customerId);
                return "Successfully deleted Customer";
            }
            catch (Exception e)
            {
                return $"Error deleting Customer. Message: {e}";
            }
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // DTO
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        public class DTO_IN_Customer
        {
            [Required]
            public string Email { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            public string Surname { get; set; }

            public string TelephoneNumber { get; set; }
        }

    }
}
