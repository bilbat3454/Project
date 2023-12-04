using System.Data.SQLite;

public class ClothingDb
{
    public static void CreateTable(SQLiteConnection conn)
    {
        // SQL statement for creating a new table
        string sql =
            "CREATE TABLE IF NOT EXISTS Clothing (\n"
            + "   ID integer PRIMARY KEY\n"
            + "   ,ClothingID integer\n"
            + "   ,ClothingName varchar(40)\n"
            + "   ,Qty integer\n"
            + "   ,Cost integer\n"
            + "   ,BackorderStatus bool);"

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddClothing(SQLiteConnection conn, Clothing cl)
    {
        string sql = string.Format(
            "INSERT INTO Clothing(ClothingID, ClothingName, Qty, Cost, BackorderStatus) "
            + "VALUES({0},'{1}', {2}, {3}, {4})",
            cl.ClothingID, cl.ClothingName, cl.Qty, cl.Cost, cl.BackorderStatus);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void UpdateClothing(SQLiteConnection conn, Clothing cl)
    {
        string sql = string.Format(
            "UPDATE Clothing SET ClothingID={0}, ClothingName='{1}', Qty={2}, Cost={3}, BackorderStatus={4}"
            + " WHERE ID={5}", cl.ClothingID, cl.ClothingName, cl.Qty, cl.Cost, cl.BackorderStatus, cl.ID);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void DeleteClothing(SQLiteConnection conn, int id)
    {
        string sql = string.Format("DELETE from Clothing WHERE ID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static List<Clothing> GetAllClothing(SQLiteConnection conn)
    {
        List<Clothing> clothing = new List<Clothing>();
        string sql = "SELECT * FROM Clothing";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            clothing.Add(new Clothing(
                rdr.GetInt32(0),
                rdr.GetInt32(1),
                rdr.GetString(2),
                rdr.GetInt32(3),
                rdr.GetInt32(4),
                rdr.GetString(5)
            ));
        }

        return clothing;
    }

    public static Clothing GetClothing(SQLiteConnection conn, int id)
    {
        string sql = string.Format("SELECT * FROM Clothing WHERE ID = {0}", id);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        if (rdr.Read())
        {
            return new Clothing(
                rdr.GetInt32(0),
                rdr.GetInt32(1),
                rdr.GetString(2),
                rdr.GetInt32(3),
                rdr.GetInt32(4),
                rdr.GetString(5)  
            );
        }
        else
        {
            return new Clothing(-1, string.Empty, string.Empty, -1);
        }
    }
}