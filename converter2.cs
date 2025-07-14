using System.Windows.Media;
namespace Converter2
{
    public static class HexToBrushExtension
    {
        public static SolidColorBrush ToBrush(this string value)
        {
            var converter = new BrushConverter();
            return (SolidColorBrush)converter.ConvertFromString(value);
        }
    }
}