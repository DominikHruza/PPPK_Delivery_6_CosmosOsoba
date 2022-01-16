using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPPK_Delivery_6_CosmosOsoba.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "fullname")]
        public string Fullname { get; set; }

        [Required]
        [JsonProperty(PropertyName = "dob")]
        public string Dob { get; set; }
    }
}