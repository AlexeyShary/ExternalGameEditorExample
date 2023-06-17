using System.Collections.Generic;
using System.Windows.Input;
using EditorExample.DAO;
using EditorExample.Model;
using EditorExample.View;

namespace EditorExample.ViewModel;

public class LocationObjectsViewModel : EditorBase<LocationObjectEntity>
{
    protected override List<LocationObjectEntity> GetFullList()
    {
        return LocationObjectDao.GetFullList();
    }

    protected override void AddEntity()
    {
        LocationObjectDao.AddEntity();

        FilterText = string.Empty;
        ReloadList();
    }

    protected override void DeleteEntity()
    {
        if (SelectedItem == null)
            return;

        LocationObjectDao.DeleteEntity(SelectedItem.Id);

        ReloadList();
    }

    protected override void SaveChanges()
    {
        if (SelectedItem == null)
            return;

        LocationObjectDao.SaveChanges(SelectedItem);
    }

    protected override void FilterList()
    {
        FilteredList = string.IsNullOrEmpty(FilterText)
            ? GetFullList()
            : GetFullList().FindAll(i => i.CharacterId.ToString().ToLower().Contains(FilterText.ToLower()));
    }

    public void CharIdColumn_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var dialog = new CharacterSelectionDialog(CharacterDao.GetFullList());

        var result = dialog.ShowDialog();

        if (!result.HasValue || !result.Value || dialog.SelectedItem == null) return;
        
        SelectedItem.CharacterId = dialog.SelectedItem.Id;

        SaveChanges();
        ReloadList();
    }
}