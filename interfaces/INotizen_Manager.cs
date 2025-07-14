using System;
using System.Collections.ObjectModel;
using Benutzer_Notiz;

namespace Notiz_Manager
{
    public interface INotizen_Manager
    {
        ObservableCollection<Notiz> Notizen {get;}
        public void Erstellen();
        public void HinzuSchreiben();
        public void LadenAusDatei();
    }
} 