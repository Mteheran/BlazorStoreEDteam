using System.Threading.Tasks;

namespace BlazorStore.Client
{
    public interface IHttpService
    {
        Task<T> Get<T>(string uri);
        Task<T> Post<T>(string uri, object value);
        Task<string> PutString(string uri, object value);
        Task<string> PostString(string uri, object value);
    }
}