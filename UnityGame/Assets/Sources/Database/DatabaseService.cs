using System.Data;
using Mono.Data.Sqlite;
using Sources.Database.DAO;
using UnityEngine;

namespace Sources.Database
{
    public class DatabaseService
    {
        private const string DATABASE_NAME = "ExampleDB.bytes";

        private readonly IDbConnection dbConnection;

        public CharacterActionDao CharacterActionDao { get; private set; }
        public CharacterDao CharacterDao { get; private set; }
        public LocationObjectDao LocationObjectDao { get; private set; }
        
        private DatabaseService()
        {
            dbConnection = new SqliteConnection("URI=file:" + Application.streamingAssetsPath + "/" + DATABASE_NAME);
            dbConnection.Open();

            CharacterActionDao = new CharacterActionDao();
            CharacterDao = new CharacterDao();
            LocationObjectDao = new LocationObjectDao();
        }

        internal IDbCommand CreateCommand()
        {
            return dbConnection.CreateCommand();
        }

        ~DatabaseService()
        {
            dbConnection.Close();
        }

        #region Singletone

        private static DatabaseService _instance;

        public static DatabaseService Instance => _instance ??= new DatabaseService();

        #endregion
    }
}