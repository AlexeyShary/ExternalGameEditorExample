using System.Collections.Generic;
using System.IO;
using EditorExample.DAO;
using EditorExample.Model;
using HasturDatabaseEditor.Common;
using Microsoft.Win32;

namespace EditorExample.ViewModel;

public class CharactersEditorViewModel : EditorBase<CharacterEntity>
{
    public CharactersEditorViewModel()
    {
        SelectImageCommand = new RelayCommand<CharacterEntity>(SelectImage);
    }

    public RelayCommand<CharacterEntity> SelectImageCommand { get; }

    protected override List<CharacterEntity> GetFullList()
    {
        return CharacterDao.GetFullList();
    }

    protected override void AddEntity()
    {
        CharacterDao.AddEntity();

        FilterText = string.Empty;
        ReloadList();
    }

    protected override void DeleteEntity()
    {
        if (SelectedItem == null)
            return;

        CharacterDao.DeleteEntity(SelectedItem.Id);

        ReloadList();
    }

    protected override void SaveChanges()
    {
        if (SelectedItem == null)
            return;

        CharacterDao.SaveChanges(SelectedItem);
    }

    protected override void FilterList()
    {
        FilteredList = string.IsNullOrEmpty(FilterText)
            ? GetFullList()
            : GetFullList().FindAll(i => i.Name.ToLower().Contains(FilterText.ToLower()));
    }

    private void SelectImage(CharacterEntity character)
    {
        var initialPath = Path.Combine("..", "..", "..", "..", "UnityGame", "Assets", "Resources", "Characters");

        var openFileDialog = new OpenFileDialog
        {
            InitialDirectory = Path.GetFullPath(initialPath),
            Filter = "PNG files (*.png)|*.png",
            RestoreDirectory = true
        };

        if (openFileDialog.ShowDialog() != true) return;
        var selectedImagePath = openFileDialog.FileName;
        var selectedFileName = Path.GetFileNameWithoutExtension(selectedImagePath);

        character.Sprite = selectedFileName;
        SaveChanges();
    }
}