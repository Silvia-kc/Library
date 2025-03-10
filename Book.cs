using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
		private string title;
		public string Title
		{
			get { return title; }
			set { title = value; }
		}
		private string author;
		public string Author
		{
			get { return author; }
			set { author = value; }
		}
		private string genre;
		public string Genre
		{
			get { return genre; }
			set { genre = value; }
		}
		private int availableCopies;
		public int AvailableCopies
		{
			get { return availableCopies; }
			set { availableCopies = value; }
		}
		private int numberOfTotalTimesBorrowed;
		public int NumberOfTotalTimesBorrowed
        {
			get { return numberOfTotalTimesBorrowed; }
			set { numberOfTotalTimesBorrowed = value; }
		}
		public Book(string title, string suthor, string genre, int availableCopies, int numberOfTotalTimesBorrowed)
		{
			Title = title;
			Author = suthor;
			Genre = genre;
			AvailableCopies = availableCopies;
			NumberOfTotalTimesBorrowed= numberOfTotalTimesBorrowed;
		}
	}
}
