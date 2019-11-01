using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project6363.Models
{
    public class Customer
    {
        
            [Required]
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]

        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Email Address")]
        public string email { get; set; }
        //[DataType(phonenum)]
        [Display(Name = "Phone Number")]

        [DataType(DataType.PhoneNumber)]
        public long phoneNumber { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }


      
    }
}
