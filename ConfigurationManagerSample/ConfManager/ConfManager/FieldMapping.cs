using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfManager
{
    public class FieldMapping: ConfigurationSection
    {
        [ConfigurationProperty("xVelocity")]
        public FieldCollection xVelocity
        {
            get
            {
                return (FieldCollection)this["xVelocity"];
            }
            set
            {
                this["xVelocity"] = value;
            }
        }
    }
}
