
using System.Configuration;

namespace ConfManager.CManager
{
    public interface IConfigurationManager<out T>
    {
        string GetValue(string key);

        IConfiguration<T> GetSection(string name);
    }
}
