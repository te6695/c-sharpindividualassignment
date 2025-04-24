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

 Derived Classes 
Class: Police 
  - Specialization: Handles "Crime" incidents.
Class: Firefighter 
  - Specialization: Handles "Fire" incidents.
Class: Ambulance 
  - Specialization: Handles "Medical" incidents.


                                                                  EmergencyUnit
                                                                    /  |  \ 
                                                                   /   |    \
                                                                 /     |       \ 
                                                       Ambulance    police      Firefighter

                                             FIG.Hierarchical inheritance
