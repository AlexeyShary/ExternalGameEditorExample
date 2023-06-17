using System;
using Sources.Database.Model;

namespace Sources.Database.DAO
{
    public class CharacterDao
    {
        public CharacterEntity GetById(int id)
        {
            using var command = DatabaseService.Instance.CreateCommand();
            command.CommandText = "SELECT CHARACTER_ID, CHARACTER_NAME, CHARACTER_SPRITE FROM CHARACTERS WHERE CHARACTER_ID = @Id";
            command.AddParameter("@Id", id);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var instance = new CharacterEntity
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Sprite = reader.GetString(2)
                };
                
                return instance;
            }

            throw new Exception("Failed load character " + id);
        }
    }
}