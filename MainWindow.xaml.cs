using System.Windows;
using System.Windows.Controls;
using Notizen_Manager;
using Benutzer_Notiz;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace NotePad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //Notizen_Manager noteObject;
        INotizen_Manager noteObject;
        public MainWindow()
        {
            InitializeComponent();
            noteObject = new Notizen_Manager();
            noteObject.LadenAusDatei();
            this.DataContext = noteObject;
        }
        public void btn_hinzufuegen_Click(object sender, RoutedEventArgs e )
        {   
            
            //Notiz notiz = new Notiz(noteObject) {Title = Notiz_benennen.Text};
            INotiz notiz = new Notiz(noteObject) {Title = Notiz_benennen.Text};
            noteObject.Notizen.Add(notiz);
            Notiz_benennen.Text = string.Empty; 
            
            noteObject.HinzuSchreiben();
            tabDynamisch.Items.Refresh();
        }
        private void btn_entfernen_Click(object sender, RoutedEventArgs eventArgs)
        {
            if (MessageBox.Show("Bist du dir sicher das du diese Notiz entfernen willst?", "Notiz Entfernen",
            MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                bool abfrage = noteObject.Notizen.Remove((Notiz)((Button)sender).DataContext);
                noteObject.Erstellen();
            }
            tabDynamisch.Items.Refresh();

        }
        private void alwaysOnTop_IsChecked(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
        }

        private void alwaysOnTop_IsUnchecked(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            this.Activate();
        }
        
    }
}

