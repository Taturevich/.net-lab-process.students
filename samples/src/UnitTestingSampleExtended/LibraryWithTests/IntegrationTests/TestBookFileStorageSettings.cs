using LibraryWithTests.Services;
using System;
using System.IO;

namespace LibraryWithTests.Tests.Integration
{
    public class TestBookFileStorageSettings : IFIleStorageSettings
    {
        public string FileNameData 
            => Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Books_for_test.txt");
    }
}
