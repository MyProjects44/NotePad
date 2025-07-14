using System;
using Notiz_Manager;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
namespace Benutzer_Notiz
{
    public interface INotiz
    {
        public static ObservableCollection<SolidColorBrush> ?listofColors { get; }
        string Title { get; set; }
        string Content { get; set; }
        string SelectedColor { get; set; }
        void setManager(INotizen_Manager m);
    }
} 