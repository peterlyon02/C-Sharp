using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
	internal class User
	{
        public int id { get; set; }
		public string username { get; set; }
		public string email { get; set; }
		public string phone { get; set; }
		public string website { get; set; }
		public Address address { get; set; }
	}
	internal class Address 
	{
		public string street { get; set; }
		public string suite { get; set; }
		public string city { get; set; }
		public string zipcode { get; set; }
		public Geo geo { get; set; }
	}
	internal class Geo
	{
		public string lat { get; set;}
		public string lng { get; set; }
	}
}
