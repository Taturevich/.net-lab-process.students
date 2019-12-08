namespace AddInB
{
    using Shared;

    public class AddInB : IAddIn
    {
        public string Do(int number)
        {
            return $"AddInB param = {number}, result = {number * number}";
        }
    }
}
