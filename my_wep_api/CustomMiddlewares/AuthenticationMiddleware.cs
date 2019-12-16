﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace my_wep_api.CustomMiddlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];

            if (authHeader == null)
            {
                await _next(context);
                return;
            }

            //basic emre:123456

            if (authHeader!=null && authHeader.StartsWith("basic",StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.Substring(6).Trim();
                try
                {
                    var credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                    var credentials = credentialString.Split(":");

                    if (String.Equals("emre", credentials[0].ToString()) && String.Equals("123456", credentials[1].ToString()))
                    {
                        //Principle

                        var claims = new[] {
                        new Claim ( "name",credentials[0] ),
                        new Claim (ClaimTypes.Role,"Admin")
                        };

                        var identity = new ClaimsIdentity(claims);
                        context.User = new ClaimsPrincipal(identity);
                    }
                    else
                    {
                        context.Response.StatusCode = 401;
                    }
                }
                catch (Exception)
                {

                    context.Response.StatusCode = 401;
                }
                
            }

            await _next(context);
        }
    }
}
