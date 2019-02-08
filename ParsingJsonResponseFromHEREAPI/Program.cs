using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParsingJsonResponseFromHEREAPI
{
	class Program
	{
		static void Main(string[] args)
		{
			WebClient wc = new WebClient();
			Console.WriteLine("How many copies do you want to create : ");
			int n = int.Parse(Console.ReadLine());
			var add = AddFetcher.getAddress(n);
			var app_id = "nlETxVb8XzBCAp720JMZ";
			var app_code = "MqWTqxG7PNX4VbNrmJ_OpA";
			var latLong = Fetcher.GetLatLong(app_id, app_code, add);
			foreach(var val in latLong)
			{
				Console.WriteLine($"Latitude = {val.Latitude} & Longitude = {val.Longitude}");
			}
		}
	}
}
