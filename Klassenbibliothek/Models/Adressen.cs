﻿using System.Threading.Channels;

namespace Klassenbibliothek.Models;

public class Adressen
{
    private List<Person> people = new List<Person>();
    
    public void AddPerson(Person p)
    {
        people.Add(p);
    }
    
    public void DeletePerson()
    {
        bool fail = false;
        
        do
        {
            fail = false;
            
            int index;
            Console.Write("Welche Person soll gelöscht werden? -> ");
            index = Convert.ToInt32(Console.ReadLine()) - 1;
            
            if (index >= 0 && index < people.Count)
            {
                people.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe - Bitte wiederholen!");
                fail = true;
            }
        } while (fail);
    }

    public void SaveToFile(string filename)
    {
        List<string> listOfEntries = new List<string>();
        
        foreach (Person p in people)
        {
            string line = $"{p.firstName},{p.lastName},{p.street},{p.city},{p.postalCode}";
            listOfEntries.Add(line);
        }
        
        File.WriteAllLines(filename, listOfEntries);
    }

    public void LoadFromFile(string filename)
    {
        people.Clear();
        
        var content = File.ReadAllLines(filename);

        foreach (string line in content)
        {
            string[] temp = line.Split(',');
            if (temp.Length == 5)
            {
                Person p = new Person();
                
                p.firstName = temp[0];
                p.lastName = temp[1];
                p.street = temp[2];
                p.postalCode = temp[3];
                p.city = temp[4];
                
                people.Add(p);
            }
        }
    }

    public void ListPeople()
    {
        int count = 0;
        foreach (var p in people)
        {
            Console.WriteLine($"{count + 1}. {p.firstName} {p.lastName}");
            count++;
        }
    }

    public void ShowPeople()
    {
        int index;
        bool fail = false;
        do
        {
            fail = false;
            Console.Write("Welche Person soll angezeigt werden? -> ");
            index = Convert.ToInt32(Console.ReadLine()) - 1;


            if (index >= 0 && index < people.Count) // Weiß wie viele einträge er hat
            {
                Person p = people[index];

                Console.WriteLine($"Vorname: {p.firstName}");
                Console.WriteLine($"Nachname: {p.lastName}");
                Console.WriteLine($"Straße: {p.street}");
                Console.WriteLine($"Postleitzahl: {p.postalCode}");
                Console.WriteLine($"Ort: {p.city}");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe - Bitte wiederholen!");
                fail = true;
            }
        } while (fail);
    }

    public void ModifyPeople()
    {
        int index;
        bool fail = false;
        string auswahl;

        do
        {
            fail = false;
            Console.Write("Welche Person soll bearbeitet werden? -> ");
            index = Convert.ToInt32(Console.ReadLine()) - 1;


            if (index >= 0 && index < people.Count) // Weiß wie viele einträge er hat
            {
                Person p = people[index];
                
                Console.WriteLine($"1. Vorname: {p.firstName}");
                Console.WriteLine($"2. Nachname: {p.lastName}");
                Console.WriteLine($"3. Straße: {p.street}");
                Console.WriteLine($"4. Postleitzahl: {p.postalCode}");
                Console.WriteLine($"5. Ort: {p.city}");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe - Bitte wiederholen!");
                fail = true;
                continue;
            }

            Console.Write("Welche Position soll bearbeitet werden? -> ");
            auswahl = Console.ReadLine();

            Console.Write("Neuer Wert -> ");
            string newValue = Console.ReadLine();

            switch (auswahl)
            {
                case "1":
                    people[index].firstName = newValue;
                    break;
                
                case "2":
                    people[index].lastName = newValue;
                    break;
                
                case "3":
                    people[index].street = newValue;
                    break;
                
                case "4":
                    people[index].postalCode = newValue;
                    break;
                
                case "5":
                    people[index].city = newValue;
                    break;
                
                default:
                    Console.WriteLine("Ungültige Eingabe.");
                    fail = true;
                    break;
            }
        } while (fail);
    }
}