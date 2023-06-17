using System.Windows.Controls;
using EditorExample.ViewModel;

namespace EditorExample.View;

public partial class CharacterActionsEditorControl : UserControl
{
    public CharacterActionsEditorControl(int characterId)
    {
        InitializeComponent();
        DataContext = new CharacterActionsEditorViewModel(characterId);
    }

    private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.EditAction != DataGridEditAction.Commit) return;
        var viewModel = DataContext as CharacterActionsEditorViewModel;
        viewModel?.DataGrid_CellEditEnding(sender, e);
    }
}