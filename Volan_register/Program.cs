using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Volan_register
{
    class Program
    {
        static void Main(string[] args)
        {
            //Készíts egy Volán példányt és töltsd fel
            Volan volan = new Volan();

            //Amennyiben a feltöltés során kivétel keletkezik, azt kapd el és írd ki a képernyőre a kivételt kiváltó busz rendszámát és a kivételt hibaüzenetét!
            try
            {
                StreamReader reader = new StreamReader("input.txt");

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(';');

                    volan.AddBus(
                        data[0],
                        byte.Parse(data[1]),
                        double.Parse(data[2]),
                        data[3]);
                }

                reader.Close();
            }
            catch
            {
                ///????
            }

            //Írd ki a képernyőre annak a busznak az adatait (ha lehet, akkor ToString metódussal!), melynek a tényleges fogyasztása a legkisebb!

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
