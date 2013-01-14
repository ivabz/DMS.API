using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.API.Models
{
    public class WorkItemDTO
    {
        public int ID;
        public int type;
        public int Status;
        public string Title;
        public string Description;
        public int Priority;
        public int Severity;
        public string Environment;
        public string OS;
        public string Browser;
        public int? Resolution;
        public int? Build;
        public int AssignTo;
        public int OpenedBy;
        public int? ActivatedBy;
        public int? ClosedBy;
        public string AreaPath;
    }
}