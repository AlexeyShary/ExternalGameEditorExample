using System.Collections.Generic;
using Sources.Database.Model;

namespace Sources.Database.DAO
{
    public class LocationObjectDao
    {
        public List<LocationObjectEntity> GetAll()
        {
            var result = new List<LocationObjectEntity>();
            
            using var command = DatabaseService.Instance.CreateCommand();
            command.CommandText = "SELECT LOCATION_OBJECT_ID, CHARACTER_ID, SPAWN_POS_X, SPAWN_POS_Y FROM LOCATION_1";
            
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
    }
}