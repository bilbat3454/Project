using System.Data.SQLite;

public class OrderDb
{
    public static void CreateTable(SQLiteConnection conn)
    {
        // SQL statement for creating a new table
        string sql =
            "CREATE TABLE IF NOT EXISTS Order (\n"
            + "   ID integer PRIMARY KEY\n"
            + "   ,OrderNum integer\n"
            + "   ,OrderDate varchar(20)\n"
            + "   ,ShippingStatus bool);"

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddOrder(SQLiteConnection conn, Order o)
    {
        string sql = string.Format(
            "INSERT INTO Customer(OrderNum, OrderDate, ShippingStatus) "
            + "VALUES({0},'{1}',{2})",
            o.OrderNum, o.OrderDate, o.ShippingStatus);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void UpdateOrder(SQLiteConnection conn, Order o)
    {
        string sql = string.Format(
            "UPDATE Customer SET OrderNum={0}, OrderDate='{1}', ShippingStatus={2}"
            + " WHERE ID={3}", o.OrderNum, o.OrderDate, o.ShippingStatus, o.ID);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void DeleteOrder(SQLiteConnection conn, int id)
    {
        string sql = string.Format("DELETE from Order WHERE ID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static List<Order> GetAllOrders(SQLiteConnection conn)
    {
        List<Order> order = new List<Order>();
        string sql = "SELECT * FROM Order";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            customer.Add(new Order(
                rdr.GetInt32(0),
                rdr.GetInt32(1),
                rdr.GetString(2),
                rdr.GetString(3)
            ));
        }

        return order;
    }

    public static Order GetOrder(SQLiteConnection conn, int id)
    {
        string sql = string.Format("SELECT * FROM Order WHERE ID = {0}", id);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        if (rdr.Read())
        {
            return new Order(
                rdr.GetInt32(0),
                rdr.GetInt32(1),
                rdr.GetString(2),
                rdr.GetString(3)
            );
        }
        else
        {
            return new Order(-1, string.Empty, string.Empty, -1);
        }
    }
}