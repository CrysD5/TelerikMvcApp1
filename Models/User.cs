using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikMvcApp1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public List<SocialSites> Socials { get; set; }
        public string Sport { get; set; }
    }
    public class SocialSites
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}