
namespace Events.Demo01
{
    class Program
    {
        static void Main(string[] args)
        {
            var mngr = new MailManager();
            var post = new Post(mngr);
            var fax = new Fax(mngr);
            mngr.SimulateNewMail("Test@test.com", "Students", "Hello world");

        }
    }
}
