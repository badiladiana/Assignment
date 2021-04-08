using Assignment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.Manager.Contracts
{
    public interface IRealEstateAgentManager
    {
        /// <summary>
        ///Returns full list of real estate agents
        /// </summary>
        /// <returns></returns>
        IEnumerable<RealEstateAgentViewModel> GetRealEstateAgents();

        /// <summary>
        /// Returns real estate agents based on filters
        /// </summary>
        /// <param name="top"></param>
        /// <param name="city"></param>
        /// <param name="forSale"></param>
        /// <param name="hasGarden"></param>
        /// <returns></returns>
        Task<IEnumerable<RealEstateAgentViewModel>> GetTopRealEstateAgentsByFilter(int top, string city, bool forSale, bool hasGarden);
    }
}
