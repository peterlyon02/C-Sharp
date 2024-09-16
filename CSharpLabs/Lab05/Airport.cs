using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lab05
{
	internal class Airport
	{

		const string filePath = "D:\\Materiale Corsi\\ENAIP\\CSharp\\Mod01\\CSharpLabs\\Lab05\\airline.csv";

		internal Airport()
        {
			ReadDataFromFile();
		}

		internal List<Flight> Flights { get; set; }

		private void ReadDataFromFile()
		{
			Flights = new List<Flight>();
			string[] flights = File.ReadAllLines(filePath);
			int i = 1;
			foreach (string flight in flights)
			{
				if (i == 1)
				{
					i++;
					continue;
				}
				string[] line = flight.Split(',');

				bool cancelled = false;
				if(line[5] == "1")
					cancelled = true;
				int depDelay = 0;
				int arrDelay = 0;
				// Controllo che il dato depDelay e arrDelay sia valorizzato
				bool result = int.TryParse(line[3], out depDelay);
				result = int.TryParse(line[4], out arrDelay);
				
				Flight book1 = new Flight(line[0], line[1], line[2], depDelay, arrDelay, cancelled, int.Parse(line[6]));
				Flights.Add(book1);
				i++;
			}

		}

	}
}
