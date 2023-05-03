using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class Card
    {
        private string _operators;
        private string _numbers;

        public string Operators
        {
            get { return _operators; }
        }

        public string Numbers
        {
            get { return _numbers; }
        }

        public Card(string value, string type)
        {
            _operators = type;
            _numbers = value;
        }
    }
}

