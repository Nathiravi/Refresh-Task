using Microsoft.AspNetCore.Mvc;
using Authentication.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Controllers;


[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{

private IConfiguration _configuration;
public HomeController(IConfiguration configuration){
    _configuration=configuration;
}

 
    private string GenerateToken(Login login)
    {
        var securitykey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
        var credentials=new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
        var token=new JwtSecurityToken(_configuration["Jwt:Issuer"],_configuration["Jwt:Audience"],null,
        expires:DateTime.Now.AddSeconds(30),
        signingCredentials:credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public bool validateToken(string token)
      {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = _configuration["Jwt:Issuer"],
            ValidAudience = _configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
        SecurityToken validatedToken;
        var claim = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
        return claim.Identity.IsAuthenticated;
      }
      
    [HttpPost]
    public string Login([FromBody]Login login)
    {
        
        if (login.Username=="neela.dhanalakshmi"&&login.Password=="Ndhana@1810")
        { 
           string token= GenerateToken(login);
            return token;
        }
              else return "Invalid";
    }
    [HttpGet]
    public string Edit(string token){
        if(validateToken(token)){
            return "valid token";
        }
        return "Token Expired";
    }
}