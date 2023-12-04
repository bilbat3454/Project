using System.Data.SQLite;

public class CustomerDb
{
    public static void CreateTable(SQLiteConnection conn)
    {
        // SQL statement for creating a new table
        string sql =
            "CREATE TABLE IF NOT EXISTS Customer (\n"
            + "   ID integer PRIMARY KEY\n"
            + "   ,Name varchar(40)\n"
            + "   ,Address varchar(40)\n"
            + "   ,CustomerID integer);"

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddCustomer(SQLiteConnection conn, Customer c)
    {
        string sql = string.Format(
            "INSERT INTO Customer(Name, Address, CustomerID) "
            + "VALUES('{0}','{1}',{2})",
            c.Name, c.Address, c.CustomerID);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void UpdateCustomer(SQLiteConnection conn, Customer c)
    {
        string sql = string.Format(
            "UPDATE Customer SET Name='{0}', Address='{1}', CustomerID={2}"
            + " WHERE ID={3}", c.Name, c.Address, c.CustomerID, c.ID);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void DeleteCustomer(SQLiteConnection conn, int id)
    {
        string sql = string.Format("DELETE from Customer WHERE ID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static List<Customer> GetAllCustomers(SQLiteConnection conn)
    {
        List<Customer> customer = new List<Customer>();
        string sql = "SELECT * FROM Customer";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            customer.Add(new Customer(
                rdr.GetInt32(0),
                rdr.GetString(1),
                rdr.GetString(2),
                rdr.GetInt32(3)
            ));
        }

        return customer;
    }

    public static Customer GetCustomer(SQLiteConnection conn, int id)
    {
        string sql = string.Format("SELECT * FROM Customer WHERE ID = {0}", id);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        if (rdr.Read())
        {
            return new Customer(
                rdr.GetInt32(0),
                rdr.GetString(1),
                rdr.GetString(2),
                rdr.GetInt32(3) 
            );
        }
        else
        {
            return new Customer(-1, string.Empty, string.Empty, -1);
        }
    }
}