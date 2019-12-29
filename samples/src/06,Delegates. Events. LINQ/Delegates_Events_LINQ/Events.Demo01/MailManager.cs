using System;
using System.Threading;

namespace Events.Demo01
{
    internal class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail;

        public void SimulateNewMail(string from, string to, string subject)
        {
            NewMailEventArgs e = new NewMailEventArgs(from, to, subject);
            OnNewMail(e);
        }

        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            Volatile.Read(ref NewMail)?.Invoke(this, e);
        }
    }
}
