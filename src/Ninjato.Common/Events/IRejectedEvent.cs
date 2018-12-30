namespace Ninjato.Common.Events
{
  public  interface IRejectedEvent : IEvent
  {
      ///
      // Reason for why the event is rejected
      ///
      string Reason { get; }

      ///
      // Code for why the event is rejected 
      /// 
      string Code { get; }
  }
}