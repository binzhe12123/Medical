using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Infrastructure
{
    public class CloneClass
    {

        /// <summary>
        /// 对象clone,把t转成u
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="t"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static U Clone<T, U>(T t,U u)
        {
            Type ttype = t.GetType();
            Type utype = u.GetType();
            foreach (var tprop in ttype.GetProperties())
            {
                var uprop = utype.GetProperty(tprop.Name);
                if (uprop != null)
                {
                    uprop.SetValue(u, tprop.GetValue(t));
                }
            }
            return u;
        }

    }
}
