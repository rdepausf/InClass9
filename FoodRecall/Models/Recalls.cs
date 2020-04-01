//using System;
//namespace FoodRecall.Models
//{
//    public class Recalls
//    {
//        public Recalls()
//        {
//        }
//    }
//}


using System;
using System.Collections.Generic;

namespace FoodRecall.Models
{
    // Model for recalls data. These classes can be obtained by either using 
    // the Visual Studio editor (right-click -> Paste Special -> Paste Json as Classes)
    // or sites such as JsonToCSHarp
    public class Recall
    {
        public string states { get; set; }
        public string latLong { get; set; }
        public string description { get; set; }
        public string designation { get; set; }
        public string parkCode { get; set; }
        public string id { get; set; }
        public string directionsInfo { get; set; }
        public string directionsUrl { get; set; }
        public string fullName { get; set; }
        public string url { get; set; }
        public string weatherInfo { get; set; }
        public string name { get; set; }
    }

    public class Recalls
    {
        public string total { get; set; }
        public List<Recall> data { get; set; }
        public string limit { get; set; }
        public string start { get; set; }
    }
}