using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace EditorExample.View;

public class CharacterImagePathConverter : IValueConverter
{
    private readonly string basePath =
        Path.Combine("..", "..", "..", "..", "UnityGame", "Assets", "Resources", "Characters");

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not string fileName) return null;
        var imagePath = Path.Combine(basePath, fileName + ".png");
        return Path.GetFullPath(imagePath);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}