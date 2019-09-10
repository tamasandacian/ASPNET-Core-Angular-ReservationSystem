using webapi.Helpers;
using webapi.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using webapi.Models.ViewModels;

namespace webapi.Services 
{
    public interface ICustomerService
    {
        Customer Authenticate(string name, string password);
        Customer Register(Customer customer, string password);
        List<ReservationVM> GetCustomerReservations(int customerID);
    }

    public class CustomerService : ICustomerService
    {
        private readonly DBContext _dbContext;

        public CustomerService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Customer Authenticate(string email, string password)
        {
            // check if email and password fields are empty or null
            if (string.IsNullOrEmpty(email) || (string.IsNullOrEmpty(password)))
            {
                return null;
            }

            var customer = _dbContext.Customers.SingleOrDefault(x => x.EmailAddress == email);

            // check if customer with email exist
            if (customer == null) {
                return null;
            }

            // check if password is correct
            if (!VerifyPasswordHash(password, customer.PasswordHash, customer.PasswordSalt))
            {
                return null;
            }

            return customer;
            
        }

        public Customer Register(Customer customer, string password)
        {
            // check if password is null or white space
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ApplicationException("Password is required!");
            }

            if(!IsValidEmail(customer.EmailAddress))
            {
                throw new ApplicationException("Please type a valid Email Address!");
            }

            // check if customer with email exist
            if (_dbContext.Customers.Any(x => x.EmailAddress == customer.EmailAddress))
            {
                throw new ApplicationException("Customer with " + customer.EmailAddress + " is already taken");
            }

            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return customer;
        }

        public List<ReservationVM> GetCustomerReservations(int customerId)
        {
            var reservations = (from r in _dbContext.Reservations 
                                join f in _dbContext.Fields on r.FieldId equals f.FieldId
                                join fd in _dbContext.FieldDetails on f.FieldId equals fd.FieldId
                                where r.CustomerId == customerId
                                select new ReservationVM
                                {
                                    Id = (int)r.Id,
                                    Name = r.Title,
                                    Start = r.Start,
                                    End = r.End,
                                    Total = r.Total,
                                    Field = f.Title,
                                    Path = f.PathURL,
                                    Address = fd.Address,
                                    StartProgram = fd.StartProgram,
                                    EndProgram = fd.EndProgram
                                    
                                }).ToList();

            return reservations;
        }


        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }


    }
}