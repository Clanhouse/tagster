using System;

namespace Tagster.CQRS.Events.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class IntegrationEventType : Attribute
    {
        public Type EventType { get; }

        public IntegrationEventType(Type eventType)
        {
            EventType = eventType;
        }
    }
}
