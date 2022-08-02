using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_I_Interface_Segregation_Principle
{
    class ProblemSendMsgInterfaceExample
    {
    }

    interface IMessage
    {
        void Send();
        string Text { get; set; }
        string Subject { get; set; }
        string ToAddress { get; set; }
        string FromAddress { get; set; }

        byte[] Voice { get; set; } // добавили для голосовой почты
    }

    class EmailMessage : IMessage
    {
        public string Text { get; set; } = "";
        public string Subject { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public string FromAddress { get; set; } = "";

        public void Send() => Console.WriteLine("Send email: {0}", Text );

        public byte[] Voice { get; set; } // совершенно ненужный функционал

    }

    class SmsMessage : IMessage
    {
        public string Text { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";

        public string Subject
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public byte[] Voice { get; set; } // совершенно ненужный функционал
        public void Send() => Console.WriteLine("Отправляем sms сообщение: {0}",Text);
    }

    class VoiceMessage : IMessage
    {
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public byte[] Voice { get; set; }

        public string Text
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public string Subject
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Send() => Console.WriteLine("Передача голосовой почты");
    }


}
