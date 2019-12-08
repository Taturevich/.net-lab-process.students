using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Demo01
{
    internal class NewMailEventArgs : EventArgs
    {
        private readonly string m_from, m_to, m_subject;
        public NewMailEventArgs(string from, string to, string subject)
        {
            m_from = from;
            m_to = to;
            m_subject = subject;
        }

        public string From
        {
            get
            {
                return m_from;
            }
        }
        public string To
        {
            get
            {
                return m_to;
            }
        }
        public string Subject
        {
            get
            {
                return m_subject;
            }
        }
    }
}
