using System.Collections.Generic;
using Sources.Database.Model;

namespace Sources.Database.DAO
{
    public class CharacterActionDao
    {
        public List<CharacterActionEntity> GetByCharacterId(int characterId)
        {
            var result = new List<CharacterActionEntity>();

            using var command = DatabaseService.Instance.CreateCommand();
            command.CommandText =
                "SELECT CHARACTER_ACTION_ID, CHARACTER_ID, CHARACTER_ACTION_SCRIPT FROM CHARACTERS_ACTIONS WHERE CHARACTER_ID = @CharacterId";
            command.AddParameter("@CharacterId", characterId);
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
    }
}