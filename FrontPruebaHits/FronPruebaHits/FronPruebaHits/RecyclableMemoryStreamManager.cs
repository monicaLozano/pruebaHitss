namespace FronPruebaHits
{
    public class RecyclableMemoryStreamManager : IDisposable
    {
        private readonly ThreadLocal<RecyclableMemoryStream> _threadLocalInstance = new ThreadLocal<RecyclableMemoryStream>(() => new RecyclableMemoryStream());
        private readonly object _lock = new object();

        public MemoryStream GetStream()
        {
            var stream = _threadLocalInstance.Value;

            // Verificar si el MemoryStream ya ha sido liberado y cerrado
            if (stream.IsDisposed)
            {
                _threadLocalInstance.Value = new RecyclableMemoryStream();
                stream = _threadLocalInstance.Value;
            }

            return stream;
        }

        public void Dispose()
        {
            if (_threadLocalInstance.IsValueCreated)
            {
                _threadLocalInstance.Value.Dispose();
            }
            _threadLocalInstance.Dispose();
        }

    }

    public class RecyclableMemoryStream : MemoryStream
    {
        public bool IsDisposed { get; private set; }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Liberar los recursos administrados

                bool closeStream = false;
                try
                {
                    // Resetear el MemoryStream para su reutilización
                    SetLength(0);
                    closeStream = true;
                }
                catch (Exception ex)
                {
                    closeStream = true;
                }
                finally
                {
                    if (closeStream)
                    {
                        base.Dispose(disposing);
                    }
                }
            }
            IsDisposed = true;
            base.Dispose(disposing);
        }
    }
}
