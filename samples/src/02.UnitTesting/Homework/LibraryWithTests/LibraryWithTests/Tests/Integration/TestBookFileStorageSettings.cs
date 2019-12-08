using LibraryWithTests.Services;
using System;
using System.IO;

namespace LibraryWithTests.Tests.Integration
{
    public class TestBookFileStorageSettings : IFIleBookStorageSettings
    {
        public string FileNameWithData 
            => Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Books_for_test.txt");
    }
}
