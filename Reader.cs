using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Reader
    {
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private int identificationNumber;
		public int IdentificationNumber
		{
			get { return identificationNumber; }
			set { identificationNumber = value; }
		}
		private int age;
		public int Age
		{
			get { return age; }
			set { age = value; }
		}
		private List<Book> books;
		public List<Book> Books
		{
			get { return books; }
			set { books = value; }
		}
		public Reader(string name, int identificationNumber, int age, List<Book> books)
		{
			Name = name;
			IdentificationNumber = identificationNumber;
			Age = age;
			Books = new List<Book>();
		}
	}
}
