using ServiceManager.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager.Contracts
{
    public interface IServiceManager
    {
        /// <summary>
        /// Retreives all agents from api 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IEnumerable<RealEstateAgentDTO> GetAgentsFromAPi(string key);

        /// <summary>
        /// Returns filtered agents from api - version with no cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="top"></param>
        /// <param name="city"></param>
        /// <param name="forSale"></param>
        /// <param name="hasGarden"></param>
        /// <returns></returns>
        Task<IEnumerable<RealEstateAgentDTO>> GetFilteredAgentsFromApi(string key, int top, string city, bool forSale, bool hasGarden);

        /// <summary>
        /// Returns filtered agents from api - version with cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="top"></param>
        /// <param name="city"></param>
        /// <param name="forSale"></param>
        /// <param name="hasGarden"></param>
        /// <returns></returns>
        Task<IEnumerable<RealEstateAgentDTO>> GetFilteredAgentsFromApiCached(string key, int top, string city, bool forSale, bool hasGarden);


    }
}
