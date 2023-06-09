using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    //tırnak int olmasının sebebi ilk değerin int olması anahtar int olması
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }
        public string City  { get; set; }
        public string ImageUrl { get; set; }
        public int ConfirmCode { get; set; }
     

        List<CustomerAccont> CustomerAcconts { get; set; }
         
    }
}
