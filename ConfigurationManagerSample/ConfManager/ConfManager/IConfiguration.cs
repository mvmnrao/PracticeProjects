using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfManager
{
    public interface IConfiguration<out T> where T : ConfigurationSection
    {
        string GetValue(string key);

        IConfiguration<T> GetSection(string name);
    }
}