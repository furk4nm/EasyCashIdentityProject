using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccont
    {
        [Key]
        public int CustomerAcconutID { get; set; }

        public string CustomerAccontNumber { get; set; }

        public string CustomerAccontCurrency { get; set; }
        public decimal CustomerAccontBalance { get; set; }
        public string BankBranch { get; set; }

        public int AppUserID { get; set; }

        public AppUser AppUser { get; set; }
    }
}
