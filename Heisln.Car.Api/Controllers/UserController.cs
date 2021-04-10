﻿using Heisln.Api.Attributes;
using Heisln.Api.Models;
using Heisln.Api.Security;
using Heisln.Car.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Heisln.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserOperationHandler userOperationHandler;

        public UserController(IUserOperationHandler userOperationHandler)
        {
            this.userOperationHandler = userOperationHandler;
        }

        /// <summary>
        /// register a user
        /// </summary>
        /// <param name="newUser">Mail needs to be unique</param>
        /// <response code="200">registered user</response>
        /// <response code="409">login invalid</response>
        [HttpPost("login")]
        [Authorize(AuthenticationSchemes = ApiKeyAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerResponse(statusCode: 200, type: typeof(AuthenticationResponse), description: "registered user")]
        [SwaggerResponse(statusCode: 409, type: typeof(ErrorObject), description: "login invalid")]
        public async virtual Task<IActionResult> UserLogin(string userEmail, string password)
        {
            var result = await userOperationHandler.Login(userEmail, password);
            return new ObjectResult(new AuthenticationResponse { Token = result });
        }

        /// <summary>
        /// register a user
        /// </summary>
        /// <param name="newUser">Mail needs to be unique</param>
        /// <response code="200">registered user</response>
        /// <response code="409">registration invalid</response>
        [HttpPost("registration")]
        [Authorize(AuthenticationSchemes = ApiKeyAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerResponse(statusCode: 200, type: typeof(AuthenticationResponse), description: "registered user")]
        [SwaggerResponse(statusCode: 409, type: typeof(ErrorObject), description: "registration invalid")]
        public async virtual Task<IActionResult> RegistrateUser([FromBody] User newUser)
        {
            var result = await userOperationHandler.Register(newUser.Email, newUser.Password, newUser.FirstName, newUser.LastName, newUser.Birthday);
            return new ObjectResult(new AuthenticationResponse() { Token = result } );
        }
    }
}
