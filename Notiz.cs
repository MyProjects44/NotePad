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

        private static ObservableCollection<SolidColorBrush> _l = new ObservableCollection<SolidColorBrush>();
        public static ObservableCollection<SolidColorBrush> listofColors
        {
            get{return _l;} 
            private set{_l = value;}
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
                _selectedColor = value;
                NotifyPropertyChanged("SelectedColor");
            }
        }
        private INotizen_Manager notiz_Manager {get; set;}
        private string krizelContent = "";
        public string Title{ get; set; }
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
        public Notiz(){}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Notiz(INotizen_Manager m)
        {
            listofColors.Add(Brushes.Blue);
            listofColors.Add(Brushes.Red);
            listofColors.Add(Brushes.Green);
            listofColors.Add(Brushes.Yellow);
            _selectedColor = "blue";
            Title = "";
            this.notiz_Manager = m;
        }

        public void setManager( INotizen_Manager m)
        {
            this.notiz_Manager = m;
        }
        
        //Durchfuehrung von Dependency Injection

        //Event fuer aenderrungen in der Notiz
        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
                notiz_Manager.HinzuSchreiben();
            }  
        }           
    }
}
   