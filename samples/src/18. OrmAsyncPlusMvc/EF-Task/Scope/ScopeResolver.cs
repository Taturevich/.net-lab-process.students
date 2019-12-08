using System;
using System.Runtime.Remoting.Messaging;

namespace EF_Task.Scope
{
    public interface IScopeCreator
    {
        IDisposable CreateReadonly();
    }

    internal class NorthwindScopeCreator : IScopeCreator
    {
        private readonly IScopeContextCreator<NorthwindContext> _scopeContextCreator;

        public NorthwindScopeCreator(IScopeContextCreator<NorthwindContext> scopeContextCreator)
        {
            _scopeContextCreator = scopeContextCreator;
        }

        public IDisposable CreateReadonly() => _scopeContextCreator.CreateReadScope(() => new NorthwindContext());
    }
}
