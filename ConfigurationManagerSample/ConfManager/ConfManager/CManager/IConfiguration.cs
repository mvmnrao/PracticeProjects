using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfManager.CManager
{
    public interface IConfiguration<out T>
    {
        bool LoadConfiguration();

        string GetValue(string keyName);

        IConfiguration<T> GetSection(string name);
    }
}
