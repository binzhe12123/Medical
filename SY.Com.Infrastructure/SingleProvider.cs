using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SY.Com.Infrastructure
{
    public class SingleProvider<T> where T:new ()
    {
        private static readonly T _instance = new T();

        public static T Instance
        {
            get { return _instance; } 
        }

    }
}
