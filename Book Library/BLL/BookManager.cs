using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;
namespace BLL
{
    public class BookManager
    {
        public static bool addbook(Book b)
        {
            return (BookConnected.addbook(b));
        }
        public static List<Book> GetBooks()
        {
            return (BookConnected.GetBooks());
        }
        public static Book getbook(int id)
        {

            return (BookConnected.getbook(id));
        }
        public static bool updatebook(Book b)
        {
            return (BookConnected.update(b));
        }
        public static bool deletebook(int id)
        {
            return (BookConnected.deletebook(id));
        }
        public static Book searchbook(string title)
        {

            return (BookConnected.searchbook(title));
        }
    }
}
