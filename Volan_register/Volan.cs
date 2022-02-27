using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volan_register
{
    class Volan
    {
        private List<Bus> buses = new List<Bus>();

        public Bus this[int index]
        {
            get
            {
                if (index <= 0 && index < buses.Count)
                    return buses[index];
                throw new Exception(string.Format("Nincs {0} bus", index));
            }
        }

        public Bus this[string licencePlateNumber]
        {
            get
            {
                foreach (Bus bus in buses)
                    if (licencePlateNumber == bus.LicencePlateNumber)
                        return bus;

                    throw new Exception(string.Format("Nincs ilyen {0} rendszám", licencePlateNumber));
            }
        }

        public void AddBus(string model, byte age, double factoryConsumption, string licencePlateNumber)
        {
            Bus newBus = new Bus(model, age, factoryConsumption, licencePlateNumber);
            if (buses.Contains(newBus) && newBus.Model == model && newBus.Age < model.Length)
                throw new Exception("Van már ilyen rendszámű, azonos modellű fiatalabb busz!");
            buses.Add(newBus);
        } 

        public Bus MaxRealConsumption
        {
            get
            {
                Bus maxBus = buses[0];
                foreach (Bus bus in buses)
                {
                    if (bus.RealConsumption > maxBus.RealConsumption)
                        maxBus = bus;
                }
                return maxBus;
            }
        }
       
    }
}
