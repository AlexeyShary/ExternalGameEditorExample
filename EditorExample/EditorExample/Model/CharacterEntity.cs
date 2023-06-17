using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EditorExample.Model;

public class CharacterEntity : INotifyPropertyChanged
{
    private int _id;
    private string _name;
    private string _sprite;

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged();
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public string Sprite
    {
        get => _sprite;
        set
        {
            _sprite = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}