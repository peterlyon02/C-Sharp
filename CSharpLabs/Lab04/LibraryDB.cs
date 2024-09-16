using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
	internal class LibraryDB
	{
        const string connString = "Data Source=LAPTOP-O4PVHI4G;Initial Catalog=LibraryDB;Integrated Security=True;";
		
		internal List<BookDB> ListBooks(SortCriteria criteria, SortOrder order)
		{
			List<BookDB> items = new List<BookDB>();
			using (SqlConnection connection = new SqlConnection(connString))
			{
				SqlCommand cmd = connection.CreateCommand();
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = "sp_SelectAllBooks";

				// Aggiunta parametri di input
				if (criteria == SortCriteria.Title)
					cmd.Parameters.AddWithValue("@SortColumn", "Title");
				else if (criteria == SortCriteria.Author)
					cmd.Parameters.AddWithValue("@SortColumn", "Author");
				else if (criteria == SortCriteria.Year)
					cmd.Parameters.AddWithValue("@SortColumn", "Year");
				if (order == SortOrder.Ascending)
					cmd.Parameters.AddWithValue("@SortOrder", 0);
				else if (order == SortOrder.Descending)
					cmd.Parameters.AddWithValue("@SortOrder", 1);

				connection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						BookDB bookDB = new BookDB(reader.GetInt32(reader.GetOrdinal("IDBook"))
							, reader.GetString(reader.GetOrdinal("Title"))
							, reader.GetString(reader.GetOrdinal("Author"))
							, reader.GetInt32(reader.GetOrdinal("Year")));

						items.Add(bookDB);
					}
				}
			}
			int k = 0;
			int pag = 3;
			int size = 10;
			var objs = items.Select(x => new { x.Title, x.IDBook });
			foreach (var obj in objs)
			{
				Console.WriteLine(obj.Title + " " + obj.IDBook);
			}
			var years = items.Select(b => b.Year).Distinct();
			foreach (BookDB book in items)
			{
				k++;
				Console.WriteLine($"{k}) Titolo: {book.Title}, Autore: {book.Author}, Anno: {book.Year}, Id: {book.IDBook}");
			}

			return items;
		}
		internal List<BookDB> ListBooks(SortCriteria criteria, SortOrder order, int pageSize, int pageNum)
		{
			List<BookDB> items = new List<BookDB>();
			using (SqlConnection connection = new SqlConnection(connString))
			{
				SqlCommand cmd = connection.CreateCommand();
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = "sp_SelectAllBooks";

				// Aggiunta parametri di input
				if (criteria == SortCriteria.Title)
					cmd.Parameters.AddWithValue("@SortColumn", "Title");
				else if (criteria == SortCriteria.Author)
					cmd.Parameters.AddWithValue("@SortColumn", "Author");
				else if (criteria == SortCriteria.Year)
					cmd.Parameters.AddWithValue("@SortColumn", "Year");
				if (order == SortOrder.Ascending)
					cmd.Parameters.AddWithValue("@SortOrder", 0);
				else if (order == SortOrder.Descending)
					cmd.Parameters.AddWithValue("@SortOrder", 1);

				connection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						BookDB bookDB = new BookDB(reader.GetInt32(reader.GetOrdinal("IDBook"))
							, reader.GetString(reader.GetOrdinal("Title"))
							, reader.GetString(reader.GetOrdinal("Author"))
							, reader.GetInt32(reader.GetOrdinal("Year")));

						items.Add(bookDB);
					}
				}
			}
			return items.Skip(pageSize*(pageNum -1)).Take(pageSize).ToList();
		}
		internal void AddBook(string title, string author, int year)
        {
			using (SqlConnection connection = new SqlConnection(connString))
			{
				SqlCommand cmd = connection.CreateCommand();
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = "sp_InsertBook";
				cmd.Parameters.AddWithValue ("@Title", title);
				cmd.Parameters.AddWithValue("@Author", author);
				cmd.Parameters.AddWithValue("@Year", year);

				connection.Open();
				cmd.ExecuteNonQuery();
			}
		}
		internal int UpdateBook(int BookId, string title, string author, int year)
		{
			int rows = 0;
			using (SqlConnection connection = new SqlConnection(connString))
			{
				SqlCommand cmd = connection.CreateCommand();
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = "sp_UpdateBook";
				cmd.Parameters.AddWithValue("@IDBook", BookId);
				if(title.Trim() != "")
					cmd.Parameters.AddWithValue("@Title", title);
				if (author.Trim() != "")
					cmd.Parameters.AddWithValue("@Author", author);
				if (year != 0)
					cmd.Parameters.AddWithValue("@Year", year);

				connection.Open();
				rows = cmd.ExecuteNonQuery();
			}
			return rows;
		}
		internal int RemoveBooks(string title)
        {
			int rows = 0;
			using (SqlConnection connection = new SqlConnection(connString))
			{
				SqlCommand cmd = connection.CreateCommand();
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = "sp_DeleteBooks";
				cmd.Parameters.AddWithValue("@Title", title);

				connection.Open();
				rows = cmd.ExecuteNonQuery();
			}
			return rows;
        }
		internal BookDB FindById(int Id)
		{
			var items = new List<BookDB>();
			using (SqlConnection connection = new SqlConnection(connString))
			{
				SqlCommand cmd = connection.CreateCommand();
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = "sp_FindBooks";
				cmd.Parameters.AddWithValue("@IDBook", Id);

				connection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						BookDB bookDB = new BookDB(reader.GetInt32(reader.GetOrdinal("IDBook"))
							, reader.GetString(reader.GetOrdinal("Title"))
							, reader.GetString(reader.GetOrdinal("Author"))
							, reader.GetInt32(reader.GetOrdinal("Year")));

						items.Add(bookDB);
					}
				}
			}
			return items.SingleOrDefault();
		}
		internal List<BookDB> FindByTitle(string title)
		{
			var items = new List<BookDB>();
			using (SqlConnection connection = new SqlConnection(connString))
			{
				SqlCommand cmd = connection.CreateCommand();
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = "sp_FindBooks";
				cmd.Parameters.AddWithValue("@Title", title);

				connection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						BookDB bookDB = new BookDB(reader.GetInt32(reader.GetOrdinal("IDBook"))
							, reader.GetString(reader.GetOrdinal("Title"))
							, reader.GetString(reader.GetOrdinal("Author"))
							, reader.GetInt32(reader.GetOrdinal("Year")));

						items.Add(bookDB);
					}
				}
			}
			return items;
		}
		internal List<BookDB> FindByAuthor(string author)
		{
			var items = new List<BookDB>();
			using (SqlConnection connection = new SqlConnection(connString))
			{
				SqlCommand cmd = connection.CreateCommand();
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = "sp_FindBooks";
				cmd.Parameters.AddWithValue("@Author", author);

				connection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						BookDB bookDB = new BookDB(reader.GetInt32(reader.GetOrdinal("IDBook"))
							, reader.GetString(reader.GetOrdinal("Title"))
							, reader.GetString(reader.GetOrdinal("Author"))
							, reader.GetInt32(reader.GetOrdinal("Year")));

						items.Add(bookDB);
					}
				}
			}
			return items;
		}
		internal List<BookDB> FindByYear(int? yearstart, int? yearend)
		{
			var items = new List<BookDB>();
			using (SqlConnection connection = new SqlConnection(connString))
			{
				SqlCommand cmd = connection.CreateCommand();
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = "sp_FindBooks";
				if(yearstart.HasValue)
					cmd.Parameters.AddWithValue("@YearStart", yearstart.Value);
				if (yearend.HasValue)
					cmd.Parameters.AddWithValue("@YearEnd", yearend.Value);

				connection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						BookDB bookDB = new BookDB(reader.GetInt32(reader.GetOrdinal("IDBook"))
							, reader.GetString(reader.GetOrdinal("Title"))
							, reader.GetString(reader.GetOrdinal("Author"))
							, reader.GetInt32(reader.GetOrdinal("Year")));

						items.Add(bookDB);
					}
				}
			}
			return items;
		}
	}
}
