using System;
using Notiz_Manager;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;


namespace Benutzer_Notiz
{
    [Serializable()]
    public class Notiz : INotifyPropertyChanged, INotiz
    {
        private static ObservableCollection<Brush> _l = new ObservableCollection<Brush>
        {
            Brushes.Red,
            Brushes.Black,
            Brushes.Violet,
            Brushes.Green

         };
        public static ObservableCollection<System.Drawing.Color> listofColoredNames
        {
            get
            {
                var gj = _l;
                ObservableCollection<System.Drawing.Color> collectionOfColors = new ObservableCollection<System.Drawing.Color>();
                foreach (var color in _l)
                {
                    System.Drawing.Color stringColor = System.Drawing.ColorTranslator.FromHtml(color.ToString());
                    collectionOfColors.Add(stringColor);
                }
                return collectionOfColors;
            }
        }

        private string _selectedColor;
        public string SelectedColor
        {
            get
            {
                return _selectedColor;
            }
            set
            {
                try
                {
                    string getColorName = value.Split()[1];
                    string removeFirstBracket = getColorName.Split("[")[1];
                    string getFinalColorName = removeFirstBracket.Split("]")[0];
                    int ColorValue = System.Drawing.Color.FromName(getFinalColorName).ToArgb();
                    string colorHex = string.Format("#{0:x6}", ColorValue);
                    _selectedColor = colorHex;
                }
                catch (IndexOutOfRangeException)
                {
                    _selectedColor = value;
                }
                NotifyPropertyChanged("SelectedColor");
            }
        }
        private INotizen_Manager notiz_Manager { get; set; }
        private string krizelContent = "";
        public string Title { get; set; }
        public string Content
        {
            get
            {
                return krizelContent;
            }
            set
            {
                krizelContent = value;
                NotifyPropertyChanged("Content");
            }
        }
        //Muss drinen bleiben sonst geht die Serializierung nicht
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Notiz() { }

        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Notiz(INotizen_Manager m)
        {
            Title = "";
            this.notiz_Manager = m;
        }

        public void setManager(INotizen_Manager m)
        {
            this.notiz_Manager = m;
        }

        //Durchfuehrung von Dependency Injection

        //Event fuer aenderrungen in der Notiz
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
                notiz_Manager.HinzuSchreiben();
            }
        }        
    }
}
   