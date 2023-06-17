using System.Collections.Generic;
using EditorExample.DAO;
using EditorExample.Model;

namespace EditorExample.ViewModel;

public class CharacterActionsEditorViewModel : EditorBase<CharacterActionEntity>
{
    private readonly int _characterId;

    public CharacterActionsEditorViewModel(int characterId)
    {
        _characterId = characterId;
        FilteredList = GetFullList();
    }

    protected override List<CharacterActionEntity> GetFullList()
    {
        return CharacterActionDao.GetFullList(_characterId);
    }

    protected override void AddEntity()
    {
        CharacterActionDao.AddEntity(_characterId);

        FilterText = string.Empty;
        ReloadList();
    }

    protected override void DeleteEntity()
    {
        if (SelectedItem == null)
            return;

        CharacterActionDao.DeleteEntity(SelectedItem.Id);

        ReloadList();
    }

    protected override void SaveChanges()
    {
        if (SelectedItem == null)
            return;

        CharacterActionDao.SaveChanges(SelectedItem);
    }

    protected override void FilterList()
    {
        FilteredList = string.IsNullOrEmpty(FilterText)
            ? GetFullList()
            : GetFullList().FindAll(i => i.Action.ToLower().Contains(FilterText.ToLower()));
    }
}