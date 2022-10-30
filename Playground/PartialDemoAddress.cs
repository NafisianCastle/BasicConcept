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

		public string Address() => city + ", " + province + ", " + country;

		public string PersonalDetails(ParamDel<string> fullName, ParamDel<string> address)
		{
			return fullName() + "\n" + address();
		}
	}
}
