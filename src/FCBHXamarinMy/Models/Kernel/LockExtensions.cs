using System;
using System.Threading;

namespace FCBHXamarinMy.Models.Kernel
{
    // From http://stackoverflow.com/questions/170028/how-would-you-simplify-entering-and-exiting-a-readerwriterlock
    // Usage: 
    //   ReaderWriter8LockSlim _locker = new ReaderWriterLockSlim();
    //   using (_locker.Read())
    //   {
    //        ... do stuff ...
    //   }

    public static class LockExtensions
    {
        #region class: ReadLockToken
        private sealed class ReadLockToken : IDisposable
        {
            private ReaderWriterLockSlim _sync;

            public ReadLockToken(ReaderWriterLockSlim sync)
            {
                _sync = sync;
                sync.EnterReadLock();
            }

            public void Dispose()
            {
                if (_sync == null)
                {
                    return;
                }

                _sync.ExitReadLock();
                _sync = null;
            }
        }
        #endregion
        #region ExtensionMethod: IDisposable Read(this ReaderWriterLockSlim obj)
        /// <summary>
        /// Establishes a Read lock for the contained operations
        /// </summary>
        /// <param name="obj">The locking object</param>
        public static IDisposable Read(this ReaderWriterLockSlim obj)
        {
            return new ReadLockToken(obj);
        }
        #endregion

        #region class: WriteLockToken
        private sealed class WriteLockToken : IDisposable
        {
            private ReaderWriterLockSlim _sync;

            public WriteLockToken(ReaderWriterLockSlim sync)
            {
                _sync = sync;
                sync.EnterWriteLock();
            }

            public void Dispose()
            {
                if (_sync == null)
                {
                    return;
                }

                _sync.ExitWriteLock();
                _sync = null;
            }
        }
        #endregion
        #region ExtensionMethod: IDisposable Write(this ReaderWriterLockSlim obj)
        /// <summary>
        /// Establishes a Write lock for the contained operations
        /// </summary>
        /// <param name="obj">The locking object</param>
        public static IDisposable Write(this ReaderWriterLockSlim obj)
        {
            return new WriteLockToken(obj);
        }
        #endregion

        #region class: UpgradeableToken
        private sealed class UpgradeableToken : IDisposable
        {
            private ReaderWriterLockSlim _sync;

            public UpgradeableToken(ReaderWriterLockSlim sync)
            {
                _sync = sync;
                sync.EnterUpgradeableReadLock();
            }

            public void Dispose()
            {
                if (_sync == null)
                {
                    return;
                }

                _sync.ExitUpgradeableReadLock();
                _sync = null;
            }
        }
        #endregion
        #region ExtensionMethod: IDisposable Upgradeable(this ReaderWriterLockSlim obj)
        /// <summary>
        /// Establishes a Upgradeable lock for the contained operations
        /// </summary>
        /// <param name="obj">The locking object</param>
        public static IDisposable Upgradeable(this ReaderWriterLockSlim obj)
        {
            return new UpgradeableToken(obj);
        }
        #endregion

    }
}
