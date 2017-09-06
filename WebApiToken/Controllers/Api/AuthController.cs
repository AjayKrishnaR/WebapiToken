using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiToken.Filters;
using WebApiToken.Models;

namespace WebApiToken.Controllers.Api
{
    public class AuthController : ApiController
    {




        BusinessService _BusinessService = new BusinessService();

        private HttpResponseMessage GetAuthToken(string username, string password)
        {
            var token = _BusinessService.GenerateToken(username, password);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", token.Authtoken);
            response.Headers.Add("TokenExpiry", DateTime.Now.AddHours(2).ToString());
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;
        }

        [Route("Authenticating")]
        [HttpGet]
        public HttpResponseMessage Authenticate(string username, string password)
        {
            return GetAuthToken(username, password);
        }

        [AuthorizationRequired]
        [Route("GetUserAgain")]
        public  string GetUserDetails(string username)
        {
            return "Invalid";
        }
    }
}
