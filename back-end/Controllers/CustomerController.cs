using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using webapi.Helpers;
using webapi.Models;
using webapi.Models.ViewModels;
using webapi.Services;

namespace webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        public CustomerController(ICustomerService customerService, IMapper mapper, IOptions<AppSettings> appSettings) {
            _customerService = customerService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Register([FromBody] CustomerVM customerVM) 
        {
            
            var customer = _mapper.Map<Customer>(customerVM);
            
            try
            {
                _customerService.Register(customer, customerVM.Password);
                return Ok();
            }
            catch(ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Authenticate([FromBody] CustomerVM customerVM)
        {
            var customer = _customerService.Authenticate(customerVM.EmailAddress, customerVM.Password);

            if (customer == null)
            {
                return BadRequest("Email or Password is incorrect! ");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, customer.CustomerId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return customer information without password + token
            return Ok( new {
                CustomerId = customer.CustomerId,
                EmailAddress = customer.EmailAddress,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNo = customer.PhoneNo,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpGet("[action]/{customerId}")]
        public IActionResult GetCustomerReservations(int customerId)
        {
            try 
            {
                var reservations = _customerService.GetCustomerReservations(customerId);
                return Ok(reservations);
            }
            catch(ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}