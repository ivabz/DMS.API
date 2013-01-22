using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMS.API.Utilities;
using DMS.API.Models.AzureDAL;
using DMS.API.Models;
using System.Web.Http.ModelBinding;

namespace DMS.API.Controllers
{
    public class UserController : ApiController
    {
        DMSDataAccessLayer DBUser = new DMSDataAccessLayer();

        // GET api/User/All
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            return DBUser.ReadAllUsersFromDMS();
        }

        // GET api/User/5
        public UserDTO GetUser(User user)
        {
            return DBUser.ReadFromDMS(user);
        }

        // POST api/User
        [HttpPost]
        public HttpResponseMessage Post(User user)
        {
            try
            {
                DBUser.InsertToDMS(user);
            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
                throw e;
            }

            return Request.CreateResponse(HttpStatusCode.Created);            
        }

        // PUT api/User/5
        [HttpPut]
        public HttpResponseMessage Put(User user)
        {
            try
            {
                if (DBUser.UpdateToDMS(user))
                {
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to Update the User info for the Given ID"); 
                }
            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
                throw e;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public HttpResponseMessage Delete(User user)
        {
            try
            {
                if (DBUser.DeleteFromDMS(user))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Unable to Update the User info for the Given ID"); 
                }
            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message); // TODO: throw proper exceptions.
                throw e;
            }
        }
    }
}