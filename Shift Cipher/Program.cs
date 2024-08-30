using System.Runtime.CompilerServices;

namespace Shift_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int shift = 36;
            char letterCiphered;
            char letterDeciphered;
            int letterCipheredIndexNum;
            int letterDecipheredIndexNum;


            
            //char[] cipheredMessage = "IZW WOZNCCM FSWHLJX UILR SMHGT WVZXH! DYE DQEVG PMHN HCO NLE TSBUZFLUHA GYGR NKW MMTLV!".ToCharArray();
            //char[] cipheredMessage = "E".ToCharArray();
            char[] cipheredMessage = "DRSC SC K MOCOKB MSZROB KXN SDC UOI SC 36!".ToCharArray();

            string decipheredMessage = "";

            for (int i = 0; i < cipheredMessage.Length; i++)
            {
                letterCiphered = cipheredMessage[i];

                //decipher letters only
                if (Char.IsLetter(letterCiphered))
                {
                    //shift cannot be big
                    shift = shift % 26;
                    letterCipheredIndexNum = FindLetterIndex(letterCiphered);
                    letterDecipheredIndexNum = letterCipheredIndexNum - shift;
                    if (letterDecipheredIndexNum < 0 )
                    {
                        letterDecipheredIndexNum = letterDecipheredIndexNum + 26;
                    }
                    letterDeciphered = FindLetterByIndex(letterDecipheredIndexNum);
                    decipheredMessage += letterDeciphered.ToString();
                }
                else
                {
                    letterDeciphered = letterCiphered;
                    decipheredMessage += letterDeciphered.ToString();
                }
            }

            Console.WriteLine(decipheredMessage);
            
        }

        static int FindLetterIndex(char letter)
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int letterIndex = 0;

            for (int i = 0; i < alphabet.Length; i++ )
            {
                if (alphabet[i] == letter)
                {
                    letterIndex = i;
                    break;
                }

            }

            return letterIndex;
        }

        static char FindLetterByIndex(int letterIndexNum)
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char letterByIndex = ' ';

            for (int i = 0; i < alphabet.Length; i++)
            {
                if (i == letterIndexNum)
                {
                    letterByIndex = alphabet[i];
                    break;
                }

            }

            return letterByIndex;
        }

    }
}