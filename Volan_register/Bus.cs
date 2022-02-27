using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volan_register
{
    class Bus
    {
        private string model;

        public string Model
        {
            get { return model; }
            private set
            {
                if (value == null)
                    throw new Exception("Nem lehet a busz modelljének a neve nulla!");
                if (value.Length < 2)
                    throw new Exception("A név túl rövid!");
                model = value;
            }
        }

        private byte age;

        public byte Age
        {
            get { return age; }
            set {
                if (value < 0)
                    throw new Exception("A busz életkora nem lehet negatív szám!");
                if (value < age)
                    throw new Exception("Az új érték nem lehet kisebb a régi értéknél!");
                age = value;
            }
        }

        private double factoryConsumption;

        public double FactoryConsumption
        {
            get { return factoryConsumption; }
            private set {
                if (value < 0)
                    throw new Exception("A gyári fogyasztás csak pozitív szám lehet!");
                factoryConsumption = value; }
        }

        private string licencePlateNumber;

        public string LicencePlateNumber
        {
            get { return licencePlateNumber; }
            set {
                       if (value == null)
                            throw new Exception("A rendszámnak 3 számból és 3 betűből kell állnia.");
                       if (value.Length != 6)
                            throw new Exception("Nem megfelelő hossz!");

                for (int i = 0; i < value.Length; i++)
                {
                    if (value[0] < 41 && value[0] > 90 || value[1] < 41 && value[1] > 90 || value[2] < 41 && value[2] > 90) //itt a nagybetűkhöz tartozó ASCII kódot használtam
                        throw new Exception("A rendszám első három karaktere csak az abc nagy betűi lehetnek!");
                    if (value[3] < 0 && value[0] > 9 || value[4] < 0 && value[4] > 9 || value[5] < 0 && value[5] > 9)
                        throw new Exception("A rendszám utolsó három karaktere csak 0 és 9 közötti számokat vehet fel!");
                }
                        licencePlateNumber = value; }
        }

        public double RealConsumption
        {
            get { return RealConsumption; }
            set {
                RealConsumption = FactoryConsumption * ((1 + age) / 20);
            }
        }

        public Bus(string model, byte age, double factoryConsumption, string licencePlateNumber)
        {
            Model = model;
            Age = age;
            FactoryConsumption = factoryConsumption;
            LicencePlateNumber = licencePlateNumber;
        }

        public Bus(string model, double factoryConsumption, string licencePlateNumber)
            : this (model, 0, factoryConsumption, licencePlateNumber)
        {
        }

        public Bus(string model, string licencePlateNumber)
           : this(model, 0, 20, licencePlateNumber)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Modell: {0}\n", Model);
            sb.AppendFormat("Életkor: {0}\n", Age);
            sb.AppendFormat("Gyári fogyasztás: {0}\n", FactoryConsumption);
            sb.AppendFormat("Rendszám: {0} Ft\n", LicencePlateNumber);
            return sb.ToString();
        }
    }
}
