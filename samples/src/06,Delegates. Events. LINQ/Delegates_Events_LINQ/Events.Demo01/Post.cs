using System;

namespace Events.Demo01
{
    internal class Post
    {
        public Post(MailManager mm)
        {
            mm.NewMail += FaxMsg;
        }

        private void FaxMsg(object sender, NewMailEventArgs e)
        {
            Console.WriteLine("Sending mail to Post office:");
            Console.WriteLine($" From={e.From}, To={e.To}, Subject={e.Subject}");
        }

        public void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
        }
    }
}
