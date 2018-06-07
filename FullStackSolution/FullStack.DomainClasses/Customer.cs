using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.DomainClasses
{
    public class Customer
    {
        private ICollection<Address> _address;

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public virtual ContactDetails contactDetails { get; set; }
        public virtual ICollection<Address> Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public Customer()
        {
            _address = new List<Address>();
        }
    }
}
