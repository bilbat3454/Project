using System.Data.SQLite;

public class MembershipDb
{
    public static void CreateTable(SQLiteConnection conn)
    {
        // SQL statement for creating a new table
        string sql =
            "CREATE TABLE IF NOT EXISTS Membership (\n"
            + "   ID integer PRIMARY KEY\n"
            + "   ,MemberStatus bool);"

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddMembership(SQLiteConnection conn, Membership m)
    {
        string sql = string.Format(
            "INSERT INTO Customer(MemberStatus) "
            + "VALUES({0})",
            m.MemberStatus);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void UpdateMembership(SQLiteConnection conn, Membership m)
    {
        string sql = string.Format(
            "UPDATE Membership SET MemberStatus={0}"
            + " WHERE ID={1}", m.MemberStatus, m.ID);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void DeleteMembership(SQLiteConnection conn, int id)
    {
        string sql = string.Format("DELETE from Membership WHERE ID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static List<Membership> GetAllMemberships(SQLiteConnection conn)
    {
        List<Membership> membership = new List<Membership>();
        string sql = "SELECT * FROM Membership";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            customer.Add(new Membership(
                rdr.GetInt32(0),
                rdr.GetString(1)
            ));
        }

        return membership;
    }

    public static Membership GetMembership(SQLiteConnection conn, int id)
    {
        string sql = string.Format("SELECT * FROM Membership WHERE ID = {0}", id);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        if (rdr.Read())
        {
            return new Membership(
                rdr.GetInt32(0),
                rdr.GetString(1)
            );
        }
        else
        {
            return new Membership(-1, string.Empty, string.Empty, -1);
        }
    }
}