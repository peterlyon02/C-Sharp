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

        Console.WriteLine("Inserisci il tipo da cercare");
        string tipoDaCercare = Console.ReadLine();

        List<Utente> studenti = gestionecorsi.GetUtentiByTipoUtente(tipoDaCercare);

        if (studenti.Count > 0)
        {
            foreach (Utente studente in studenti)
            {
                Console.WriteLine(studente);
            }
        }
        else
        {
            Console.WriteLine("Non esistono utenti");
        }


    }
}