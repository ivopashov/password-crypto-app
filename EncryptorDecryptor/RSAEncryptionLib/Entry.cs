using System;
using System.Collections.Generic;
using System.Text;

namespace RSAEncryptionLib
{
    public class Entry
    {
        public string Name { get; set; }
        public string OtherInfo { get; set; }
        public string Category{ get; set; }
        public string EncryptedPassword { get; set; }
    }
}
