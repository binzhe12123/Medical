using System;
using System.Threading;

namespace SY.Com.Infrastructure
{
    public abstract class Disposable:IDisposable
    {
        /// <summary>
		/// 资源是否已经释放
		/// </summary>
		private long _Disposed = 0;

        /// <summary>
        /// 获取资源是否已经释放
        /// </summary>
        protected bool Disposed
        {
            get { return Interlocked.Read(ref _Disposed) == 1; }
        }
        /// <summary>
		/// 释放资源
		/// </summary>
		public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
		/// 释放资源
		/// </summary>
		/// <param name="disposeManagedResources">是否释放托管资源</param>
		protected void Dispose(bool disposeManagedResources)
        {
            if (Interlocked.CompareExchange(ref _Disposed, 1, 0) == 0)
            {
                if (disposeManagedResources)
                {
                    // 释放托管资源
                    ManagedDispose();

                    // 避免重复调用析构函数
                    GC.SuppressFinalize(this);
                }

                // 释放非托管资源
                UnmanagedDispose();
            }
        }

        /// <summary>
        /// 释放托管资源
        /// </summary>
        protected virtual void ManagedDispose()
        {

        }

        /// <summary>
        /// 释放非托管资源
        /// </summary>
        protected virtual void UnmanagedDispose()
        {

        }
    }
}
