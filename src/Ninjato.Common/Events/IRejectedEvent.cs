namespace Ninjato.Common.Events
{
    /// <summary>
    /// Rejected event.
    /// </summary>
    public  interface IRejectedEvent : IEvent
    {
        /// <summary>
        /// Gets the reason for why the event is rejected
        /// </summary>
        /// <value>The reason.</value>
        string Reason { get; }

        /// <summary>
        /// Gets the code for why the event is rejected .
        /// </summary>
        /// <value>The code.</value>
        string Code { get; }
    }
}