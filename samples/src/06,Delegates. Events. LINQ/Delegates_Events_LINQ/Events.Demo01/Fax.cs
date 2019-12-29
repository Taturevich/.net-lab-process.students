using System;

namespace Events.Demo01
{
    internal class Fax
    {
        public Fax(MailManager mm)
        {
            mm.NewMail += FaxMsg;
        }

        private void FaxMsg(object sender, NewMailEventArgs e)
        {
            Console.WriteLine("Faxing mail message:");
            Console.WriteLine($" From={e.From}, To={e.To}, Subject={e.Subject}");
        }

        public void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
        } 
    }
}