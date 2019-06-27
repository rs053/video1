using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace video
{       
    class dataoperation
    {
        SqlDataAdapter adap = new SqlDataAdapter();
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        DataSet d = new DataSet();
        string getpath()
        {
            string[] str2 = new string[1];
            str2[0] = "bin";
            string str = System.IO.Directory.GetCurrentDirectory().ToString();
            string[] str1 = str.Split(str2, StringSplitOptions.None);
            return (str1[0]);
        }
        public int getmaxmovieid()
        {
            string str = getpath();
            con.Close();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravid\Desktop\video\video\video\Database2.mdf;Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "select max(MovieID) from Movies";
            adap.SelectCommand = com;
            com.Connection = con;
            con.Open();
            adap.Fill(d);
            int id = Convert.ToInt16(d.Tables[0].Rows[0][0]);
            return (id);
        }
        public bool insertnewmovie(string movieid, string rating, string title, string year, string copies, string plot, string genre)
        {
            con.Close();
            string str = getpath();
            int year1 = Convert.ToInt16(year);
            string rent = "";
            if (2019 - year1 > 5)
            {
                rent = "2";
            }
            else
            {
                rent = "5";
            }

            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravid\Desktop\video\video\video\Database2.mdf;Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into Movies values('" + rating + "','" + title + "','" + year + "'," + rent + ",'" + copies + "','" + plot + "','" + genre + "')";

            adap.InsertCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            return (true);
        }
        public DataSet moviedata(string movieid)
        {
            string str = getpath();
            con.Close();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravid\Desktop\video\video\video\Database2.mdf;Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from Movies where movieid=" + movieid;
            adap.SelectCommand = com;
            com.Connection = con;
            con.Open();
            adap.Fill(d);
            return (d);
        }
        public bool updatemovie(string movieid, string rating, string title, string year, string copies, string plot, string genre)
        {
            con.Close();
            string str = getpath();
            int year1 = Convert.ToInt16(year);
            string rent = "";
            if (2019 - year1 > 5)
            {
                rent = "2";
            }
            else
            {
                rent = "5";
            }

            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravid\Desktop\video\video\video\Database2.mdf;Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "update Movies set Rating='" + rating + "',Title='" + title + "',Year='" + year + "',Rental_Cost=" + rent + ",Copies='" + copies + "',Plot='" + plot + "',Genre='" + genre + "' where MovieID=" + movieid;

            adap.UpdateCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            return (true);
        }
        public bool deletemovie(string movieid)
        {
            con.Close();
            string str = getpath();


            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravid\Desktop\video\video\video\Database2.mdf;Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "delete Movies where MovieID=" + movieid;

            adap.DeleteCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            return (true);
        }

        public bool addcustomer(string fname, string lname, string address, string phone)
        {
            con.Close();
            string str = getpath();


            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravid\Desktop\video\video\video\Database2.mdf;Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into Customer (FirstName,LastName,Address,Phone)values('" + fname + "','" + lname + "','" + address + "','" + phone + "')";

            adap.InsertCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            return (true);
        }
        public bool updatecustomer(string custid, string fname, string lname, string address, string phone)
        {
            con.Close();
            string str = getpath();


            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravid\Desktop\video\video\video\Database2.mdf;Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "update Customer set FirstName='" + fname + "',LastName='" + lname + "',Address='" + address + "',Phone='" + phone + "' where CustID=" + custid;

            adap.UpdateCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            return (true);
        }
        public bool deletecustomer(string custid)
        {
            con.Close();
            string str = getpath();


            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravid\Desktop\video\video\video\Database2.mdf;Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "delete from Customer where CustID=" + custid;

            adap.DeleteCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            return (true);
        }
        public bool issuemovie(string movieid, string custid, string daterented)
        {
            con.Close();
            string str = getpath();


            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravid\Desktop\video\video\video\Database2.mdf;Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into RentedMovies (MovieIDFK,CustIDFK,DateRented)values(" + movieid + "," + custid + ",'" + daterented + "')";

            adap.InsertCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            return (true);
        }
        public bool returnmovie(string rmid, string returndate)
        {
            con.Close();
            string str = getpath();


            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravid\Desktop\video\video\video\Database2.mdf;Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "update RentedMovies set DateReturned='" + returndate + "' where RMID=" + rmid;

            adap.UpdateCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            return (true);
        }
        public DataSet showcurrent()
        {
            string str = getpath();
            con.Close();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravid\Desktop\video\video\video\Database2.mdf;Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from Movies where year='2019'";
            adap.SelectCommand = com;
            com.Connection = con;
            con.Open();
            adap.Fill(d);
            return (d);
        }
        public DataSet mostpopular()
        {
            string str = getpath();
            con.Close();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravid\Desktop\video\video\video\Database2.mdf;Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from Movies where  MovieID in (select MovieIDFK from RentedMovies)";
            adap.SelectCommand = com;
            com.Connection = con;
            con.Open();
            adap.Fill(d);
            return (d);
        }
    }
}
