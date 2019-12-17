using System;

namespace LibraryWithTests.Services
{
    class FileBookStorageSettings : IFIleStorageSettings
    {
        ValueType d;
        public string FileNameData => "Books.txt";
    }
}
