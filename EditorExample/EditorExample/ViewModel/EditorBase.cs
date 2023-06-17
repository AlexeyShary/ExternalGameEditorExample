using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using HasturDatabaseEditor.Common;

namespace EditorExample.ViewModel;

public abstract class EditorBase<T> : INotifyPropertyChanged
{
    private List<T> _filteredList;

    private string _filterText;

    private T _selectedItem;

    protected EditorBase()
    {
        AddCommand = new RelayCommand(AddEntity);
        DeleteCommand = new RelayCommand(DeleteEntity);
        SaveCommand = new RelayCommand(SaveChanges);

        FilteredList = GetFullList();
    }

    public RelayCommand AddCommand { get; }
    public RelayCommand DeleteCommand { get; }
    public RelayCommand SaveCommand { get; }

    public string FilterText
    {
        get => _filterText;
        set
        {
            _filterText = value;
            FilterList();
            OnPropertyChanged();
        }
    }

    public List<T> FilteredList
    {
        get => _filteredList;
        set
        {
            _filteredList = value;
            OnPropertyChanged();
        }
    }

    public T SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsSelected));
        }
    }

    public bool IsSelected => SelectedItem != null;

    protected abstract List<T> GetFullList();

    protected abstract void AddEntity();

    protected abstract void DeleteEntity();

    protected abstract void SaveChanges();

    protected abstract void FilterList();

    protected void ReloadList()
    {
        FilteredList = GetFullList();
    }

    public void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.EditingElement is not TextBox editedElement) return;
        var bindingExpression = editedElement.GetBindingExpression(TextBox.TextProperty);
        bindingExpression?.UpdateSource();
        SelectedItem = (T)e.Row.Item;
        SaveChanges();
    }

    #region PropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}