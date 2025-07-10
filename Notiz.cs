using System;
using Notiz_Verwaltung;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Benutzer_Notiz
{
    [Serializable()]
    public class Notiz : INotifyPropertyChanged
    {

        private static ObservableCollection<SolidColorBrush> _l = new ObservableCollection<SolidColorBrush>();
        public static ObservableCollection<SolidColorBrush> listofColors
        {
            get{return _l;} 
            private set{_l = value;}
        }
        static Notiz()
        {
            listofColors.Add(Brushes.Blue);
            listofColors.Add(Brushes.Red);
            listofColors.Add(Brushes.Green);
            listofColors.Add(Brushes.Yellow);
        }

        public string _selectedColor;
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
        private Notizen_Manager ?notiz_Manager {get; set;}
        private string ?krizelContent = "";
        public string ?Title{ get; set; }
        public string ?Content 
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
        protected Notiz()
        {

        }
        public Notiz( Notizen_Manager m)
        {
            this.notiz_Manager = m;
        }

        public void setManager( Notizen_Manager m)
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
   