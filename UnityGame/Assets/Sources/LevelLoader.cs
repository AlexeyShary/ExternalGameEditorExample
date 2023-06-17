using Sources.Database;
using UnityEngine;

namespace Sources
{
    public class LevelLoader : MonoBehaviour
    {
        public CharacterFactory characterFactory;
        
        private void Awake()
        {
            var charactersList = DatabaseService.Instance.LocationObjectDao.GetAll();

            foreach (var o in charactersList)
            {
                characterFactory.CreateCharacter(o);
            }
        }
    }
}