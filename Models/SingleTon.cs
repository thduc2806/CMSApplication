using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssigmentCode.Models
{
	public class SingleTon
	{
        private static SingleTon instance = new SingleTon();
        private SingleTon() { }
        public static SingleTon getIntance()
        {
            return instance;
        }
        public string Role { get; set; }
        public string Username { get; set; }
    }
}
