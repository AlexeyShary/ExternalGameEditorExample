using Sources.Database;
using Sources.Database.Model;
using UnityEngine;

namespace Sources
{
    public class CharacterFactory : MonoBehaviour
    {
        public GameObject characterPrefab;

        public void CreateCharacter(LocationObjectEntity locationObjectEntity)
        {
            var characterEntity = DatabaseService.Instance.CharacterDao.GetById(locationObjectEntity.CharacterId);
            var characterObject = Instantiate(characterPrefab);

            characterObject.GetComponent<SpriteRenderer>().sprite =
                Resources.Load<Sprite>("Characters/" + characterEntity.Sprite);

            var character = characterObject.GetComponent<Character>();
            
            character.CharacterName = characterEntity.Name;
            foreach (var actionEntity in DatabaseService.Instance.CharacterActionDao.GetByCharacterId(characterEntity.Id))
            {
                character.CharacterActions.Add(actionEntity.Action);
            }

            characterObject.transform.position =
                new Vector3(locationObjectEntity.SpawnPosX, locationObjectEntity.SpawnPosY);
        }
    }
}