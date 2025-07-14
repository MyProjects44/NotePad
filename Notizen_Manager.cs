using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using Benutzer_Notiz;

namespace Notiz_Manager 
{
    
    public class Notizen_Manager : INotizen_Manager
    {  
        private  ObservableCollection<Notiz> _Notizen {get; set;}
        public ObservableCollection<Notiz> Notizen {get { return _Notizen;} set{ _Notizen = value; }}


        public Notizen_Manager()
        {
            _Notizen = new ObservableCollection<Notiz>();
        }


        private string ordner_Erstellen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NotePad");
        public string datei_Pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NotePad/NotePad.xml");

            //Methode zum Erstellen einer XML-Datei, dient hier eher zum Löschen eines Elements
        public void Erstellen()
        {
            try
            {
                using (FileStream notiz_Datei = new FileStream(datei_Pfad, FileMode.Create))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(Collection<Notiz>));
                    XML.Serialize(notiz_Datei, _Notizen);
                }
            }
            catch(ArgumentNullException)
            {

            }
            catch(DirectoryNotFoundException)
            {
                Directory.CreateDirectory(ordner_Erstellen);
            }
        }

            //Methode zum Hinzufügen von neuen Elementen in einer Bestehenden XML datei.
        public void HinzuSchreiben()
        {
            XmlSerializer XML = new XmlSerializer(typeof(Collection<Notiz>));

            try
            {
                using (TextWriter notiz_Datei = new StreamWriter(datei_Pfad))
                {  
                    XML.Serialize(notiz_Datei, _Notizen);
                }
            }
            catch(ArgumentNullException)
            {

            }
        }

            //Methode zum Laden einer Bestehenden XML datei, die den Inhalt der Datei zurück gibt an den Aufrufer
        public void LadenAusDatei()
        {
            XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Notiz>));
            ObservableCollection<Notiz>? ret = null;
            try
            {
                using (var notiz_Datei = new StreamReader(datei_Pfad))
                {
                    ret = (ObservableCollection<Notiz>)XML.Deserialize(notiz_Datei)!;
                }
                foreach(var n in ret){
                    n.setManager(this);
                    _Notizen.Add(n);
                }
            }
            catch(FileNotFoundException)
            {
                Erstellen();
            }
            catch(System.InvalidOperationException)
            {
                    
            }
            catch(DirectoryNotFoundException)
            {
                Erstellen();
            }
        }
    }
}