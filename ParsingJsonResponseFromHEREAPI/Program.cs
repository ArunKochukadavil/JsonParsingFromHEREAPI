using System;
using System.IO;
using System.Net;

namespace ParsingJsonResponseFromHEREAPI
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				WebClient wc = new WebClient();
				Console.WriteLine("How many copies do you want to create : ");
				int n = int.Parse(Console.ReadLine());
				var location = File.ReadAllText(@"location.txt");
				var text = File.ReadAllText(location);
				var id = text.Split();

				var add = AddFetcher.getAddress(n);
				var app_id = id[0];
				var app_code = id[1];

				var latLong = Fetcher.GetLatLong(app_id, app_code, add);
				foreach (var val in latLong)
				{
					Console.WriteLine($"Latitude = {val.Latitude} & Longitude = {val.Longitude}");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
