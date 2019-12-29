using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExceptionTreeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadAssemblies();

            var allTypes = (from a in AppDomain.CurrentDomain.GetAssemblies()
                            from t in a.ExportedTypes where 
                            typeof(Exception).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo())
                            orderby t.Name select t).ToArray();

            Console.WriteLine(WalkInheritanceHierarchy(new StringBuilder(), 0, typeof(Exception), allTypes));
        }

        private static StringBuilder WalkInheritanceHierarchy(StringBuilder sb, Int32 indent, Type baseType, IEnumerable<Type> allTypes)
        {
            var spaces = new String(' ', indent * 3); sb.AppendLine(spaces + baseType.FullName);
            foreach (var t in allTypes)
            {
                if (t.GetTypeInfo().BaseType != baseType) continue;
                WalkInheritanceHierarchy(sb, indent + 1, t, allTypes);
            }
            return sb;
        }


        private static void LoadAssemblies()
        {
            String[] assemblies = {
                "System, Version={0}, Culture=neutral, PublicKeyToken={1}",
                "System.Core, Version={0}, Culture=neutral, PublicKeyToken={1}",
                "System.Data, Version={0}, Culture=neutral, PublicKeyToken={1}",
                "System.Runtime.Remoting, Version={0}, Culture=neutral, PublicKeyToken={1}",
                "System.Xml, Version={0}, Culture=neutral, PublicKeyToken={1}"
            };

            var EcmaPublicKeyToken = "b77a5c561934e089";

            var version = typeof(System.Object).Assembly.GetName().Version;

            foreach (var a in assemblies)
            {
                var AssemblyIdentity = string.Format(a, version, EcmaPublicKeyToken);
                Assembly.Load(AssemblyIdentity);
            }
        }
    }
}
