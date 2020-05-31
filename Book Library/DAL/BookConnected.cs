using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BOL;
namespace DAL
{   public class BookConnected
    {
        public static string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\CDAC\Ms DotNet\Book Library\Book Library\App_Data\Book.mdf;Integrated Security=True";
    
         public static bool addbook(Book b)
        {
            bool status = false;

            string sqlquery = "insert into Book(title, author,ISBN,publisher,year) values(@title, @author, @ISBN,@publisher,@year) ";

            IDbConnection con = new SqlConnection();
        con.ConnectionString = constring;

            IDbCommand cmd = new SqlCommand();
        cmd.Connection = con;
            cmd.CommandText = sqlquery;

            cmd.Parameters.Add(new SqlParameter("@title", b.title));
            cmd.Parameters.Add(new SqlParameter("@author", b.author));
            cmd.Parameters.Add(new SqlParameter("@ISBN", b.ISBN));
            cmd.Parameters.Add(new SqlParameter("@publisher", b.publisher));
            cmd.Parameters.Add(new SqlParameter("@year",b.year));

            con.Open();

            int reader = cmd.ExecuteNonQuery();
            if (reader > 0)
            {
                status = true;
            }
             con.Close();
            return status;
        }


        public static List<Book> GetBooks()
        {
            List<Book> Books = new List<Book>();

            string sqlquery = "select * from Book";

            IDbConnection con = new SqlConnection();
            con.ConnectionString = constring;

            IDbCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sqlquery;

            con.Open();

            IDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    Book b = new Book();

                    b.serno = int.Parse(reader["Id"].ToString());
                    b.title = reader["title"].ToString();
                    b.author = reader["author"].ToString();
                    b.ISBN = reader["ISBN"].ToString();
                    b.publisher = reader["publisher"].ToString();
                    b.year = reader["year"].ToString();
                    Books.Add(b);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }

            return Books;

        }

        public static bool deletebook(int serno)
        {
            bool status = false;

            string sqlquery = "delete from Book where Id=@serno";

            IDbConnection con = new SqlConnection();
            con.ConnectionString = constring;

            IDbCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sqlquery;

            cmd.Parameters.Add(new SqlParameter("@serno", serno));
            con.Open();

            int reader = cmd.ExecuteNonQuery();
            if (reader > 0) 
            {
                status = true;
            }

            con.Close();
            return status;

        }

        public static bool update(Book b)
        {
            bool status = false;

            string sqlquery = "update Book set title=@title,author=@author,ISBN=@isbn,publisher=@publisher,year=@year where Id=@id";

            IDbConnection con = new SqlConnection();
            con.ConnectionString = constring;

            IDbCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sqlquery;
            cmd.Parameters.Add(new SqlParameter("@id", b.serno));
            cmd.Parameters.Add(new SqlParameter("@title", b.title));
            cmd.Parameters.Add(new SqlParameter("@author", b.author));
            cmd.Parameters.Add(new SqlParameter("@isbn", b.ISBN));
            cmd.Parameters.Add(new SqlParameter("@publisher", b.publisher));
            cmd.Parameters.Add(new SqlParameter("@year", b.year));
            con.Open();

            int i = cmd.ExecuteNonQuery();
            if (i == 1)
            {
                status = true;
            }
            con.Close();
            return status;

        }
      
        public static Book getbook(int id)
        {
            Book b = new Book();
            string sqlquery = "select * from Book where Id=@id";

            IDbConnection con = new SqlConnection();
            con.ConnectionString = constring;

            IDbCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sqlquery;

            cmd.Parameters.Add(new SqlParameter("@id", id));
            con.Open();

            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                b.serno = int.Parse(reader["Id"].ToString());
                b.title = reader["title"].ToString();
                b.author = reader["author"].ToString();
                b.ISBN = reader["ISBN"].ToString();
                b.publisher = reader["publisher"].ToString();
                b.year = reader["year"].ToString();
            }
            con.Close();
            return b;

        }
        public static Book searchbook(string title)
        {
            Book b = new Book();
            string sqlquery = "select * from Book where title=@title";

            IDbConnection con = new SqlConnection();
            con.ConnectionString = constring;

            IDbCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sqlquery;

            cmd.Parameters.Add(new SqlParameter("@title", title));
            con.Open();

            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                b.serno = int.Parse(reader["Id"].ToString());
                b.title = reader["title"].ToString();
                b.author = reader["author"].ToString();
                b.ISBN = reader["ISBN"].ToString();
                b.publisher = reader["publisher"].ToString();
                b.year = reader["year"].ToString();
            }
            con.Close();
            return b;

        }
        public static bool checkbook(string title)
        {
            Book b = new Book();
            string sqlquery = "select * from Book where title=@title";

            IDbConnection con = new SqlConnection();
            con.ConnectionString = constring;

            IDbCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sqlquery;

            cmd.Parameters.Add(new SqlParameter("@title", title));
            con.Open();

            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            con.Close();
            return false;

        }

    }

}




