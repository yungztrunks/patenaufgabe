using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Untere nur machen wenn der using import nicht funktioniert!!!

//Vorher die dll MySql.Data.dll zu den Verweisen hinzufügen.
//dann kann man auf den Namespace verweisen.
//Quelle: https://dev.mysql.com/downloads/connector/net/



namespace SimpleDBAccess
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_set_data(object sender, RoutedEventArgs e)
        {
            ///Um diese Klassen benutzen zu können, müssen Sie den Namespace MySql.Data in den
            ///using-Direktiven (siehe oben) hinzufügen. 
            ///
            ///Jetzt können wir als Erstes eine Verbindung zur Datenbank herstellen. In einem sog.
            ///Connection-String geben wir die nötigen Verbindungsinformationen an:
            ///- Server-Adresse/IP
            ///- Name der Datenbank
            ///- User, der auf die Datenbank zugreifen darf und
            ///- Passwort (Sicherheitskriterien beachten!)
            ///Natürlich müssen Datenbank und User auf der Datenbank existieren.
            MySqlConnection con = new MySqlConnection(@"SERVER = localhost;DATABASE=demodb;UID=root;PASSWORD=root;");

            //Nachdem die Zugangsdaten gesetzt wurden, können wir den "Kanal" zur Datenbank öffnen.
            con.Open();  //Jetzt greift unser Programm über das Netzwerk/lokal auf die Datenbank zu.

            //Tabelle erstellen
            string table = "CREATE TABLE Personen_test (name VARCHAR(255), altere INT)";//Alter ist schon ein command in sql weshalb ich für das alter einfach altere geschrieben haben damit es zu keinen Komplikationen führt
            ///Nun können wir einen SQL-Befehl an die DB senden, der Daten in eine Tabelle einfügt. 
            ///Dies geht im einfachsten Fall über SQL-Befehle als String.
            string insert = "INSERT INTO Personen_test (Name, Altere) VALUES ('Morris', 32)"; //Alter ist schon ein command in sql weshalb ich für das alter einfach altere geschrieben haben damit es zu keinen Komplikationen führt
            //Damit der MySQL-Server das SQL-Statement verarbeiten kann, müssen wir es in einen MySqlCommand-Objekt umwandeln.
            //Dafür erstellen wir ein MySqlCommand-Objekt mit new...
            MySqlCommand cmd = new MySqlCommand();
            MySqlCommand cmd2 = new MySqlCommand();
            //..und fügen die nötigen Informationen hinzu:
            cmd2.CommandText = table;
            cmd2.Connection = con;

            cmd.CommandText = insert;
            cmd.Connection = con; //Damit weiß der Command, welche Verbindung er zum DB-Server verwenden soll.

            //Mit ExecuteNonQuery() führen wir den Command auf der DB aus.

            ///cmd2.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd.ExecuteNonQuery();

            AusgabeFeld.Text = "Data wurde erfolgreich in die Datenbank eingetragen!";

            //So, wenn alles funktioniert hat, solle nun in der Datenbank ein Eintrag in der Tabelle Personen_test vorhanden sein.
            //Überprüfen Sie dies....

            //Dies war ein Besipiel, hieran kannst du dich für deine Teil 3 Aufgaben orientieren. Die Buttons kannst du nach belieben bearbeiten.
            //Oder sogar neue hinzufügen

        }

        private void Button_get_data(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
