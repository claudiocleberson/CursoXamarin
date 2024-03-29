﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Helpers;

namespace TravelRecord.Model
{
    public class VenueRoot
    {
        public Meta meta { get; set; }
        public Response response { get; set; }

        public static string GenerateURL(double lat, double lon)
        {
            return string.Format(Constants.VENUE_SEARCH, lat, lon, Constants.CLIENTE_ID, Constants.CLIETEN_SECRET, DateTime.Now.ToString("yyyMMdd"));
        }
    }

    public class Meta
    {
        public int code { get; set; }
        public string requestId { get; set; }
    }

    public class LabeledLatLng
    {
        public string label { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Location
    {
        public string address { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public IList<LabeledLatLng> labeledLatLngs { get; set; }
        public int distance { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public IList<string> formattedAddress { get; set; }
        public string crossStreet { get; set; }
        public string postalCode { get; set; }
    }

    public class Icon
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public Icon icon { get; set; }
        public bool primary { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public IList<Category> categories { get; set; }
        public string referralId { get; set; }
        public bool hasPerk { get; set; }

        public async static Task<List<Venue>> GetVenues(double lat, double lon)
        {
            List<Venue> venues = new List<Venue>();

            var url = VenueRoot.GenerateURL(lat, lon);

            using (HttpClient client = new HttpClient())
            {
                var responsee = await client.GetAsync(url);
                var json = await responsee.Content.ReadAsStringAsync();

                var jsonConverted = JsonConvert.DeserializeObject<VenueRoot>(json);
                venues = jsonConverted.response.venues.ToList();
            }

            return venues;
        }
    }

    public class Response
    {
        public IList<Venue> venues { get; set; }
        public bool confident { get; set; }
    }

   
}
