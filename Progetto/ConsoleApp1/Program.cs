using ConsoleApp1;
using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        GestioneCorsi gestionecorsi = new GestioneCorsi();

        //Chiediamo all'utente di inserire il nome da cercare 
        Console.WriteLine("Inserisci il nome");
        string nomeDaCercare = Console.ReadLine();

        //Cerchiamo l'utente nel database
        Utente utente = gestionecorsi.GetUtenteByNome(nomeDaCercare);

        if (utente == null)
        {
            Console.WriteLine($"L'utente '{nomeDaCercare}' non esiste");
        }
        else
        {
            Console.WriteLine("Utente trovato:");
            Console.WriteLine(utente);
        }
    }
}
