using System;
using System.Collections.Generic;
using System.Linq;

abstract class EmergencyUnit
{
    public string Name { get; set; }
    public int Speed { get; set; }

    public abstract bool CanHandle(string incidentType);
    public abstract void RespondToIncident(string incidentType, string location);
}

class Police : EmergencyUnit
{
    public Police(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public override bool CanHandle(string incidentType)
    {
        return incidentType.Equals("Crime", StringComparison.OrdinalIgnoreCase);
    }

    public override void RespondToIncident(string incidentType, string location)
    {
        Console.WriteLine($"{Name} is handling crime at {location}.");
    }
}

class Firefighter : EmergencyUnit
{
    public Firefighter(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public override bool CanHandle(string incidentType)
    {
        return incidentType.Equals("Fire", StringComparison.OrdinalIgnoreCase);
    }

    public override void RespondToIncident(string incidentType, string location)
    {
        Console.WriteLine($"{Name} is extinguishing fire at {location}.");
    }
}

class Ambulance : EmergencyUnit
{
    public Ambulance(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public override bool CanHandle(string incidentType)
    {
        return incidentType.Equals("Medical", StringComparison.OrdinalIgnoreCase);
    }

    public override void RespondToIncident(string incidentType, string location)
    {
        Console.WriteLine($"{Name} is treating patients at {location}.");
    }
}

class SWAT : EmergencyUnit
{
    public SWAT(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public override bool CanHandle(string incidentType)
    {
        return incidentType.Equals("Hostage", StringComparison.OrdinalIgnoreCase) ||
               incidentType.Equals("Terrorism", StringComparison.OrdinalIgnoreCase);
    }

    public override void RespondToIncident(string incidentType, string location)
    {
        Console.WriteLine($"{Name} is responding to {incidentType} situation at {location}.");
    }
}

class Hazmat : EmergencyUnit
{
    public Hazmat(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public override bool CanHandle(string incidentType)
    {
        return incidentType.Equals("Chemical", StringComparison.OrdinalIgnoreCase) ||
               incidentType.Equals("Biological", StringComparison.OrdinalIgnoreCase);
    }

    public override void RespondToIncident(string incidentType, string location)
    {
        Console.WriteLine($"{Name} is containing {incidentType} hazard at {location}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<EmergencyUnit> units = new List<EmergencyUnit>
        {
            new Police("Police Unit 1", 90),
            new Firefighter("Firefighter Unit 1", 80),
            new Ambulance("Ambulance Unit 1", 100),
            new SWAT("SWAT Team Alpha", 70),
            new Hazmat("Hazmat Unit 1", 60)
        };

        int score = 0;
        int totalRounds = 5;
        Random random = new Random();

        Console.WriteLine("Welcome to the Emergency Response Simulation!");
        Console.WriteLine("Valid incident types: Crime, Fire, Medical, Hostage, Terrorism, Chemical, Biological");

        for (int i = 1; i <= totalRounds; i++)
        {
            Console.WriteLine($"\n--- Turn {i} ---");

            Console.Write("Enter incident type: ");
            string type = Console.ReadLine();

            if (!IsValidIncidentType(type))
            {
                Console.WriteLine("Invalid incident type! -5 points.");
                score -= 5;
                Console.WriteLine($"Current Score: {score}");
                continue;
            }

            Console.Write("Enter incident location: ");
            string location = Console.ReadLine();

            var capableUnits = units.Where(u => u.CanHandle(type)).ToList();

            if (capableUnits.Count == 0)
            {
                Console.WriteLine($"No unit available to handle {type} at {location}.");
                Console.WriteLine("-5 points");
                score -= 5;
                Console.WriteLine($"Current Score: {score}");
                continue;
            }

            Console.WriteLine("\nAvailable units:");
            for (int j = 0; j < capableUnits.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {capableUnits[j].Name} (Speed: {capableUnits[j].Speed})");
            }

            Console.Write("Select unit (number) or press Enter for auto-select: ");
            string selection = Console.ReadLine();
            EmergencyUnit selectedUnit = null;

            if (string.IsNullOrEmpty(selection))
            {
                selectedUnit = capableUnits.OrderByDescending(u => u.Speed).First();
                Console.WriteLine($"Auto-selected: {selectedUnit.Name}");
            }
            else if (int.TryParse(selection, out int unitIndex) && unitIndex > 0 && unitIndex <= capableUnits.Count)
            {
                selectedUnit = capableUnits[unitIndex - 1];
            }
            else
            {
                Console.WriteLine("Invalid selection! -5 points.");
                score -= 5;
                Console.WriteLine($"Current Score: {score}");
                continue;
            }

            selectedUnit.RespondToIncident(type, location);
            Console.WriteLine("+10 points");
            score += 10;
            Console.WriteLine($"Current Score: {score}");
        }

        Console.WriteLine($"\nFinal Score: {score}");
        Console.WriteLine("Simulation ended.");
    }

    static bool IsValidIncidentType(string type)
    {
        string[] validTypes = { "Crime", "Fire", "Medical", "Hostage", "Terrorism", "Chemical", "Biological" };
        return validTypes.Any(t => t.Equals(type, StringComparison.OrdinalIgnoreCase));
    }
}