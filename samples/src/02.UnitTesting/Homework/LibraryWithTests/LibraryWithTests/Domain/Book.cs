namespace LibraryWithTests.Domain
{
    public class Book : IHasBasicId
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
