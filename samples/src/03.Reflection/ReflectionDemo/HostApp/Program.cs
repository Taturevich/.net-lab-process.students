namespace HostApp
{
    using Shared;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            // Находим каталог, содержащий файл HostApp.exe      
            var AddInDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            // Предполагается, что сборки подключаемых модулей       
            // находятся в одном каталоге с EXE-файлом хоста
            var AddInAssemblies = Directory.EnumerateFiles(AddInDir, "*.dll");

            // Создание набора объектов Type, которые могут использоваться хостом
            var AddInTypes = new List<Type>();
            foreach (var file in AddInAssemblies)
            {
                var name = AssemblyName.GetAssemblyName(file);
                var assembly = Assembly.Load(name);
                AddInTypes.AddRange(assembly.ExportedTypes.Where(tp => tp.IsClass && typeof(IAddIn).GetTypeInfo().IsAssignableFrom(tp.GetTypeInfo())));
            }

            // Инициализация завершена: хост обнаружил типы, пригодные для использования
            // Пример конструирования объектов подключаемых компонентов 
            // и их использования хостом
            foreach (var t in AddInTypes)
            {
                var ai = (IAddIn)Activator.CreateInstance(t);
                Console.WriteLine(ai.Do(5));
            }
        }
    }
}
