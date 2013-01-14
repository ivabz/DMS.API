using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMS.API.Models.AzureDAL;
using DMS.API.Utilities;
using DMS.API.Models;


namespace DMS.API.Controllers
{
    public class WorkItemController : ApiController
    {
        
        DMSDataAccessLayer DBWorkItem = new DMSDataAccessLayer();

        // GET api/WorkItem
        public IEnumerable<WorkItemDTO> GetWorkItems()
        {
            return DBWorkItem.ReadAllWorkItemsFromDMS();
        }

        // GET api/WorkItem/5
        public WorkItemDTO GetWorkItem(WorkItem item)
        {
            return DBWorkItem.ReadFromDMS(item);
        }

        // POST api/WorkItem
        [HttpPost]
        public HttpResponseMessage PostWorkItem(WorkItem item)
        {
            try
            {
                DBWorkItem.InsertToDMS(item);
            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
                throw e;
            }

            return Request.CreateResponse(HttpStatusCode.Created);    
        }

        // PUT api/WorkItem/5
        [HttpPut]
        public HttpResponseMessage PutWorkItem(WorkItem item)
        {
            try
            {
                DBWorkItem.UpdateToDMS(item);
            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message);
                throw e;
            }

            return Request.CreateResponse(HttpStatusCode.Created);   
        }

        // DELETE api/WorkItem/5
        [HttpDelete]
        public HttpResponseMessage DeleteWorkitem(WorkItem item)
        {
            try
            {
                DBWorkItem.DeleteFromDMS(item);
            }
            catch (Exception e)
            {
                Logger.ErrorLog(e.Message); // TODO: throw proper exceptions.
                throw e;
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}