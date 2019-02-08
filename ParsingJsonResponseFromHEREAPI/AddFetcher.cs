namespace ParsingJsonResponseFromHEREAPI
{
	class AddFetcher
	{
		internal static string[] getAddress(int n)
		{
			var add = new string[n];
			for(int i=0;i<n;i++)
			{
				add[i] = "Plaza New York, Fifth Avenue at Central Park South, , , , NEW YORK, , , 10019";
			}
			return add;
		}
	}
}
