using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DMS.API.Models
{
    public class UserDTO
    {
        public int ID {get; set;}
        
        public string First_Name {get; set;}
        
        public string Last_Name {get; set;}

        public string Login_Id {get; set;}

        public string Password {get; set;}

        public int Role { get; set; }
    }
}