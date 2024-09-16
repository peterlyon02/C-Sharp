// See https://aka.ms/new-console-template for more information
using Lab01;
using System.Text;

int a = 2; // Dichiarazione di variabile di tipo intero + inizializzazione
a = 3;
int c = 1;
char d = 'a';
string nome = "paperino";
string cognome = "paolino";
//nome = "pluto";
bool b = a != 10 || c == 10; // OR logico

							 //Console.WriteLine(b);
if (b)
	Console.WriteLine("Vero");
else {
	Console.WriteLine("Falso");
}

switch (nome.Length)
{ 
	case < 10: 
		Console.WriteLine("< 10");
		break;
	case 10: 
		Console.WriteLine("10");
		break;
	default:
		break;
}
int i = 0;
while (i < 10)
{
	if (i % 2 == 0)
	{
		i = i + 1;
		break;
	}
	Console.WriteLine(i);
	i = i + 1;
}


Console.WriteLine(b ? "Vero" : "Falso"); // Operatore ternario

string valori = "à é ù % ò 6 7";
string[] result = valori.Split(' ');

for (int j = 0; j < result.Length; j++)
{
	Console.WriteLine("Il valore dell'elemento [" + j + "] è: " + result[j]);
}
// result è una variabile di tipo collection (collezione di elementi dello stesso tipo)
// -> utilizzo foreach
foreach (string elem in result)
{
	Console.WriteLine("Il valore dell'elemento corrente è: " + elem);
}

//Console.WriteLine(result[0]);
string senzaspazi = valori.Trim();

StringBuilder mybuilder = new StringBuilder();
mybuilder.Append(nome);
mybuilder.Append(" - ");
mybuilder.Append(cognome);
Console.WriteLine(mybuilder.ToString());
/*
	Area di commento
	su più righe
*/
Person person = new Person("Pippo", "De Pippo", new DateOnly(1990, 5, 1));
person.CF = "ABCDEF30M51H555F"; // Scrivo nella proprietà CF
person.Email = "pippo@yahoo.com";
person.DisplayBasicInfo();
;

