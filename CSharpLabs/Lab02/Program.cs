// See https://aka.ms/new-console-template for more information
using Lab02;

Person person = new Person("Pippo", "De Pippo", new DateOnly(1990, 10, 1));
person.CF = "ABCDEF30M51H555F"; // Scrivo nella proprietà CF
person.Email = "pippo@yahoo.com";
//Console.WriteLine(person.Age);
//person.DisplayBasicInfo();
//person.DisplayBasicInfo("---"); 
//person.DisplayBasicInfo("<", ">");

Developer dev = new Developer("Paolo", "De Paolis", new DateOnly(1980, 7, 31), 1, "Senior .NET Developer", 100000.00M);
dev.Skills = DevSkills.CSharp;
//dev.DisplayBasicInfo(); // Polimorfismo Developer

SalesPerson salesPerson = new SalesPerson("Gino", "De Gino", new DateOnly(1970, 4, 19), 2, "Head of Sales", 200000.00M);
salesPerson.SalesAmount = 1500000;
//salesPerson.DisplayBasicInfo(); // Polimorfismo SalesPerson

ProjectManager projectManager = new ProjectManager("Pino", "De Pinis", new DateOnly(1977, 8, 23), 3, "PA Administrator", 200000.00M);
projectManager.Project =  ProjectTypes.PA;
projectManager.TeamSize = 20;
//projectManager.DisplayBasicInfo(); // Polimorfismo ProjectManager

// Gestione collections in C#
// 1. Creo un array di tre elementi 
Employee[] employees1 = new Employee[3]; // dimensione predeterminata
// Popolo l'array con gli oggetti
employees1[0] = dev;
employees1[1] = salesPerson;
employees1[2] = projectManager;
for (int i = 0; i < employees1.Length; i++)
{
	employees1[i].DisplayBasicInfo();
}

// 2. Creo una lista vuota di oggetti di tipo Employee
List<Employee> employees = new List<Employee>();
// Aggiungo oggetti di tipo Employee
employees.Add(dev);
employees.Add(salesPerson);
employees.Add(projectManager);
foreach (Employee item in employees) 
{
	item.DisplayBasicInfo();
}

// 3. Creo un dictionary con chiave pari ad EmployeeId (1,2,3)
Dictionary<int, Employee> dictemployees = new Dictionary<int, Employee>();
dictemployees.Add(dev.EmployeeId, dev);
dictemployees.Add(salesPerson.EmployeeId, salesPerson);
dictemployees.Add(projectManager.EmployeeId, projectManager);
foreach (KeyValuePair<int, Employee> item in dictemployees)
{ 
	item.Value.DisplayBasicInfo();
}

// 4. Uso la classe Company
Console.WriteLine("Utilizzo della classe Company");
Company company = new Company();
company.Name = "MY company S.r.l.";
company.AddEmployee(dev);
company.AddEmployee(salesPerson);
company.AddEmployee(projectManager);

company.ListAllEmployees();

// Acquisisco il nome da cercare da input di tastiera:
Console.WriteLine("Inserisci il nome da cercare");
string? nome = Console.ReadLine();
if (nome != null)
{
	var items = company.FindByName(nome);
	Console.WriteLine("Trovati: " + items.Count + " dipendenti di nome " + nome);
}





