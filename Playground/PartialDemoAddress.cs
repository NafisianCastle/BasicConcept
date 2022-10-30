namespace Playground
{
	partial class PartialDemo
	{
		private string city;
		private string province;
		private string country;

		public string City { get => city; set => city = value; }

		public string Province { get => province; set => province = value; }

		public string Country { get => country; set => country = value; }

		public string Address(string city, string province, string country) => city + ", " + province + ", " + country;

		public string PersonalDetails(TwoParamDel<string> fullName, ThreeParamDel<string> address)
		{
			return fullName(firstName, lastName) + "\n" + address(city, province, country);
		}
	}
}
