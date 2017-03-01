using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApp.Infrastructure
{
    public class Disposeable
    {
        private bool isDisposed;

        ~Disposeable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}
