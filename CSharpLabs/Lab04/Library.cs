using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
	internal class Library
	{
		string folderPath = "D:\\Materiale Corsi\\ENAIP\\CSharp\\Mod01\\CSharpLabs\\Lab04\\Library";
		string nomeFile = "catalog.txt";

		internal Library() 
		{
			// Creazione della cartella Library
			Directory.CreateDirectory(folderPath);
			// Creazione del file catalog.txt nella cartella Library (se non preesistente)
			if (!File.Exists(folderPath + "\\" + nomeFile))
				File.Create(folderPath + "\\" + nomeFile);

			// Inizializzazione della collezione di libri della biblioteca
			ReadFromCatalog(); 
		}
		internal List<Book> Books { get; private set; }

		// Aggiungere un libro alla collezione Books
		internal void AddBook(string title, string author, int year)
		{
			// Istanziare un oggetto di tipo Book
			Book book = new Book(title, author, year);
			// Aggiungo l'oggetto alla collezione
			Books.Add(book);
			// Salvataggio delle modifiche su file
			AddToCatalog(title, author, year);
		}
		
		// Rimuove tutti i libri con Title = title assegnato
		internal int RemoveBooks(string title)
		{
			var elements = Books.FindAll(b => b.Title == title);
			foreach (Book book in elements)
			{
				Books.Remove(book);
			}
			// Salvo la modifica nel file
			SaveToCatalog();
			return elements.Count;
		}
		
		// Restituisce l'elenco di tutti i libri contenenti una parola nel titolo
		internal List<Book> FindByTitle(string keyword) 
		{
			var elements = Books.Where(b => b.Title.Contains(keyword, StringComparison.InvariantCultureIgnoreCase));
			return elements.ToList();
		}
		internal List<Book> FindByYear(int year)
		{
			var elements = Books.Where(b => b.Year == year);
			return elements.ToList();
		}
		internal List<Book> FindByAuthor(string author)
		{
			var elements = Books.Where(b => b.Author.Contains(author, StringComparison.InvariantCultureIgnoreCase));
			return elements.ToList();
		}
		// Ordinamento con LINQ
		internal void ListBooks(List<Book> books, SortCriteria criteria, SortOrder order)
		{
			int k = 0;
			IOrderedEnumerable<Book> list = null;
			if (criteria == SortCriteria.Year)
			{
				if(order == SortOrder.Ascending)
					list = books.OrderBy(b => b.Year);
				else
					list = books.OrderByDescending(b => b.Year);

			}
			else if (criteria == SortCriteria.Author)
			{
				if (order == SortOrder.Ascending)
					list = books.OrderBy(b => b.Author);
				else
					list = books.OrderByDescending(b => b.Author);

			}
			else if (criteria == SortCriteria.Title)
			{
				if (order == SortOrder.Ascending)
					list = books.OrderBy(b => b.Title);
				else
					list = books.OrderByDescending(b => b.Title);

			}
			foreach (Book book in list)
			{
				k++;
				Console.WriteLine($"{k}) Titolo: {book.Title}, Authore: {book.Author}, Anno: {book.Year}");
			}
		}

		void ReadFromCatalog()
		{
			Books = new List<Book>();
			string[] books = File.ReadAllLines(folderPath + "\\" + nomeFile);
			foreach (string book in books)
			{
				string[] line = book.Split(';');
				Book book1 = new Book(line[0], line[1], int.Parse(line[2]));
				Books.Add(book1);
			}
		}
		void SaveToCatalog()
		{
			List<string> content = new List<string>();
			foreach (Book book in Books) {
				string line = book.Title + ";" + book.Author + ";" + book.Year;
				content.Add(line);
			}
			File.WriteAllLines(folderPath + "\\" + nomeFile, content);
		}
		void AddToCatalog(string title, string author, int year)
		{
			string[] contents = new string[1];
			contents[0] = title + ";" + author + ";" + year;
			File.AppendAllLines(folderPath + "\\" + nomeFile, contents);
		}
	}
	internal enum SortOrder
	{
		Ascending,
		Descending
	}
	internal enum SortCriteria
	{
		Year,
		Author,
		Title
	}
}
