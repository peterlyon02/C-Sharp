using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
	internal class BookDB
	{
		public BookDB(int IDBook, string title, string author, int year) 
		{
			this.IDBook = IDBook;
			this.Title = title;
			this.Author = author;
			this.Year = year;
		}

		public int IDBook { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
        public int Year { get; set; }
    }
}
