using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfManager
{
    [ConfigurationCollection(typeof(Field), AddItemName = "Field")]
    public class FieldCollection : ConfigurationElementCollection//, IEnumerable<Field>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Field();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Field)element).Id;
        }

        public Field this[int idx]
        {
            get { return (Field)BaseGet(idx); }
        }
    }

    public class Field : ConfigurationElement
    {
        [ConfigurationProperty("Id")]
        public int Id
        {
            get
            {
                return (int) this["Id"];
            }
            set
            {
                this["Id"] = value;
            }
        }

        [ConfigurationProperty("Description")]
        public string Description
        {
            get
            {
                return (string)this["Description"];
            }
            set
            {
                this["Description"] = value;
            }
        }

        [ConfigurationProperty("MappedTo")]
        public string MappedTo
        {
            get
            {
                return (string)this["MappedTo"];
            }
            set
            {
                this["MappedTo"] = value;
            }
        }
    }
}
