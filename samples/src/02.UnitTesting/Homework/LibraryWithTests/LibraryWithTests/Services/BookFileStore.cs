using LibraryWithTests.Core;
using LibraryWithTests.Domain;
using LibraryWithTests.Tests.Integration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryWithTests.Services
{
    class BookFileStore : IStore<Book>
    {
        private readonly IFIleBookStorageSettings _settings;

        public BookFileStore(IFIleBookStorageSettings settings)
        {
            _settings = settings;
        }

        public void Add(Book item)
        {
            var books = GetBooks();
            var calculatedId = books.GetIncrementedId();
            item.Id = calculatedId;
            books.Add(item);
            SaveBooks(books);
        }

        public void Delete(Book item)
        {
            var books = GetBooks();
            var bookToDelete = books.FirstOrDefault(x => x.Id == item.Id);
            books.Remove(bookToDelete);
            SaveBooks(books);
        }

        public List<Book> GetAll()
        {
            return GetBooks();
        }

        private List<Book> GetBooks()
        {
            var text = File.ReadAllText(_settings.FileNameWithData);
            var books = JsonConvert.DeserializeObject<List<Book>>(text);
            return books;
        }

        private void SaveBooks(List<Book> books)
        {
            var text = JsonConvert.SerializeObject(books);
            File.WriteAllText(_settings.FileNameWithData, text);
        }
    }
}
