using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Internal.Utilities
{
    public static class ReflectionUtility
    {
        public static Type[] GetSubclassesOf<T>()
        {
            return Assembly.GetExecutingAssembly()
                .DefinedTypes
                .Where(t => t.IsSubclassOf(typeof(T)) && !t.IsAbstract).ToArray();
        }
    }
}
