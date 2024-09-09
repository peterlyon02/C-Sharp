// See https://aka.ms/new-console-template for more information
using First_Project;
using System.Text;

int a=2; //Dichiarazione di variabile din tipo intero + inizializzazione
a = 3;
int c = 1;
char d = 'a';
string nome = "paperino";
string cognome = "paolino";
nome = "pluto";
bool b = a != 10 || c == 10; //OR logico
Console.WriteLine(b);

int pos = nome.IndexOf('u');
Console.WriteLine(pos);

string valori = "1,2,3,4,5";
string[] result = valori.Split(',');
Console.WriteLine(result[0]);

StringBuilder mybuilder = new StringBuilder();
mybuilder.Append(nome);
mybuilder.Append(" - ");
mybuilder.Append(cognome);

Console.WriteLine(mybuilder.ToString());


Person person = new Person(nome, cognome, new DateOnly(2002, 8, 8));
Console.WriteLine(person.Name);

