using Klassenbibliothek.Models;

namespace AdressbuchApp;

public static class Funktionen
{
    public static Person CreatePerson()
    {
        Person p = new Person();
        
        Console.Write("Vorname: ");
        p.firstName = Console.ReadLine();
        
        Console.Write("Nachname: ");
        p.lastName = Console.ReadLine();
        
        Console.Write("Strasse und Hausnummer: ");
        p.street = Console.ReadLine();
        
        Console.Write("Postleitzahl: ");
        p.postalCode = Console.ReadLine();
        
        Console.Write("Stadt: ");
        p.city = Console.ReadLine();
        
        return p;
    }
}