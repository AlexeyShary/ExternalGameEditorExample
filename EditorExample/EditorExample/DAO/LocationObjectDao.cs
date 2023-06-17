using System.Collections.Generic;
using EditorExample.Model;
using EditorExample.Service;

namespace EditorExample.DAO;

public static class LocationObjectDao
{
    public static List<LocationObjectEntity> GetFullList()
    {
        const string query = "SELECT LOCATION_OBJECT_ID, CHARACTER_ID, SPAWN_POS_X, SPAWN_POS_Y FROM LOCATION_1";
        var result = new List<LocationObjectEntity>();

        using var command = DatabaseService.Instance.CreateSQLiteCommand(query);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var instance = new LocationObjectEntity
            {
                Id = reader.GetInt32(0),
                CharacterId = reader.GetInt32(1),
                SpawnPosX = reader.GetInt32(2),
                SpawnPosY = reader.GetInt32(3)
            };
            result.Add(instance);
        }

        return result;
    }

    public static void AddEntity()
    {
        const string query = "INSERT INTO LOCATION_1 (CHARACTER_ID, SPAWN_POS_X, SPAWN_POS_Y) VALUES ('0', '0', '0')";

        using var command = DatabaseService.Instance.CreateSQLiteCommand(query);
        command.ExecuteNonQuery();
    }

    public static void DeleteEntity(int id)
    {
        const string query = "DELETE FROM LOCATION_1 WHERE LOCATION_OBJECT_ID = @Id";

        using var command = DatabaseService.Instance.CreateSQLiteCommand(query);
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();
    }

    public static void SaveChanges(LocationObjectEntity locationObjectEntity)
    {
        const string query =
            "UPDATE LOCATION_1 SET CHARACTER_ID = @CharacterId, SPAWN_POS_X = @PosX, SPAWN_POS_Y = @PosY WHERE LOCATION_OBJECT_ID = @Id";

        using var command = DatabaseService.Instance.CreateSQLiteCommand(query);
        command.Parameters.AddWithValue("@CharacterId", locationObjectEntity.CharacterId);
        command.Parameters.AddWithValue("@PosX", locationObjectEntity.SpawnPosX);
        command.Parameters.AddWithValue("@PosY", locationObjectEntity.SpawnPosY);
        command.Parameters.AddWithValue("@Id", locationObjectEntity.Id);
        command.ExecuteNonQuery();
    }
}