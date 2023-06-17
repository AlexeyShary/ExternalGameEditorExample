using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EditorExample.Model;

public class CharacterActionEntity : INotifyPropertyChanged
{
    private int _characterId;
    private int _id;
    private string _action;

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

    public string Action
    {
        get => _action;
        set
        {
            _action = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}