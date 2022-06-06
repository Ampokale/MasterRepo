using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private loginDAL _repository = new loginDAL();
        

        public LoginController()
        {
            

        }

        [HttpPost("/login")]

        public IActionResult UserLogin([FromBody]User u)
        {
            try
            {
                User user = _repository.loginUser(u);

                if (user!=null)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tokenTeam@8kanbanboard@0248"));

                    var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken
                    (
                        issuer: "https://localhost:8537",
                        audience: "https://localhost:8537",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(4),
                        signingCredentials : signingCredentials

                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new { Token = tokenString , User = user });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.Message);
            }


        }

        


    }





}
