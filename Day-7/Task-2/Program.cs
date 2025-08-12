using System;

namespace ThermostatApp
{
    public delegate void TemperatureChangeHandler(float newTemp);

    class Thermostat
    {
        private float _currentTemp;
        public event TemperatureChangeHandler OnTemperatureChange;

        public float CurrentTemp
        {
            get => _currentTemp;
            set
            {
                _currentTemp = value;
                Console.WriteLine($"\nThermostat: Current temperature set to {value}°C");
                OnTemperatureChange?.Invoke(value); // Fire event
            }
        }
    }

    class Heater
    {
        public float Temperature { get; set; }
        public void TemperatureChange(float newTemp)
        {
            Temperature = newTemp;
            if (newTemp < 20)
                Console.WriteLine($"Heater: It's cold ({newTemp}°C), turning heater ON.");
            else
                Console.WriteLine($"Heater: Temperature is fine ({newTemp}°C), turning heater OFF.");
        }
    }

    class Cooler
    {
        public float Temperature { get; set; }
        public void TemperatureChange(float newTemp)
        {
            Temperature = newTemp;
            if (newTemp > 25)
                Console.WriteLine($"Cooler: It's hot ({newTemp}°C), turning cooler ON.");
            else
                Console.WriteLine($"Cooler: Temperature is fine ({newTemp}°C), turning cooler OFF.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thermostat T = new Thermostat();
            Heater H = new Heater();
            Cooler C = new Cooler();

            T.OnTemperatureChange += C.TemperatureChange;
            T.OnTemperatureChange += H.TemperatureChange;

            // Test
            T.CurrentTemp = 18; // Cold
            T.CurrentTemp = 22; // Moderate
            T.CurrentTemp = 28; // Hot

            Console.ReadKey();
        }
    }
}
