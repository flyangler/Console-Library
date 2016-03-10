using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Library
{
    public class Library
    {
        public List<Book> Books = new List<Book>();
        public Book CurrentlyCheckedOut;

        public void PopulateLibrary()
        {
            Book book1 = new Book
            {
                Title = "HeadFirst with C#",
                CheckedOut = false,
                //OutTime = DateTime.Now,
                //InTime = DateTime.Now,
            };
            Book book2 = new Book
            {
                Title = "Mastering the Console App",
                CheckedOut = false,
                //OutTime = DateTime.Now,
                //InTime = DateTime.Now,
            };
            Book book3 = new Book
            {
                Title = "C# Game Programming: For Serious Game Creation",
                CheckedOut = false,
                //OutTime = DateTime.Now,
                //InTime = DateTime.Now,
            };
            Book book4 = new Book
            {
                Title = "Pro C# 5.0 and the .NET 4.5 Framework",
                CheckedOut = false,
                //OutTime = DateTime.Now,
                //InTime = DateTime.Now,
            };

            Books.Add(book1);
            Books.Add(book2);
            Books.Add(book3);
            Books.Add(book4);
        }

        public void ReturnBook(Book book)
        {
            book.CheckedOut = false;
            book.InTime = DateTime.Now;
            Books.Add(book);
            CurrentlyCheckedOut = null;
            Console.WriteLine(book + "was checked out for: " + (book.InTime - book.OutTime));
        }

        public void SelectBook()
        {
            Console.WriteLine("Select a book by number to check out: ");

            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + Books[i].Title);
            }
            var input = Console.ReadLine();
            Validation(input);
        }
        //Helper Method Diamond in the flow Chart
        public void Validation(string shelf)
        {
            if (shelf == "1" || shelf == "2" || shelf == "3" || shelf == "4")
            {
                int select = int.Parse(shelf);
                Checkout(select);
            }
            else
            {
                Console.WriteLine("Sorry invalid choice ");
                SelectBook();
            }
        }
        public void Checkout(int index)
        {
            Book book = Books[index - 1];
            book.CheckedOut = true;
            book.OutTime = DateTime.Now;
            Books.Remove(book);
            CurrentlyCheckedOut = book;
        }

        public void Librarian()
        {

            if (CurrentlyCheckedOut.CheckedOut)
            {
                Console.WriteLine("Do you want to check in a Book? ");
                var Answer = Console.ReadLine();
                if (Answer.ToLower() == "y")
                {
                    ReturnBook(CurrentlyCheckedOut);
                }
                else
                {
                    //Console.WriteLine("Do you want to check out a Book? ");
                    return;
                }
            }
        }

        public void DisplayHome()
        {

            Console.Clear();
            Console.WriteLine("-----WELCOME-----");
            Console.WriteLine("Choose from the options below...");
            Console.WriteLine("1. Checkout a book.");
            Console.WriteLine("2. Return a book.");
            Console.WriteLine("3. Exit Library.");
            var choice = Console.ReadKey();
            switch (choice.KeyChar)
            {
                case '1':
                    DisplayCheckout();
                    break;
                case '2':
                    DisplayCheckin();
                    break;
                case '3':
                    return;
                default:
                    DisplayHome();
                    break;
            }

        }

        public void DisplayCheckout()
        {
            Console.Clear();
            Console.WriteLine("-----WELCOME-----");
            Console.WriteLine("Choose a book to checkout...");
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + Books[i].Title);
            }
            Console.WriteLine("Press r to Return To Home.");
            var choiceKey = Console.ReadKey();

            int choice;
            if (!int.TryParse(choiceKey.KeyChar.ToString(), out choice))
            {
                if(choiceKey.KeyChar == 'r')
                {
                    DisplayHome();
                    return;
                }
                DisplayCheckout();
                return;
            };

            if((choice+1) > Books.Count)
            {
                DisplayCheckout();
            }

            var book = Books[choice - 1];
            Console.WriteLine();
            ShowSpinner(3000, "Checking out " + book.Title);
            Console.WriteLine();
            Console.WriteLine("You checked out " + book.Title + " at" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss a"));
            Thread.Sleep(2000);
            DisplayCheckout();

        }

        public void DisplayCheckin()
        {

            Console.Clear();
            Console.WriteLine("-----Book Return-----");
            Console.WriteLine("Choose from the options below...");

        }

        public void ShowSpinner(int timeInMilliseconds, string message, int speed = 200)
        {
            var spinner = @"|/-\";
            var timeout = DateTime.Now.AddMilliseconds(timeInMilliseconds);
            while (DateTime.Now < timeout)
            {
                foreach (var c in spinner)
                {
                    Console.Write("\r" + c + " " + message);
                    Thread.Sleep(speed);
                }
            }
        }

    }
}
