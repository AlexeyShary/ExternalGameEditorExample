using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EditorExample.Model;

public class LocationObjectEntity
{
    private int _id;
    private int _characterId;
    private int _spawnPosX;
    private int _spawnPosY;

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged();
        }
    }

    public int CharacterId
    {
        get => _characterId;
        set
        {
            _characterId = value;
            OnPropertyChanged();
        }
    }

    public int SpawnPosX
    {
        get => _spawnPosX;
        set
        {
            _spawnPosX = value;
            OnPropertyChanged();
        }
    }

    public int SpawnPosY
    {
        get => _spawnPosY;
        set
        {
            _spawnPosY = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}