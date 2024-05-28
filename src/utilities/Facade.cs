using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public abstract class Facade<TFacade>
            where TFacade : new()
    {
        private static readonly Lazy<TFacade> _lazyFacade = new Lazy<TFacade>(() => new TFacade());

        public static TFacade Instance
        {
            get
            {
                return _lazyFacade.Value;
            }
        }
    }
}
