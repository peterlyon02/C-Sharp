// See https://aka.ms/new-console-template for more information
using Lab03;

bool continua = true;
Library library = new Library();

while (continua == true)
{
	Console.WriteLine("Cosa vuoi fare? Inserire libro (1), cancellare libro (2), ricerca libro (3), Consulta catalogo (4), Termina (5)....");
	string choice = Console.ReadLine();
	int ichoice;
	bool result = int.TryParse(choice, out ichoice); // Converte la stringa choice in un intero ichoice (se result == true) 
	if (result)
	{
		switch (ichoice)
		{
			case 1: // Inserisci libro
				Console.WriteLine("Inserisci titolo");
				string titolo = Console.ReadLine();
				if (titolo == "")
					continue;
				Console.WriteLine("Inserisci autore");
				string autore = Console.ReadLine();
				if (autore == "")
					continue;
				// Gestione validazione anno inserito da console
				bool corretto = false;
				int year = 0;
				while (corretto == false)
				{
					Console.WriteLine("Inserisci anno");
					string anno = Console.ReadLine();
					if (anno == "")
						continue;
					corretto = int.TryParse(anno, out year);
				}
				library.AddBook(titolo, autore, year);
				Console.WriteLine($"Libro con titolo: {titolo}, autore {autore} e anno {year} inserito con successo!");
				break;
			case 2:
				Console.WriteLine("Inserisci titolo da cancellare");
				string titolo1 = Console.ReadLine();
				if (titolo1 == "")
					continue;
				int trovati = library.RemoveBooks(titolo1);
				Console.WriteLine($"Cancellati n.{trovati} libri con titolo {titolo1}!");
				break;
			case 3: // Ricerca libri
				Console.WriteLine("Inserisci tipo di ricerca: per titolo (1), per anno (2), per autore (3))");
				choice = Console.ReadLine();
				ichoice = 0;
				result = int.TryParse(choice, out ichoice); // Converte la stringa choice in un intero ichoice (se result == true) 
				List<Book> books = new List<Book>();
				if (result)
				{
					switch (ichoice)
					{
						case 1: // Per titolo
							Console.WriteLine("Inserisci titolo da ricercare");
							string titolo2 = Console.ReadLine();
							books = library.FindByTitle(titolo2);
							break;
						case 2: // Per anno
							Console.WriteLine("Inserisci anno da ricercare");
							string anno = Console.ReadLine();
							books = library.FindByYear(int.Parse(anno));
							break;
						case 3: // Per autore
							Console.WriteLine("Inserisci autore da ricercare");
							string author = Console.ReadLine();
							books = library.FindByAuthor(author);
							break;
						default:
							break;
					}
					// Mostro i risultati della ricerca
					if (books.Count == 0)
						Console.WriteLine("Nessun libro trovato");
					else
					{
						int k = 0;
						Console.WriteLine("------------------");
						foreach (var item in books)
						{
							k++;
							Console.WriteLine($"{k}) Titolo: {item.Title}, Authore: {item.Author}, Anno: {item.Year}");
						}
						Console.WriteLine("------------------");
					}
				}
				break;
			case 4:
				int counter = 0;
				Console.WriteLine("------------------");
				foreach (var item in library.Books)
				{
					counter++;
					Console.WriteLine($"{counter}) Titolo: {item.Title}, Authore: {item.Author}, Anno: {item.Year}");
				}
				Console.WriteLine("------------------");
				break;
			case 5:
				continua = false; // Per uscire dal ciclo while
				break;
			default:
				Console.WriteLine("Altro");
				break;

		}
	}
	else
	{
		Console.WriteLine("La scelta inserita non è corretta");
	}
}
Console.WriteLine("Grazie per aver usato il programma");


