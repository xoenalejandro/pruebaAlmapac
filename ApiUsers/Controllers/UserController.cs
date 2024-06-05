using ApiUsers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using ApiUsers.Utilitis;
using AutoMapper;


namespace ApiUsers.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private Utils _utils = new Utils();
        private readonly UserDBContex _context;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        public UserController(UserDBContex context, ILogger<UserController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "ListUsers")]

        public async Task<IActionResult> ListUsers()
        {

            List<User> users = await _context.User.ToListAsync();
            List<phones> phones = await _context.phones.ToListAsync();


            return Ok(users);
        }



        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO userDTO)
        {
            try
            {
                User user = _mapper.Map<User>(userDTO);
               
                if (!_utils.IsValidEmail(user.Email))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = "El formato de correo electrónico no es válido" });
                }


                if (!_utils.IsValidPassword(user.Password))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = "El Formato es incorrecto para la Contraseña" });
                }

                user.Password = _utils.EncryptPassword(user.Password);

                if (_context.User.Any(u => u.Email == user.Email))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = "El correo electrónico ya está registrado" });
                }



                user.Id = Guid.NewGuid();
                user.Token = Guid.NewGuid().ToString();
                user.Created = DateTime.Now;
                user.Modified = DateTime.Now;
                user.LastLogin = DateTime.Now;
                user.IsActive = true;



                foreach (var phone in user.phones)
                {
                    phone.Id = Guid.NewGuid();
                    phone.UserId = user.Id;
                }

                _context.User.Add(user);
                await _context.SaveChangesAsync();

                var createdUser = new
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    CreationDate = user.Created,
                    ModificationDate = user.Modified,
                    LastLogin = user.LastLogin,
                    Token = user.Token,
                    Active = user.IsActive
                };
                return Ok(createdUser);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = "Contactar al Administrador Error: " + e.Message });
            }
        }

    }
}
