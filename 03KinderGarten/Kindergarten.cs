using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }
        public int  ChildrenCount{get{return  Registry.Count; } }

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }
            return false;

        }

        public bool RemoveChild(string childFullName)
        {
            string[] SeparatedName = childFullName.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            string FirstName = SeparatedName[0];
            string LastName= SeparatedName[1];

            Child ChildForRemove =
                Registry.FirstOrDefault(c => c.FirstName == FirstName && c.LastName == LastName);
            if (ChildForRemove != null)
            {
                Registry.Remove(ChildForRemove);
                return true;
            }

            return false;
        }

        public Child GetChild(string childFullName)
        {
            string[] SeparatedName = childFullName.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            string FirstName = SeparatedName[0];
            string LastName = SeparatedName[1];

            Child ChildWithNAmes =
                Registry.FirstOrDefault(c => c.FirstName == FirstName && c.LastName == LastName);

            if (ChildWithNAmes== null)
            {
                return null;
            }
            return ChildWithNAmes;
        
        }

        public string RegistryReport()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"Registered children in {Name}:");

            List<Child> SortedChild = Registry.
                OrderByDescending(c => c.Age).ThenBy(c => c.LastName).
                ThenBy(ch => ch.FirstName).ToList();

            foreach (var child in SortedChild)
            {
                sb.AppendLine($"{child.ToString()}");
            }

            return sb.ToString().Trim() ;

        }



    }
}
