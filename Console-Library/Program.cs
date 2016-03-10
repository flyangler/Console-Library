using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Library
{
    class Program
    {
        static void Main(string[] args)
        {
   
            var startLeft = Console.CursorLeft;
            var startTop = Console.CursorTop;

            var MyLibrary = new Library();
            MyLibrary.PopulateLibrary();
            MyLibrary.DisplayHome();
            return;
            //Puts books in Library

            //Console.WriteLine(MyLibrary.Books[0].Title);
            MyLibrary.SelectBook();
            Console.WriteLine("You have checked out " + MyLibrary.CurrentlyCheckedOut.Title);
            Console.Clear();
            Console.SetCursorPosition(startLeft, startTop);
            MyLibrary.Librarian();
            
            Console.ReadLine();
        }
    }
}

/*Select a Book to Checkout:

1. 
2. 
3. 
4. 
5. Return Book

Checkout();
//SelectBook will need to check the users input and validate the input is a valid
SelectBook()
//ReturnBook is responsible for adding a previously checked out book to be returned to the List of AvailableBooks
ReturnBook()
//When a book is returned display to the console the amount of time the book was absent for.
Bonus Challenge
*/
