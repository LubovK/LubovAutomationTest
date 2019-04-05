using API.Data.Request;
using API.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Enum;
using API.Data;
using API.Helpers;
using System;
using API.Enums;
using System.Reflection;

namespace API.Tests
{
    /// <summary>
    /// Test class for Postcodes tests
    /// </summary>
    [TestClass]
    public class PostcodeTests
    {
        private StatusCode ExpectedStatusCode => StatusCode.Ok;

        private string ResourceUrl => URL.ResourceUrl;

        ///*Given* I have a running API
        ///*When*  I lookup a valid postcode 
        ///*Then*  the response is 200 OK and details of the area are returned
        [TestMethod]
        public void CheckValidPostcodeData()
        {
            string postcode = Postcode.ValidPostcode;

            Console.WriteLine("Step 1. Get a request data");
            RequestData requestData = RequestData.GetRequestData(RequestType.PostcodeData, Postcode.ValidPostcode);
            Console.WriteLine($"Resource: '{ResourceUrl}/{requestData.Resource}'. Method: '{requestData.Method}'");

            Console.WriteLine($"Step 2. Send the request to check that postcode '{postcode}' is valid");
            PostcodeData response = ExecuteRequest<PostcodeData>(URL.ResourceUrl, requestData);

            Console.WriteLine($"Step 3. Check that response Status Code = {(int)ExpectedStatusCode}");
            string str = $"Expected: {(int)ExpectedStatusCode}. Actual from response: {response.Status}";
            Console.WriteLine(str);
            if ((int)ExpectedStatusCode != response.Status)
                throw new Exception($"Response Status Code is incorrect. " + str);

            Console.WriteLine($"Step 4. Check that details of the area are returned");
            //Get amount Of Null Or Empty Properties for response.Result
            int amountOfNullOrEmptyProperties1 = CheckResponseData(response.Result);

            //Get amount Of Null Or Empty Properties for response.Result.Codes
            int amountOfNullOrEmptyProperties2 = CheckResponseData(response.Result.Codes);

            //Verify that amount of Null or Empty field is less than 2 (or other amount allowed)
            if (amountOfNullOrEmptyProperties1 + amountOfNullOrEmptyProperties2 > 2)
                throw new Exception($"{amountOfNullOrEmptyProperties1 + amountOfNullOrEmptyProperties2} fields of response are Empty or Null. " +
                    $"Some details of the area");
            else
                Console.WriteLine($"Details of the area are returned in response");
        }


        ///*Given* I have a running API
        ///*When*  I validate a valid postcode 
        ///*Then*  the response is 200 OK and the result return is true
        [TestMethod]
        public void ValidateCorrectPostcode()
        {
            string postcode = Postcode.ValidPostcode;
            bool isValidPostcode = true;

            //Test flow to validate Valid postcode
            ValidatePostcode(postcode, isValidPostcode);
        }


        ///*Given* I have a running API
        ///*When*  I validate an invalid postcode 
        ///*Then*  the response is 200 OK and the result return is false
        [TestMethod]
        public void ValidateIncorrectPostcode()
        {
            string postcode = Postcode.InvalidPostcode;
            bool isValidPostcode = false;

            //Test flow to validate Invalid postcode
            ValidatePostcode(postcode, isValidPostcode);
        }

        /// <summary>
        /// Test flow to validate Valid/Invalid postcode
        /// </summary>
        /// <param name="postcode"></param>
        /// <param name="isValidPostcode"></param>
        private void ValidatePostcode(string postcode, bool isValidPostcode)
        {
            string isValid = isValidPostcode ? "valid" : "invalid";

            Console.WriteLine("Step 1. Get a request data");
            RequestData requestData = RequestData.GetRequestData(RequestType.PostcodeValidation, postcode);
            Console.WriteLine($"Resource: '{ResourceUrl}/{requestData.Resource}'. Method: '{requestData.Method}'");

            Console.WriteLine($"Step 2. Send the request to check that postcode '{postcode}' is {isValid}");
            PostcoseValidationData response = ExecuteRequest<PostcoseValidationData>(ResourceUrl, requestData);

            Console.WriteLine($"Step 3. Check that response Status Code = {(int)ExpectedStatusCode}");
            string str = $"Expected: {(int)ExpectedStatusCode}. Actual from response: {response.Status}";
            Console.WriteLine(str);
            if ((int)ExpectedStatusCode != response.Status)
                throw new Exception($"Response Status Code is incorrect. " + str);

            Console.WriteLine($"Step 4. Check that responce Result = '{isValidPostcode}'");
            str = $"Expected: '{isValidPostcode}'. Actual from response: '{response.Result}'";
            Console.WriteLine(str);
            if (isValidPostcode != response.Result)
                throw new Exception($"Response Result is incorrect. " + str);

            Console.WriteLine($"Correct. Postcode '{postcode}' is {isValid}");
        }

        /// <summary>
        /// 1. Initialize a rest API
        /// 2. Execute a request
        /// 3. Return an API responce
        /// </summary>
        /// <typeparam name="DTO"></typeparam>
        /// <param name="resouceUrl"></param>
        /// <param name="requestData"></param>
        /// <returns></returns>
        private DTO ExecuteRequest<DTO>(string resouceUrl, RequestData requestData)
        {
            RestApiHelper<DTO> restApi = new RestApiHelper<DTO>();
            return restApi.ExecuteRequest<DTO>(resouceUrl, requestData);
        }

        /// <summary>
        /// Check Response Data for each property of Postcode
        /// </summary>
        /// <param name="obj"></param>
        private int CheckResponseData(object obj)
        {
            int amountOfNullOrEmptyProperties = 0;
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                object propValue = property.GetValue(obj, null);
                
                if (string.IsNullOrEmpty(Convert.ToString(propValue)))
                {
                    Console.WriteLine($"Nuul or Empty: Property '{property.Name}' = '{propValue}'. ");
                    amountOfNullOrEmptyProperties++;
                }
                else
                    Console.WriteLine($"Property '{property.Name}' = '{propValue}'. ");
            }
            return amountOfNullOrEmptyProperties;
        }
    }
}
