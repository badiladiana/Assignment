using Assignment.Manager.Contracts;
using Assignment.Models;
using ServiceManager.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Manager.Implementation
{
    public class RealEstateAgentManager : IRealEstateAgentManager
    {
        public IConfiguration Configuration;
        private IServiceManager serviceManager;
        public RealEstateAgentManager(IConfiguration configuration, IServiceManager serviceManager)
        {
            Configuration = configuration;
            this.serviceManager = serviceManager;    
        }

        public IEnumerable<RealEstateAgentViewModel> GetRealEstateAgents()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RealEstateAgentViewModel>> GetTopRealEstateAgentsByFilter(int top, string city, bool forSale, bool hasGarden)
        {
            string key = Configuration["Assignment:ApiKey"];
            var result = await serviceManager.GetFilteredAgentsFromApiCached(key, top, city, forSale, hasGarden);
            var viewModel = result.Select(x => new RealEstateAgentViewModel
            {
                Address = x.Address,
                Id = x.Id,
                Name = x.Name
            });
            return viewModel;
        }
        
    }
}
