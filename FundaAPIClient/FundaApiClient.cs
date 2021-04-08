using FundaAPIClient.DataContracts;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace FundaAPIClient
{
    public class FundaApiClient : IFundaAPIClient
    {
        public async Task<Rootobject> GetAllObjects(string baseUrl, string key, string city, string type)
        {
            var client = new RestClient(baseUrl);
            throw new System.NotImplementedException();
        }

        public async Task<Rootobject> GetAllObjects(string baseUrl, string key, string city, string type, bool hasGarden)
        {
            try
            {
                var client = new RestClient(baseUrl);
                var request = new RestRequest("{key}");
                request.AddUrlSegment("key", key);
                request.AddParameter("type", "koop");
                string zo = hasGarden == true ? @"/" + city + "/tuin/" : "/" + city;
                request.AddParameter("zo", zo);
                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
                IRestResponse<Rootobject> response = client.Execute<Rootobject>(request);
                var rootObject = JsonConvert.DeserializeObject<Rootobject>(response.Content);
                return rootObject;
            }
            catch(Exception ex)
            {
                //logg error
            }
            return null;
        }
    }
}
