using System.Collections.Generic;
using System.Windows;
using EditorExample.Model;

namespace EditorExample.View;

public partial class CharacterSelectionDialog : Window
{
    public CharacterSelectionDialog(List<CharacterEntity> characters)
    {
        InitializeComponent();
        DataContext = this;

        CharactersList = characters;
    }

    public CharacterEntity SelectedItem { get; private set; }

    public List<CharacterEntity> CharactersList { get; }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        if (CharactersDataGrid.SelectedItem is CharacterEntity selectedCharacter)
        {
            SelectedItem = selectedCharacter;
            DialogResult = true;
        }
        else
        {
            MessageBox.Show("Please select a character.", "Selection Error", MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}