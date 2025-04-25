NAME :Tesfu 
ID:   DBU1501501

                        <===============ABOUT CODE================>
     Emergency Response Simulation Program
This program simulates emergency response units handling incidents. The user interacts by entering incident types and locations. The units respond if the incident matches their specialization, earning or losing points for valid or invalid interactions.

Feel free to use this Markdown file or let me know if you need any adjustments!



  Object-Oriented Programming Concepts Applied
  1. Encapsulation 
- Encapsulation is achieved through the use of properties like `Name` and `Speed` in the `EmergencyUnit` class, which ensure data is accessed and modified via defined structures.
  
  2.  Inheritance 
- The `Police`, `Firefighter`, and `Ambulance` classes inherit from the abstract `EmergencyUnit` class. This allows them to share common properties and methods while implementing their specific behaviors.

  3.  Polymorphism 
- Polymorphism is demonstrated through the use of abstract methods `CanHandle()` and `RespondToIncident()`. Each derived class provides its own implementation of these methods.

  4.  Abstraction 
- The `EmergencyUnit` abstract class provides a blueprint for emergency units, ensuring all derived classes implement the required methods.

---

  Class Structure

 Abstract Class: EmergencyUnit 
 Properties 
  - `Name` (string)
  - `Speed` (integer)
 Methods 
  - `CanHandle(string incidentType)` (abstract)
  - `RespondToIncident(string incidentType, string location)` (abstract)                                                   
Emergency Response Simulation - Code Report

 Overview
A C# console application simulating emergency unit dispatch. Players manage units (Police, Firefighters, etc.) to respond to incidents, earning points for correct responses.

 Key Features
1. Unit Types 
   - `Police`: Handles crimes  
   - `Firefighter`: Extinguishes fires  
   - `Ambulance`: Medical emergencies  
   - `SWAT`: Hostage/terrorism (new)  
   - `Hazmat`: Chemical/biological hazards (new)  

2. Incident Types  
   - Crime, Fire, Medical, Hostage, Terrorism, Chemical, Biological  

3. Gameplay 
   - 5 rounds per game  
   - Manual or auto-unit selection  
   - Score tracking (+10 for success, -5 for errors)  

4. Output Format  
   ```plaintext
   --- Turn 1 ---
   Incident: Medical at City Hall
   Ambulance Unit 1 is treating patients at City Hall.
   +10 points
   Current Score: 10
