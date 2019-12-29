namespace AddInA
{
    using Shared;

    public class AddInA : IAddIn
    {
        public string Do(int number)
        {
            return $"AddInA param = {number}, result = {number * 10}";
        }
    }
}
