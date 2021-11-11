using System;

namespace Security1
{
    class Program
    {
        public static String HEX2ASCII(String hex)
        {
            String asciiText = "";
            for (int i = 0; i < hex.Length; i += 2)
            {
                String partLine = hex.Substring(i, 2);
                char cherapter = (char)Convert.ToInt32(partLine, 16); ;

                asciiText = asciiText + cherapter;
            }
            return asciiText;
        }


        public static string XORDecoder(string Text, int key)
        {

            char[] outputText = new char[Text.Length];

            for (int i = 0; i < Text.Length; ++i)
            {
                outputText[i] = (char)(Text[i] ^ key);
            }

            return new string(outputText);
        }
        static void Main(string[] args)
        {

            String inputPath = "D:/123.txt";
            String outPath = "D:/124.txt";
            string lines = File.ReadAllText(inputPath);

            string temp;
            string str = HEX2ASCII(lines);
            string kek = "";
            for (int i = 0; i < 70; i++)
            {
                /* kek += "\n----------------------------------";
                 kek += i+1;
                 kek += "\n";
                 kek += XORCipher(str, i);  */
                temp = XORDecoder(str, i);

                if (temp.Contains(" the "))
                {
                    kek += XORDecoder(str, i);
                    break;
                }

            }
            using (StreamWriter sw = new StreamWriter(outPath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(kek);
            }
        }



    }
}
