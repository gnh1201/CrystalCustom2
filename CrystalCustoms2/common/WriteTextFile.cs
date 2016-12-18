using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.common
{
    class WriteTextFile
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        private static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }


        private static string generateFileName(string extension)
        {
            string fileName = RandomString(15) + "." + extension;

            return fileName;
        }

        public static void write(string content) {
            string newFileName = @"cache\" + generateFileName("xml");
            System.IO.File.WriteAllText(newFileName, content, Encoding.Default);
        }
    }
}
