// See https://aka.ms/new-console-template for more information
using Lab05;
using System.Text.Json;
using System.Text.Json.Serialization;

Airport airport = new Airport();
Console.WriteLine("Inserire  partenza...");
string partenza = Console.ReadLine();
Console.WriteLine("Inserire  arrivo...");
string arrivo = Console.ReadLine();
List<Flight> flights = new List<Flight>();
if (arrivo.Trim() != "" && partenza.Trim() != "")
{
	flights = airport.Flights.Where(f => f.Origin.Contains(partenza, StringComparison.InvariantCultureIgnoreCase)
	&& f.Destination.Contains(arrivo, StringComparison.InvariantCultureIgnoreCase)
	&& f.Cancelled == false)
		.OrderBy(f => f.ArrDelay).ToList();
}
else if (arrivo.Trim() != "")
{
	flights = airport.Flights.Where(f =>f.Destination.Contains(arrivo, StringComparison.InvariantCultureIgnoreCase) && f.Cancelled == false)
		.OrderBy(f => f.ArrDelay).ToList();
}
else if (partenza.Trim() != "")
{
	flights = airport.Flights.Where(f => f.Origin.Contains(partenza, StringComparison.InvariantCultureIgnoreCase) && f.Cancelled == false)
		.OrderBy(f => f.ArrDelay).ToList();
}
// 
Console.WriteLine("Voli corrispondenti in ordine di ritardo minore:");
foreach (var item in flights)
{
	Console.WriteLine($"Carrier: {item.Carrier}, Partenza: {item.Origin}, Arrivo: {item.Destination}, Delay: {item.ArrDelay}, Distanza (miglia): {item.Distance}");
}

var lateFlights = airport.Flights.OrderByDescending(f => f.ArrDelay).Take(10).ToList();
Console.WriteLine("Di seguito i 10 voli con maggiore ritardo:");
foreach (var item in lateFlights)
{
	Console.WriteLine($"Carrier: {item.Carrier}, Partenza: {item.Origin}, Arrivo: {item.Destination}, Delay: {item.ArrDelay}, Distanza (miglia): {item.Distance}");
}
//HttpClient client = new HttpClient();
//HttpResponseMessage result = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
//if(result.IsSuccessStatusCode)
//{
//	string content = await result.Content.ReadAsStringAsync();
//	var users = JsonSerializer.Deserialize<User[]>(content);

//    foreach (var user in users.OrderBy(u => u.username))
//    {
//        Console.WriteLine($"Utente: {user.username}, email: {user.email}, website: {user.website}");
//    }

//    string json = JsonSerializer.Serialize<User[]>(users);
//    Console.WriteLine("Collection serializzata: " + json);
//}
