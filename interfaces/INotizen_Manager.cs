using System;

namespace Notizen_Manager
{
    public interface INotizen_Manager
    {
        public Notizen_Manager();
        public void Erstellen();
        public void Hinzuschreiben();
        public void LadenAusDatei();
    }
} 