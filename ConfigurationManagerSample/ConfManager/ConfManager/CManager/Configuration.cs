using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfManager.CManager
{
    public class XMLConfiguration<T> : IConfiguration<T>
    {
        public bool LoadConfiguration()
        {
            throw new NotImplementedException();
        }

        public string GetValue(string keyName)
        {
            throw new NotImplementedException();
        }

        public IConfiguration<T> GetSection(string name)
        {
            throw new NotImplementedException();
        }
    }
}