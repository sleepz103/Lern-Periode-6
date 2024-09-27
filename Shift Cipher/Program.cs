using System.Runtime.CompilerServices;

namespace Shift_Cipher
{
    internal class Program
    {
        static string alphabetString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static void Main(string[] args)
        {
            bool decipherMethodFlag = true;
            int decipherMethod = 0;
            string cipheredMessageUser;
            
            Console.WriteLine("Enter ciphered message.");
            cipheredMessageUser = Console.ReadLine();

            Console.WriteLine("Choose between deciphering method. 1 is Ceaser, 2 is Shift.");
            while (decipherMethodFlag)
            {
                try
                {
                    decipherMethod = Convert.ToInt32(Console.ReadLine());
                    if (decipherMethod == 1 || decipherMethod == 2)
                    {
                        decipherMethodFlag = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Enter 1 for Ceaser deciphering method or 2 for Shift method");
                }
            }

            decipherMethodFlag = true;
            while (decipherMethodFlag)
            {
                switch (decipherMethod)
                {
                    case 1:
                        decipherMethodFlag = false;
                        decipherMethod = 1;
                        break;
                    case 2:
                        decipherMethodFlag = false;
                        decipherMethod = 2;
                        break;
                    default:
                        Console.WriteLine("Please choose between 1 and 2");
                        break;

                }
            }

            switch(decipherMethod)
            {
                case 1:
                    for (int i = 0; i < 26; i++)
                    {
                        string decoded = DecodeCeaser(cipheredMessageUser, i);
                        Console.WriteLine(i + ". " + decoded);
                    }
                    break;
                case 2:
                    for (int i = 0; i < 26; i++)
                    {
                        string decoded = DecodeShift(cipheredMessageUser, i);
                        Console.WriteLine(i + ". " + decoded);
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
            
            cipheredMessage = cipheredMessage.ToUpper();
            string decipheredMessage = "";

            for (int i = 0; i < cipheredMessage.Length; i++)
            {
                letterCiphered = cipheredMessage[i];
                if (Char.IsLetter(letterCiphered))
                {
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
            cipheredMessage = cipheredMessage.ToUpper();

            for (int i = 0; i < cipheredMessage.Length; i++)
            {
                letterCiphered = cipheredMessage[i];
                if (Char.IsLetter(letterCiphered))
                {
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