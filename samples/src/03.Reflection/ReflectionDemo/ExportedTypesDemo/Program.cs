using System;
using System.Reflection;

namespace ExportedTypesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataAssembly = "System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            LoadAssemAndShowPublicTypes(dataAssembly);
        }

        private static void LoadAssemAndShowPublicTypes(String assemId)
        {        
            // Явная загрузка сборки в домен приложений     
            var a = Assembly.Load(assemId);
            // Цикл выполняется для каждого типа, открыто экспортируемого загруженной сборкой     
            foreach (var t in a.ExportedTypes)
            {
                // Вывод полного имени типа      
                Console.WriteLine(t.FullName);
            }
        } 
    }
}
