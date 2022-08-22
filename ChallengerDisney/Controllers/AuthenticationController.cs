using ChallengerDisney.Core.Entities;
using ChallengerDisney.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChallengerDisney.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailServices _emailServices;

        public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailServices emailServices)
        {
            _userManager = userManager;
            _emailServices = emailServices;
        }

        [HttpPost]
        [Route("/registro")]

        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            //Revisar si el usuario existe

            var userExist = await _userManager.FindByNameAsync(registerUser.UserName);

            //Si existe, devolver un error

            if (userExist != null)
            {
                return StatusCode(400);
            }

            //Si no existe, registrar al usuario

            var user = new User
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                return StatusCode(500, new
                {
                    status = "Error",
                    Message = $"User creation Failed! Errors : {string.Join(",", result.Errors.Select(x => x.Description))}"
                });
            }

            //await SendEmail();

                return Ok(new
                {
                    status = "Succes",
                    Message = "User created Successfully!"
                    
                });
            }

        //LOGIN

        [HttpPost]
        [Route("/login")]

        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            //Tenemos que chequear que el usuario exista

            var result = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, false);

            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(loginUser.UserName);

                if (currentUser.IsActive)
                {
                    //Generar nuestro Token

                    //Devolver el Token creado

                    return Ok(await GetToken(currentUser));
                }  
            }

            return StatusCode(401, new
            {
                status = "Error",
                Message = $"the user{loginUser.UserName} is not authorized "
                
            }); ;

        }

        private async Task<LoginResponse> GetToken(User currentUser)
        {
            var userRoles = await _userManager.GetRolesAsync(currentUser);

            var authCliams = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, currentUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            authCliams.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));

            var authSigInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeySecretaSuperLargaDeAUTORIZACION"));

            var token = new JwtSecurityToken(
                issuer: "https://localhost:44314",
                audience: "https://localhost:44314",
                expires: DateTime.Now.AddHours(1),
                claims: authCliams,
                signingCredentials: new SigningCredentials(authSigInKey, SecurityAlgorithms.HmacSha256));

            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo
            };
        }
        /*
        public async Task<IActionResult> SendEmail()
        {
            await _emailServices.SendEmail("matute1910@gmail.com", "Bienvenida", "<h1>LE damos la bienvenido, se ha Registrado correctamente!. </h1>");

            return Ok();
        }
        */
    }
}

