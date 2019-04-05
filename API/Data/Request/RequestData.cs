using API.Enum;
using RestSharp;

namespace API.Data.Request
{
    /// <summary>
    /// Build an API Request data
    /// </summary>
    public class RequestData
    {
        public string Resource { get; set; }
        public Method Method { get; set; }

        /// <summary>
        /// Get Api request data by 'request type' and 'postcode'
        /// </summary>
        /// <param name="requestType"></param>
        /// <param name="postcode"></param>
        /// <returns></returns>
        public static RequestData GetRequestData(RequestType requestType, string postcode)
        {
            switch (requestType)
            {
                case RequestType.PostcodeData:
                    return GetRequestPostcodeData(postcode);

                case RequestType.PostcodeValidation:
                    return GetRequestPostcodeValidationData(postcode);

                default:
                    return null;
            }            
        }

        /// <summary>
        /// Build and get Request for 'PostcodeData'
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns></returns>
        private static RequestData GetRequestPostcodeData(string postcode)
        {
            return new RequestData
            {
                Resource = $"postcodes/{postcode}",
                Method = Method.GET
            };
        }

        /// <summary>
        /// Build and get Request for 'ValidationData'
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns></returns>
        private static RequestData GetRequestPostcodeValidationData(string postcode)
        {
            return new RequestData
            {
                Resource = $"postcodes/{postcode}/validate",
                Method = Method.GET
            };
        }
    }
}
