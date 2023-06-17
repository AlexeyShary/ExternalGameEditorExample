using System.Collections.Generic;
using EditorExample.Model;
using EditorExample.Service;

namespace EditorExample.DAO;

public static class CharacterDao
{
    public static List<CharacterEntity> GetFullList()
    {
        const string query = "SELECT CHARACTER_ID, CHARACTER_NAME, CHARACTER_SPRITE FROM CHARACTERS";
        var result = new List<CharacterEntity>();

        using var command = DatabaseService.Instance.CreateSQLiteCommand(query);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var instance = new CharacterEntity
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Sprite = reader.GetString(2)
            };
            result.Add(instance);
        }

        return result;
    }

    public static void AddEntity()
    {
        const string query = "INSERT INTO CHARACTERS (CHARACTER_NAME, CHARACTER_SPRITE) VALUES (@Name, '-')";

        using var command = DatabaseService.Instance.CreateSQLiteCommand(query);
        command.Parameters.AddWithValue("@Name", "New Character");
        command.ExecuteNonQuery();
    }

    public static void DeleteEntity(int id)
    {
        const string query = "DELETE FROM CHARACTERS WHERE CHARACTER_ID = @Id";

        using var command = DatabaseService.Instance.CreateSQLiteCommand(query);
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();
    }

    public static void SaveChanges(CharacterEntity characterEntity)
    {
        const string query =
            "UPDATE CHARACTERS SET CHARACTER_NAME = @Name, CHARACTER_SPRITE = @Sprite WHERE CHARACTER_ID = @Id";

        using var command = DatabaseService.Instance.CreateSQLiteCommand(query);
        command.Parameters.AddWithValue("@Name", characterEntity.Name);
        command.Parameters.AddWithValue("@Sprite", characterEntity.Sprite);
        command.Parameters.AddWithValue("@Id", characterEntity.Id);
        command.ExecuteNonQuery();
    }
}