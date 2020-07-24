
using System;
using System.Collections.Generic;

namespace FrameworkByFrancis
{
    public static partial class Utility
    {
        public static class Assembly
        {
            private static readonly System.Reflection.Assembly[] s_Assemblies=null;
            private static readonly Dictionary<string,Type> s_CachedTypes=new Dictionary<string, Type>(StringComparer.Ordinal);
        }
    }
}