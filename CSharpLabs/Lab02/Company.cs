using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
	internal class Company
	{
		internal Company() 
		{
			Employees = new List<Employee>();
		}

		internal string Name { get; set; }
		internal List<Employee> Employees { get; set; }

		internal void ListAllEmployees()
		{
			if (Employees.Count == 0)
				Console.WriteLine("Non ci sono dipendenti");
			else
			{
				foreach (var item in Employees)
				{
					item.DisplayBasicInfo();
				}
			}
		}
		internal void RemoveEmployee(int id)
		{
			var element = Employees.Find(el => el.EmployeeId == id);
            if (element != null)
				Employees.Remove(element);
		}
		internal void RemoveEmployee(string name)
		{
			var elements = Employees.FindAll(el => el.Name == name);
			for(int i = 0; i < elements.Count; i++)
				Employees.Remove(elements[i]);
		}
		internal void RemoveEmployee(Employee item)
		{
			Employees.Remove(item);
		}
		internal void AddEmployee(Employee item)
		{
			Employees.Add(item);
		}
		internal Employee FindById(int id)
		{
			var element = Employees.Find(el => el.EmployeeId == id);
			return element;
		}
		internal List<Employee> FindByName(string name)
		{
			List<Employee> elements = Employees.FindAll(el => el.Name == name);
			return elements;
		}
	}
}
