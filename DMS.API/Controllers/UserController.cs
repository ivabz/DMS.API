using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMS.API.Models.AzureDAL;
using DMS.API.Models;

namespace DMS.API.Controllers
{
    public class UserController : ApiController
    {
        DMSDataAccessLayer DB = new DMSDataAccessLayer(); 
        
        // GET api/<controller>
        public IEnumerable<User> GetUsers()
        {
            return DB.ReadAllUsersFromDMS();
        }

        // GET api/<controller>/5
        public string GetWorkItem(int id)
        {
            return DB.ReadFromDMS();
        }

        // POST api/<controller>
        public void PostWorkItem([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void PutWorkItem(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void DeletWorkItem(int id)
        {
        }
    }
}