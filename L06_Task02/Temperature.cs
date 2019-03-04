using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_Task02
{
    public class Temperature
    {
        // конвертировать Цельсия в Фаренгейта
        public string CelToFahrenheit(double temperature)
        {
            return $"{temperature} Цельсия =    {temperature * 1.80 + 32.00} Фаренгейта";
        }

        // конвертировать Цельсия в Кельвина
        public string CelToKelvin(double temperature)
        {
            return $"{temperature} Цельсия =    {temperature + 273.15} Кельвина";
        }

        // конвертировать Фаренгейта в Кельвина
        public string FahrenheitToKelvin(double temperature)
        {
            return $"{temperature} Фаренгейта = {(temperature - 32.00)/ 1.800 + 273.15} Кельвина";
        }

        // конвертировать Фаренгейта в Цельсия
        public string FahrenheitToCel(double temperature)
        {
            return $"{temperature} Фаренгейта = {(temperature - 32.00) / 1.800} Цельсия";
        }

        // конвертировать Кельвина в Цельсия
        public string KelvinToCel(double temperature)
        {
            return $"{temperature} Кельвина =   {temperature - 273.15} Цельсия";
        }

        // конвертировать Кельвина в Фаренгейта
        public string KelvinToFahrenheit(double temperature)
        {
            return $"{temperature} Кельвина =   {(temperature - 273.15) * 1.8000 + 32.00} Фаренгейта";
        }
    }
}
