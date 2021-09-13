using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheManager.Core;

namespace SY.Com.Infrastructure
{
    public class CacheManager
    {
        private static CacheManager m_Cache = null;
        private static ICacheManager<object> manager = null;
        public static CacheManager Instance
        {
            get
            {
                if (m_Cache == null)
                {
                    m_Cache = new CacheManager();
                }
                if (manager == null)
                {
                    manager = CacheFactory.Build("getStartedCache", settings =>
                    {
                        settings.WithSystemRuntimeCacheHandle("handleName").WithExpiration(ExpirationMode.Sliding,TimeSpan.FromHours(1.00));
                    });
                }

                return m_Cache;
            }
        }

        public bool Exists(string key,string region="")
        {
            return manager.Exists(key,region);
        }

        public T get<T>(string key,string region = "")
        {
            return manager.Get<T>(key, region);
        }
        public bool Add<T>(string key,T t,string region = "")
        {
            try
            {
                manager.Put(key, t, region);
                return true;
            }
            catch (Exception ep)
            {
                return false;
            }
        }

        public bool Update<T>(string key,T t,string region = "")
        {
            try
            {
                manager.Update(key, region, val => t);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string key,string region="")
        {
            try
            {
                manager.Remove(key, region);
                return true;
            }
            catch {
                return false;
            }            
        }

        public bool Clear()
        {
            try
            {
                manager.Clear();
                return true;
            }
            catch {
                return false;
            }            
        }

        public bool ClearRegion(string region="")
        {
            try
            {
                manager.ClearRegion(region);
                return true;
            }
            catch {
                return false;
            }
        }

    }
}
