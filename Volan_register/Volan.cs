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
                if (index >= 0 && index <= buses.Count)
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

        public void AddBus(string model, int age, double factoryConsumption, string licencePlateNumber)
        {
            Bus newBus = new Bus(model, age, factoryConsumption, licencePlateNumber);
            if (buses.Contains(newBus) || buses.Any(b => b.Model == model && b.Age < age))
                throw new Exception("Van már ilyen rendszámú, azonos modellű, fiatalabb busz!");           
            buses.Add(newBus);
        } 

        public Bus BusWithMinRealConsumption
        {
            get
            {
                Bus minBus = buses[0];
                foreach (Bus bus in buses)
                {
                    if (bus.RealConsumption < minBus.RealConsumption)
                        minBus = bus;
                }
                return minBus;
            }
        }
    }
}
