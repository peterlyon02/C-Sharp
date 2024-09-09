using System;

namespace First_Project 
{
    internal class Person
    {   
        //Costruttore
        internal Person(string Name, string LastName, DateOnly BirthDate) 
        {
            this.Name = Name;
            this.LastName = LastName;   
            this.DateofBirth = BirthDate;
        }

        internal string Name { get; set; } //Property
        internal string LastName { get; set; } //Property
        internal string CF { get; set; } //Property
        internal DateOnly DateofBirth { get; set; } //Property
    }

}
