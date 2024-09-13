using System.Runtime.CompilerServices;

namespace Shift_Cipher
{
    internal class Program
    {
        static string alphabetString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static void Main(string[] args)
        {
            bool cipherFlag = true;
            int shift = 0;
            int decipherMethod = 0;
            string cipheredMessageDefault = "IZW WOZNCCM FSWHLJX UILR SMHGT WVZXH! DYE DQEVG PMHN HCO NLE TSBUZFLUHA GYGR NKW MMTLV!\r\n";
            string cipheredMessageUser;
            


            Console.WriteLine("Enter ciphered message.");
            cipheredMessageUser = Console.ReadLine();

            Console.WriteLine("Choose between deciphering method. 0 is Ceaser, 1 is shift.");
            while (cipherFlag)
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0:
                        cipherFlag = false;
                        decipherMethod = 0;
                        break;
                    case 1:
                        cipherFlag = false;
                        decipherMethod = 1;
                        break;
                    default:
                        Console.WriteLine("Please choose between 0 and 1");
                        break;

                }
            }



            Console.WriteLine("Enter possible shift. If unknown, default is 0.");
            while (true)
            {
                try
                {
                    shift = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Please re-enter possible shift number.");
                }

            }

            switch(decipherMethod)
            {
                case 0:
                    for (int i = 0; i < 26; i++)
                    {
                        string decoded = DecodeCeaser(cipheredMessageUser, i);
                        Console.WriteLine(decoded);
                    }
                    break;
                case 1:
                    for (int i = 0; i < 26; i++)
                    {
                        string decoded = DecodeShift(cipheredMessageUser, i);
                        Console.WriteLine(decoded);
                    }
                    break;
            }



        }

        static string DecodeCeaser(string cipheredMessage,int shift)
        {
            char letterCiphered;
            char letterDeciphered;
            int letterCipheredIndexNum;
            int letterDecipheredIndexNum;
            int a;

            string decipheredMessage = "";

            for (int i = 0; i < cipheredMessage.Length; i++)
            {
                letterCiphered = cipheredMessage[i];

                //decipher letters only
                if (Char.IsLetter(letterCiphered))
                {
                    //shift cannot be big
                    shift = shift % 26;
                    letterCipheredIndexNum = alphabetString.IndexOf(letterCiphered);
                    letterDecipheredIndexNum = letterCipheredIndexNum - shift;
                    if (letterDecipheredIndexNum < 0)
                    {
                        letterDecipheredIndexNum = letterDecipheredIndexNum + 26;
                    }
                    letterDeciphered = alphabetString[letterDecipheredIndexNum];
                    decipheredMessage += letterDeciphered.ToString();
                }
                else
                {
                    letterDeciphered = letterCiphered;
                    decipheredMessage += letterDeciphered.ToString();
                }
            }

            return decipheredMessage;
        }

        static string DecodeShift(string cipheredMessage, int shift)
        {
            char letterCiphered;
            char letterDeciphered;
            int letterCipheredIndexNum;
            int letterDecipheredIndexNum;
            int a = 0;

            string decipheredMessage = "";
            
            for (int i = 0; i < cipheredMessage.Length; i++)
            {
                
                letterCiphered = cipheredMessage[i];

                //decipher letters only
                if (Char.IsLetter(letterCiphered))
                {
                    //shift cannot be big
                    shift = shift % 26;
                    letterCipheredIndexNum = alphabetString.IndexOf(letterCiphered);
                    letterDecipheredIndexNum = letterCipheredIndexNum - shift - a;
                    while (letterDecipheredIndexNum < 0)
                    {
                        letterDecipheredIndexNum = letterDecipheredIndexNum + 26;
                    }
                    letterDeciphered = alphabetString[letterDecipheredIndexNum];
                    decipheredMessage += letterDeciphered.ToString();
                }
                else
                {
                    letterDeciphered = letterCiphered;
                    decipheredMessage += letterDeciphered.ToString();
                    a--;
                }

                a++;
            }

            return decipheredMessage;
        }


    }
}