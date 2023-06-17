using System.Windows.Controls;
using System.Windows.Input;
using EditorExample.ViewModel;

namespace EditorExample.View;

public partial class LocationObjectsEditorControl : UserControl
{
    public LocationObjectsEditorControl()
    {
        InitializeComponent();
        DataContext = new LocationObjectsViewModel();
    }

    private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.EditAction != DataGridEditAction.Commit) return;
        var viewModel = DataContext as LocationObjectsViewModel;
        viewModel?.DataGrid_CellEditEnding(sender, e);
    }

    private void CharIdColumn_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var viewModel = DataContext as LocationObjectsViewModel;
        viewModel?.CharIdColumn_MouseDown(sender, e);
    }
}