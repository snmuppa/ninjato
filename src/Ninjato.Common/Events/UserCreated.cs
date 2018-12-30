namespace Ninjato.Common.Events
{
  public class UserCreated : IEvent
  {
    public string Email { get; }

    public string Name { get; }

    // No event should pass along the password, only the service responsible for creating the user must have the access to the password

    // This protected constructor is purely for serialization purposes 
     protected UserCreated()
     {

     }

     public UserCreated(string email, string name)
     {
       Email = email;
       Name = name;
     }
  }
}