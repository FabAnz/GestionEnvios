﻿using CasosUso.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API
{
    public class JWTManager
    {
        public static string GenerarToken(UsuarioLoginDTO usu)
        {

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //clave secreta, generalmente se incluye en el archivo de configuración
            //Debe ser un vector de bytes 

            byte[] clave = Encoding.ASCII.GetBytes("fE8t$7cLx!Rz9@qP2vWh#KdN4sYuB1gX*r/n");

            //Se incluye un claim para el email y el rol
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, usu.Email),
                    new Claim(ClaimTypes.Role, usu.Rol)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(clave),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
