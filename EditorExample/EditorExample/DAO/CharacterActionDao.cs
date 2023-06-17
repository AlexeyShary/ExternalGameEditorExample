using System.Collections.Generic;
using EditorExample.Model;
using EditorExample.Service;

namespace EditorExample.DAO;

public static class CharacterActionDao
{
    public static List<CharacterActionEntity> GetFullList(int characterId)
    {
        const string query =
            "SELECT CHARACTER_ACTION_ID, CHARACTER_ID, CHARACTER_ACTION_SCRIPT FROM CHARACTERS_ACTIONS WHERE CHARACTER_ID = @CharacterId";
        var result = new List<CharacterActionEntity>();

        using var command = DatabaseService.Instance.CreateSQLiteCommand(query);
        command.Parameters.AddWithValue("@CharacterId", characterId);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var instance = new CharacterActionEntity
            {
                Id = reader.GetInt32(0),
                CharacterId = reader.GetInt32(1),
                Action = reader.GetString(2)
            };
            result.Add(instance);
        }

        return result;
    }

    public static void AddEntity(int characterId)
    {
        const string query =
            "INSERT INTO CHARACTERS_ACTIONS (CHARACTER_ID, CHARACTER_ACTION_SCRIPT) VALUES (@CharacterId, '-')";

        using var command = DatabaseService.Instance.CreateSQLiteCommand(query);
        command.Parameters.AddWithValue("@CharacterId", characterId);
        command.ExecuteNonQuery();
    }

    public static void DeleteEntity(int id)
    {
        const string query = "DELETE FROM CHARACTERS_ACTIONS WHERE CHARACTER_ACTION_ID = @Id";

        using var command = DatabaseService.Instance.CreateSQLiteCommand(query);
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();
    }

    public static void SaveChanges(CharacterActionEntity characterActionEntity)
    {
        const string query =
            "UPDATE CHARACTERS_ACTIONS SET CHARACTER_ACTION_SCRIPT = @Action WHERE CHARACTER_ACTION_ID = @Id";

        using var command = DatabaseService.Instance.CreateSQLiteCommand(query);
        command.Parameters.AddWithValue("@Action", characterActionEntity.Action);
        command.Parameters.AddWithValue("@Id", characterActionEntity.Id);
        command.ExecuteNonQuery();
    }
}