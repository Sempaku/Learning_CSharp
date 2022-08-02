using System;
using System.Collections.Generic;
using System.Text;

namespace Normal_I_Interface_Segregation_Principle
{
    class NormalSendMsgExample
    {
    }

    interface IMessage
    {
        void Send();
        string ToAddress { get; set; }
        string FromAddress { get; set; }
    }

    interface IVoiceMessage : IMessage
    {
        byte[] Voice { get; set; }
    }

    interface ITextMessage : IMessage
    {
        string Text { get; set; }
    }

    interface IEmailMessage : IMessage
    {
        string Subject { get; set; }
    }

    class VoiceMessage : IVoiceMessage
    {
        public string ToAddress { get; set; } = "";
        public string FromAddress { get; set; } = "";

        public byte[] Voice { get; set; } = Array.Empty<byte>();

        public void Send() => Console.WriteLine("Передача голосового сообщения...");
    }

    class EmailMessage : IEmailMessage
    {
        public string ToAddress { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Text { get; set; } = "";
        public void Send() => Console.WriteLine("Отправка email: {0}", Text);
    }

    class SmsMessage : ITextMessage
    {
        public string ToAddress { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string Text { get; set; } = "";
        public void Send() => Console.WriteLine("Отправка sms: {0}", Text);
    }
}
