using System.Windows.Controls;
using EditorExample.ViewModel;

namespace EditorExample.View;

public partial class CharactersEditorControl : UserControl
{
    public CharactersEditorControl()
    {
        InitializeComponent();
        DataContext = new CharactersEditorViewModel();
    }

    private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.EditAction != DataGridEditAction.Commit) return;
        var viewModel = DataContext as CharactersEditorViewModel;
        viewModel?.DataGrid_CellEditEnding(sender, e);
    }

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (DataContext is CharactersEditorViewModel viewModel)
            ActionsEditor.Content = viewModel.SelectedItem == null
                ? null
                : new CharacterActionsEditorControl(viewModel.SelectedItem.Id);
    }
}