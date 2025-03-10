// See https://aka.ms/new-console-template for more information
using Library;
using System.Reflection.PortableExecutable;
List<Book> books = new List<Book>();
List<Reader> readers= new List<Reader>();
List<Borrowing> borrowings= new List<Borrowing>();
while (true)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1.Enter book");
    Console.WriteLine("2.Enter reader");
    Console.WriteLine("3.Borrow book");
    Console.WriteLine("4.All the books in the library");
    Console.WriteLine("5.All readers");
    Console.WriteLine("6.Books borrowed by a given reader");
    Console.WriteLine("7.Readers with active loans");
    Console.WriteLine("8.All available books");
    Console.WriteLine("9.Late returns");
    Console.WriteLine("10.Most borrowed books");
    Console.WriteLine("11.Exit");
    int num = int.Parse(Console.ReadLine());
    if (num == 11)
    {
        break;
    }
    switch (num)
    {
        case 1:
            AddBook();
            break;
        case 2:
            AddReader();
            break;
        case 3:
            Console.WriteLine("Enter book title: ");
            string title = Console.ReadLine();
            Book book = books.FirstOrDefault(b => b.Title == title);
            Console.WriteLine("Enter reader id: ");
            int id = int.Parse(Console.ReadLine());
            Reader reader = readers.FirstOrDefault(r => r.IdentificationNumber == id);
            BorrowingBook(book, reader);
            break;
        case 4:
            AllBooks();
            break;
        case 5:
            AllReaders();
            break;
        case 6:
            Console.WriteLine("Enter reader id: ");
            int id2 = int.Parse(Console.ReadLine());
            Reader reader2 = readers.FirstOrDefault(r => r.IdentificationNumber == id2);
            BooksBorrowedByGivenReader(reader2);
            break;
        case 7:
            ReadersWithActiveLoans();
            break;
            break;
        case 8:
            AllAvailableBooks();
            break;
        case 9:
            LateReturns();
            break;
        case 10:
            TheMostBorrowedBooks();
            break;
        case 11:
            Console.WriteLine();
            break;
        default:
            Console.WriteLine("This option does nit exist!");
            break;
    }
}
void AddBook()
{
    Console.WriteLine("Enter book title: ");
    string title = Console.ReadLine();
    Console.WriteLine("Enter the author of the book: ");
    string author= Console.ReadLine();
    Console.WriteLine("Enter the genre of the book: ");
    string genre= Console.ReadLine();
    Console.WriteLine("Enter available copies: ");
    int availableCopies=int.Parse(Console.ReadLine());
    Console.WriteLine("Enter number of total times borrowed");
    int numberOfTotalTimesBorrowed=int.Parse(Console.ReadLine());
    Book book = new Book(title, author, genre, availableCopies, numberOfTotalTimesBorrowed);
    books.Add(book);
}
void AddReader()
{
    Console.WriteLine("Enter reader name: ");
    string name = Console.ReadLine();
    Console.WriteLine("Enter reader id: ");
    int id=int.Parse(Console.ReadLine());
    Console.WriteLine("Enter age of the reader: ");
    int age=int.Parse(Console.ReadLine());
    List<Book> books= new List<Book>();
    Reader reader = new Reader(name, id, age, books);
    readers.Add(reader);
}
void BorrowingBook(Book book, Reader reader)
{
    if (book.AvailableCopies > 0)
    {
        DateTime borrowingDate = DateTime.Now;
        DateTime? returnDate = borrowingDate.AddDays(30);
        Borrowing borrowing = new Borrowing(reader, book, borrowingDate, returnDate);
        book.NumberOfTotalTimesBorrowed++;
        book.AvailableCopies--;
        borrowings.Add(borrowing);
    }
    else
    {
        Console.WriteLine("There are no copies.");
    }
    
}
void AllBooks()
{
    foreach (Book book in books)
    {
        Console.WriteLine(book.Title);
    }
}
void AllReaders()
{
    foreach(Reader reader in readers)
    {
        Console.WriteLine(reader.Name);
    }
}
void BooksBorrowedByGivenReader(Reader reader)
{
    foreach(Book book in reader.Books)
    {
        Console.WriteLine(book.Title);
    }
}
void ReadersWithActiveLoans()
{
    foreach(var borrowing in borrowings)
    {
        if(borrowing.Reader.Books!=null)
        {
            Console.WriteLine(borrowing.Reader.Name);
        }
    }
}
void AllAvailableBooks()
{
    foreach(var book in books)
    {
       if( book.AvailableCopies>0)
       {
            Console.WriteLine(book.Title);
       }
    }
}
void LateReturns()
{
    DateTime maxDay = DateTime.Now.AddDays(-30);
    foreach (var borrowing in borrowings)
    {
        if (maxDay>borrowing.BorrowingDate && borrowing.ReturnDate==null)
        {
            Console.WriteLine(borrowing.Book.Title, borrowing.Reader.Name, borrowing.ReturnDate);
        }
    }
}
void TheMostBorrowedBooks()
{
    foreach(var borrowing in borrowings.OrderByDescending(b=>b.Book.NumberOfTotalTimesBorrowed).Take(3))
    {
        Console.WriteLine(borrowing.Book.Title);
    }
}