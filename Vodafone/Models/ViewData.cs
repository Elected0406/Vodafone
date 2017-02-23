using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Vodafone.Models
{
    public class Keys
    {
        public int Id { get; set; }
        public string Key { get; set; }
    }
    public class UserInformation
    {
        public int Hepuhvs { get; set; }
        public int Mepuhvs { get; set; }
        public int Lepuhvs { get; set; }
        public int Ulepuhvs { get; set; }
        public int Lpdrpes { get; set; }
    }
    public class Userdatabase : DbContext
    {
        public DbSet<Keys> Keyss { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
    }
}