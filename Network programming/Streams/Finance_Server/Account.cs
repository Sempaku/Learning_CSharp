using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Finance_Server
{
    class Account
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public decimal Sum { get; private set; }
        public int Procent { get; private set; }
        public Account(string name, decimal sum, int period)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.Sum = sum;
            this.Procent = period > 6 ? 10 : 1;
        }
    }
}
