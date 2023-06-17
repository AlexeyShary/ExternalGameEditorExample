using System.Data.SQLite;
using System.IO;

namespace EditorExample.Service;

public class DatabaseService
{
    private readonly string databasePath = Path.Combine("..", "..", "..", "..", "UnityGame", "Assets",
        "StreamingAssets",
        "ExampleDB.bytes");

    private readonly SQLiteConnection dbConnection;

    private DatabaseService()
    {
        dbConnection = new SQLiteConnection($"Data Source={databasePath};Version=3;");
        dbConnection.Open();
    }

    public SQLiteCommand CreateSQLiteCommand(string query)
    {
        return new SQLiteCommand(query, dbConnection);
    }

    ~DatabaseService()
    {
        dbConnection.Close();
    }

    #region Singletone

    private static DatabaseService _instance;

    public static DatabaseService Instance => _instance ?? (_instance = new DatabaseService());

    #endregion
}