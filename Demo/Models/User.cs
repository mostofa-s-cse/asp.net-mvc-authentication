using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")] //this must be same to the UserRole class
        public UserRole Role { get; set; }
        public User()
        {
            RoleId = 1;
            // bye default it assign id=1 to the db table
        }
    }
}