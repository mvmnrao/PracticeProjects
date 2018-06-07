using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.DomainClasses
{
    public class ContactDetails
    {
        [Key, ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }        
        public Customer Customer { get; set; }
    }
}
