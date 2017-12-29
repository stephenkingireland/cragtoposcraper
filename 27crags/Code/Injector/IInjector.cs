using System.Collections.Generic;

namespace _27crags.Code.Injector
{
    public interface IInjector
    {
        void Inject(IEnumerable<Climb> climbsToInject, string fileName);
    }
}
