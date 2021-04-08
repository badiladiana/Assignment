using FundaAPIClient.DataContracts;
using System.Threading.Tasks;

namespace FundaAPIClient
{
    public interface IFundaAPIClient
    {
        /// <summary>
        /// Api call with specific filter paramteres
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="key"></param>
        /// <param name="city"></param>
        /// <param name="type"></param>
        /// <param name="hasGarden"></param>
        /// <returns></returns>
        Task<Rootobject> GetAllObjects(string baseUrl, string key, string city, string type, bool hasGarden);

        /// <summary>
        /// Api call with specific filter parameters
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="key"></param>
        /// <param name="city"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<Rootobject> GetAllObjects(string baseUrl, string key, string city, string type);
    }
}
