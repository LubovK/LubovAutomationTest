using System;
using RestSharp;
using API.Data.Request;

namespace API.Helpers
{
    /// <summary>
    /// API Helper to:
    /// 1. Build a request
    /// 2. Execute a request
    /// 3. Deserialize a response - convert response to some data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RestApiHelper<T>
    {
        /// <summary>
        /// 1. Execute a request
        /// 2. Read a response and convert response to some data
        /// 3. Return response as a some data
        /// </summary>
        /// <typeparam name="DTO"></typeparam>
        /// <param name="resourceUrl"></param>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public DTO ExecuteRequest<DTO>(string resourceUrl, RequestData requestData)
        {
            try
            {
                RestApiHelper<DTO> restApi = new RestApiHelper<DTO>();
                RestClient restUrl = restApi.SetUrl(resourceUrl);
                RestRequest restRequest = restApi.GetRequest(requestData);
                IRestResponse response = restApi.GetResponse(restUrl, restRequest);
                DTO content = restApi.GetContent<DTO>(response);
                return content;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to execute a Rest Request. Error: {ex}");
            }
        }

        /// <summary>
        /// Set and get a RestClient
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private RestClient SetUrl(string url)
        {
            try
            {
                return new RestClient(url);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to set a RestClient. Error: {ex}");
            }
        }

        /// <summary>
        /// Set and get a RestRequest
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        private RestRequest GetRequest(RequestData requestData)
        {
            try
            {
                return new RestRequest(requestData.Resource, requestData.Method);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to set a RestRequest. Error: {ex}");
            }
        }

        /// <summary>
        /// 1. Execute/send a request
        /// 2. Return a request response
        /// </summary>
        /// <param name="restClient"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private IRestResponse GetResponse(RestClient restClient, RestRequest request)
        {
            try
            {
                return restClient.Execute(request);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to execute request: {request.Resource}. Error: {ex}");
            }
        }

        /// <summary>
        /// Deserialize a response and convert to a parametrized data
        /// </summary>
        /// <typeparam name="DTO"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        private DTO GetContent<DTO>(IRestResponse response)
        {
            try
            {
                var deserializer = new RestSharp.Serialization.Json.JsonDeserializer();
                return deserializer.Deserialize<DTO>(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Deserialize a response. Error: {ex}");
            }
        }


    }
}
