using FundaAPIClient.DataContracts;
using ServiceManager.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ServiceManager.Implementation
{
    /// <summary>
    /// Very simple mapper concept. Mapps complex result from Api to simple DTO
    /// </summary>
    public class RealEstateAgentDTOMapper
    {        
        public IEnumerable<RealEstateAgentDTO> MapToRealEstateAgent(IEnumerable<Object> objects)
        {
            IEnumerable<RealEstateAgentDTO> agents = objects.Select(x => new RealEstateAgentDTO
            {
                Id = x.MakelaarId,
                Name = x.MakelaarNaam,
                Address = x.Woonplaats

            });
            return agents;
        }
    }
}
