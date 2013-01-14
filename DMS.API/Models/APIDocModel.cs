using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace DMS.API.Models
{
    public class APIDocModel
    {
        IApiExplorer _explorer;

        public APIDocModel(IApiExplorer explorer)
        {
            if (explorer == null)
            {
                throw new ArgumentNullException("explorer");
            }
            _explorer = explorer;
        }

        public ILookup<string, ApiDescription> GetApis()
        {
            return _explorer.ApiDescriptions.ToLookup(
                api => api.ActionDescriptor.ControllerDescriptor.ControllerName);

        }
    }
}