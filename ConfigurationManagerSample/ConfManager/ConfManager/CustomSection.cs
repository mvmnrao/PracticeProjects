
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfManager
{
    public class CustomSection : ConfigurationSection
    {
        [ConfigurationProperty("TestPropertyName", DefaultValue = "Not Set")]
        public string TestPropertyName
        {
            get
            {
                return (string) this["TestPropertyName"];
            }
            set
            {
                this["TestPropertyName"] = value;
            }
        }

        [ConfigurationProperty("Location")]
        public string Location
        {
            get
            {
                return (string)this["Location"];
            }
            set
            {
                this["Location"] = value;
            }
        }

        //[ConfigurationProperty("MaxUsers")]
        //public static ConfigurationProperty MaxUsers
        //{
        //    get
        //    {
        //        return (string)
        //    }
        //}

        //[ConfigurationProperty("MyElement", IsKey = true)]
        //public string MyElement
        //{
        //    get
        //    {
        //        return (string)this["MyElement"];
        //    }
        //    set
        //    {
        //        this["MyElement"] = value;
        //    }
        //}

        //[ConfigurationProperty("TestElement")]
        //public BaseElement TestElement
        //{
        //    get
        //    {
        //        return (BaseElement)this["TestElement"];
        //    }
        //    set
        //    {
        //        this["TestElement"] = value;
        //    }
        //}

        [ConfigurationProperty("MyElem")]
        public MyElem MyElem
        {
            get
            {
                return (MyElem)this["MyElem"];
            }
            set
            {
                this["MyElem"] = value;
            }
        }
    }

    public class MyElem : ConfigurationElement
    {
        public static string Value
        {
            get
            {
                return (string) Value;
            }
            set
            {
                Value = value;
            }
        }
    }

    public class BaseElement : ConfigurationElement
    {
        [ConfigurationProperty("Length", DefaultValue = "not set")]
        public string Length
        {
            get
            {
                return (string)this["Length"];
            }
            set
            {
                this["Length"] = value;
            }
        }
    }
}