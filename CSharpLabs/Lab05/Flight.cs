using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
	internal class Flight
	{
		public Flight(string carrier, string origin, string dest, int depDelay, int arrDelay, bool cancelled, int distance) 
		{
			Carrier = carrier;
			Origin = origin;
			Destination = dest;
			DepDelay = depDelay;
			ArrDelay = arrDelay;
			Cancelled = cancelled;
			Distance = distance;
		}

        public string Carrier { get; set; }
		public string Origin { get; set; }
		public string Destination { get; set; }
		public int DepDelay { get; set; }
		public int ArrDelay { get; set; }
		public bool Cancelled { get; set; }
		public int Distance { get; set; }
	}
}
