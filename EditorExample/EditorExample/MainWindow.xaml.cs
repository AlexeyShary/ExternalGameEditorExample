using System.Windows;
using EditorExample.View;

namespace EditorExample;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Characters_Click(object sender, RoutedEventArgs e)
    {
        EditorContentControl.Content = new CharactersEditorControl();
    }

    private void Location1Button_Click(object sender, RoutedEventArgs e)
    {
        EditorContentControl.Content = new LocationObjectsEditorControl();
    }
}