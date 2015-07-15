using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stash.SDK
{
    public class StashClient : IStashClient
    {
        protected enum StashObjectEnum
        {
            Projects
        }

        protected RestClient Client { get; set; }

        protected const String StashServiceURI = "/rest/greenhopper/latest";

        protected Dictionary<StashObjectEnum, String> _methods = new Dictionary<StashObjectEnum, String>()
        {
            { StashObjectEnum.Projects, String.Format("{0}/projects/", StashServiceURI)}
        };

        public StashClient(RestClient client)
        {
            Client = client;
        }

        public StashClient(String url)
        {
            Client = new RestClient(url);
        }

        public StashClient(String url, String username, String password)
        {
            Client = new RestClient(url)
            {
                Authenticator = new HttpBasicAuthenticator(username, password)
            };
        }

        protected T GetItem<T>(StashObjectEnum objectType, Dictionary<String, String> parameters = null,
            Dictionary<String, String> keys = null) where T : new()
        {
            return Execute<T>(objectType, parameters, keys);
        }

        protected List<T> GetList<T>(StashObjectEnum objectType, Dictionary<String, String> parameters = null, Dictionary<String, String> keys = null) where T : new()
        {
            return Execute<List<T>>(objectType, parameters, keys);
        }

        protected T Execute<T>(StashObjectEnum objectType, Dictionary<String, String> parameters = null, Dictionary<String, String> keys = null) where T : new()
        {
            IRestResponse<T> response = Client.Execute<T>(GetRequest(objectType, parameters ?? new Dictionary<String, String>(), keys ?? new Dictionary<String, String>()));

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception(response.ErrorMessage);
            }

            return response.Data;
        }

        protected RestRequest GetRequest(StashObjectEnum objectType, Dictionary<String, String> parameters,
            Dictionary<String, String> keys)
        {
            if (!_methods.ContainsKey(objectType))
                throw new NotImplementedException();

            return GetRequest(_methods[objectType], parameters, keys);
        }

        protected RestRequest GetRequest(String url, Dictionary<String, String> parameters, Dictionary<String, String> keys)
        {
            RestRequest request = new RestRequest(url, Method.GET)
            {
                RequestFormat = DataFormat.Json,
                OnBeforeDeserialization = resp => resp.ContentType = "application/json"
            };


            foreach (KeyValuePair<String, String> key in keys)
            {
                request.AddParameter(key.Key, key.Value, ParameterType.UrlSegment);
            }

            foreach (KeyValuePair<String, String> parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }

            return request;
        }
    }
}
