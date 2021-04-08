using FundaAPIClient;
using FundaAPIClient.DataContracts;
using ServiceManager.Contracts;
using ServiceManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceManager.Implementation
{
    public class ServiceManagr : IServiceManager
    {
        private string baseUrl = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/";
        private IFundaAPIClient aPIClient;
        private ICacheService cacheService;

        public ServiceManagr(IFundaAPIClient aPIClient, ICacheService cacheService)
        {
            this.aPIClient = aPIClient;
            this.cacheService = cacheService;
        }

        public IEnumerable<RealEstateAgentDTO> GetAgentsFromAPi(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RealEstateAgentDTO>> GetFilteredAgentsFromApiCached(string key, int top, string city, bool forSale, bool hasGarden)
        {
            if (hasGarden)
            {
                return await cacheService.GetOrSet("FilteredAgentsFromAPIWithGarden", async () => await GetFilteredAgentsFromApi(key, top, city, forSale, hasGarden));
            }
            else
            {
                return await cacheService.GetOrSet("FilteredAgentsFromAPI", async () => await GetFilteredAgentsFromApi(key, top, city, forSale, hasGarden));
            }
        }

        public async Task<IEnumerable<RealEstateAgentDTO>> GetFilteredAgentsFromApi(string key, int top, string city, bool forSale, bool hasGarden)
        {
            RealEstateAgentDTOMapper mapper = new RealEstateAgentDTOMapper();
            Rootobject result =await aPIClient.GetAllObjects(baseUrl, key, city, null, hasGarden);
            if (result != null && result.Objects != null & result.Objects.Any())
            {
                try
                {
                    var sortedResult = result.Objects.ToList().GroupBy(x => x.MakelaarNaam).Select(y => (
                        Id: y.Key,
                        Count: y.Count(),
                        Value: y.FirstOrDefault()
                    )).OrderByDescending(w => w.Count).ThenBy(w => w.Id).Take(top);
                    IEnumerable<FundaAPIClient.DataContracts.Object> objects = sortedResult.Select(x => x.Value);
                    var mappedAgents = mapper.MapToRealEstateAgent(objects);
                    return mappedAgents;
                }
                catch (Exception ex)
                {
                    //log error
                }
            }
            return null;
        }
    }
}
