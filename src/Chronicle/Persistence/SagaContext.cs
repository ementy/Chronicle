using System;

namespace Chronicle.Persistence
{
    internal sealed class SagaContext : ISagaContext
    {
        public Guid CorrelationId { get; }

        public string Originator { get; }

        private SagaContext(Guid correlationId, string originator)
            => (CorrelationId, Originator) = (correlationId, originator);

        public static ISagaContext Empty
            => new SagaContext(Guid.Empty, string.Empty);

        public static ISagaContext Create(Guid correlationId, string originator)
            => new SagaContext(correlationId, originator);
    }
}
