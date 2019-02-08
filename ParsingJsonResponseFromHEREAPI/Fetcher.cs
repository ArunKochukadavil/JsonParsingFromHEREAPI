using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParsingJsonResponseFromHEREAPI
{
	class Fetcher
	{
		internal static LatLong[] GetLatLong(string app_id,string app_code,string[] add)
		{
			LatLong[] latLong = new LatLong[add.Length];
			for(long i=0;i<add.Length;i++)
			{
				var url = String.Format("https://geocoder.api.here.com/6.2/geocode.json?app_id={0}&app_code={1}&searchtext={2}", app_id, app_code, Uri.EscapeUriString(add[i]));
				var wc = new WebClient();
				var json = wc.DownloadString(url);
				//Console.WriteLine(json);
				JObject jsonObject = JObject.Parse(json);
				var response = (JObject)jsonObject["Response"];
				var metaInfo = (JObject)response["MetaInfo"];
				var timeStamp = (DateTime)metaInfo.GetValue("Timestamp");
				var view = (JArray)response["View"];
				var result = (JArray)view[0]["Result"];
				//Console.WriteLine(result.HasValues);
				var location = (JObject)result[0]["Location"];
				//Console.WriteLine(location.HasValues);
				var displayPosition = (JObject)location["DisplayPosition"];
				//Console.WriteLine(displayPosition.HasValues);
				var lat = (decimal)displayPosition["Latitude"];
				var longi = (decimal)displayPosition["Longitude"];
				latLong[i] = new LatLong()
				{
					Latitude=lat,
					Longitude=longi
				};
				Console.WriteLine($"count={(i+1)}");
			}
			return latLong;
		}
	}
}
