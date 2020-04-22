using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmUseCases
{
    public class SimpleMessage
    {
        public SimpleMessage(string messageText)
        {
            MessageText = messageText;
        }

        public string MessageText { get; }
    }
}
