using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace intrcptn {
    public class Program {
        public enum IPType {
            UINT = 0,
            STRING = 1
        }

        static string get_string(uint ip) {
            return string.Concat(new object[] { ip >> 24 & 255U, ".", ip >> 16 & 255U, ".", ip >> 8 & 255U, ".", ip & 255U });
        }

		static uint get_uint(string ip) {
			if (string.IsNullOrWhiteSpace(ip)) return 0U;
			string[] array = ip.Split(new char[] { '.' });
			if (array.Length != 4) return 0U;
			uint num = 0U;
			uint num2;
			if (uint.TryParse(array[0], out num2)) num |= (num2 & 255U) << 24;
            if (uint.TryParse(array[1], out num2)) num |= (num2 & 255U) << 16;
            if (uint.TryParse(array[2], out num2)) num |= (num2 & 255U) << 8;
            if (uint.TryParse(array[3], out num2)) num |= (num2 & 255U);
            return num;
		}

		static void Main(string[] args) {
            string arg = null;
            if (args.Length < 1) {
                Console.Write("Enter ip(uint or string whatever) = ");
                arg = Console.ReadLine();
            }
            else arg = args[0];
            
            IPType type;
            if (arg.Contains(".")) type = IPType.STRING;
            else type = IPType.UINT;

            if (type == IPType.STRING) Console.WriteLine(get_uint(arg));
            else Console.WriteLine(get_string(Convert.ToUInt32(arg)));
            Console.ReadKey();
            return;
        }
    }
}
