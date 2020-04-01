//using System;
//namespace FoodRecall.APIHandlerManager
//{
//    public class APIHandler
//    {
//        public APIHandler()
//        {
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using FoodRecall.Models;

namespace FoodRecall.APIHandlerManager
{
    public class APIHandler
    {
        // Obtaining the API key is easy. The same key should be usable across the entire
        // data.gov developer network, i.e. all data sources on data.gov.
        // https://www.nps.gov/subjects/developer/get-started.htm

        static string BASE_URL = "https://api.fda.gov/drug/event.json";
        static string API_KEY = "6j8sUbS7FY6XyK5p7EZ4Bg7laJISv1PGVuQwZ8Of"; //Add your API key here inside ""

        HttpClient httpClient;

        /// <summary>
        ///  Constructor to initialize the connection to the data source
        /// </summary>
        public APIHandler()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Method to receive data from API end point as a collection of objects
        /// 
        /// JsonConvert parses the JSON string into classes
        /// </summary>
        /// <returns></returns>
        public Recalls GetRecalls()
        {
            string FOOD_RECALL_API_PATH = BASE_URL + "?limit=20";
            string recallsData = "";

            Recalls recalls = null;

            httpClient.BaseAddress = new Uri(FOOD_RECALL_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(FOOD_RECALL_API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    recallsData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!recallsData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    recalls = JsonConvert.DeserializeObject<Recalls>(recallsData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return recalls;
        }
    }
}
