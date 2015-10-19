using System;
using System.IO;
using System.Linq;
using FrankBryce.Random.Generator;

namespace FrankBryce.Random.Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var hexEnum = new RandomHexEnumerable(new PppWrapper());

            File.Delete("rand.csv");

            for(var sampleSize = 10; sampleSize < 1000000; sampleSize *= 10)
            {
                Console.WriteLine("Samples of size: " + sampleSize);

                File.AppendAllText("rand.csv", sampleSize.ToString() + "\r\n");

                for(var i = 0; i < 100; i++)
                {
                    var chars = hexEnum.Take(sampleSize);
                    byte[] charsRead = new byte[16];
                    var hexDigits = chars.Select(x =>
                    {
                        switch(x)
                        {
                            case '0':
                                return (byte)0;
                            case '1':
                                return (byte)1;
                            case '2':
                                return (byte)2;
                            case '3':
                                return (byte)3;
                            case '4':
                                return (byte)4;
                            case '5':
                                return (byte)5;
                            case '6':
                                return (byte)6;
                            case '7':
                                return (byte)7;
                            case '8':
                                return (byte)8;
                            case '9':
                                return (byte)9;
                            case 'a':
                                return (byte)10;
                            case 'b':
                                return (byte)11;
                            case 'c':
                                return (byte)12;
                            case 'd':
                                return (byte)13;
                            case 'e':
                                return (byte)14;
                            case 'f':
                                return (byte)15;
                            default:
                                throw new ArgumentException("character must be a hex digit");
                        }
                    }).ToArray();

                    for(byte b = 0; b < 16; b++)
                    {
                        charsRead[b] = (byte)hexDigits.Count(x => x == b);
                    }

                    // put chars in .csv
                    File.AppendAllText("rand.csv", string.Join(",", charsRead.OrderBy(x => x)) + "\r\n");
                }
            }
        }
    }
}
