using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Volan_register
{
    class Program
    {
        static void Main(string[] args)
        {           
            //Készíts egy Volán példányt és töltsd fel
            Volan volan = new Volan();
            
            
            StreamReader reader = new StreamReader("input.txt");
                
            while (!reader.EndOfStream)
            {
                
                string line = reader.ReadLine();
                string[] data = line.Split(';');

                try
                {
                    volan.AddBus(
                        data[0],
                        int.Parse(data[1]),
                        double.Parse(data[2], CultureInfo.InvariantCulture),
                        data[3]);
                } 
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message + " Rendszáma: " + data[data.Length - 1]);
                }
            }

            reader.Close();
            

            Console.WriteLine(volan.BusWithMinRealConsumption);

            Console.ReadKey();
        }
    }
}
