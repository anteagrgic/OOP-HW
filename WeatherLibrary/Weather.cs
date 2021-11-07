/*Radite sustav koji omogućuje rad s informacijama o wremenskim prilikama. Vremenske prilike predstavljene su klasom *Weather* sa stanjem za trenutnu 
temperaturu u stupnjevima Celzijusa, relativnu vlažnost zraka u postotcima te jačinu vjetra u km/h. Implementirajte sve potrebne klase definirajući njihova stanja 
i metode kako bi se testni program u nastavku mogao ispravno izvesti. 

## Dodatne upute i materijali

* Više o osjetu hladnoće vjetra (engl. *wind chill*) moguće je pronaći na [Wind chill - Wiki](https://en.wikipedia.org/wiki/Wind_chill).
	* Paziti na to u kojim se slučajevima računa osjet hladnoće vjetra, ako ga nije moguće odrediti uzima se da je osjet = 0.
* Više o osjetu topline (engl. Heat index, feels like) moguće je pronaći na [Heat index - Wiki](https://en.wikipedia.org/wiki/Heat_index).
	* Paziti na to da se rabi ispravna jednadžba, namijenjena odgovarajućoj mjernoj jedinici temperature.
* Niti jedna od ovih stvari ne predstavlja stanje.

## Pravila

* Koristiti programski jezik C#.
* Svaka klasa ide u zasebnu datoteku, imena jednakog kao i klasa
* Kreirati dva projekta unutar solutiona, jedan koji će biti definiran kao *class library* i u kojem će biti logika rješenja, a drugi koji će biti konzolna aplikacija
 i koji će predstavljati UI. Referencirati projekt s rješenjem u projektu koji predstavlja UI i na taj način rabiti njegove elemente.
* Koristiti .NET Core projekte u VS-u.
* Uploadati rješenje na Github, na privatni repozitorij.
* Zalijepiti link na repozitorij na odgovarajuće mjesto na Merlinu za predaju zadaće.
* Nakon isteka roka za zadaću učiniti repozitorij javnim kako bi mogao biti ocijenjen.
* Prepisivanje je strogo zabranjeno i bit će kažnjavano (i za izvor i za prepisivača!).
*/

using System;

namespace WeatherLibrary
{
    public class Weather
    {
        private double temperature;
        private double humidity;
        private double windSpeed;

        public Weather(double temperature, double humidity, double windSpeed)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.windSpeed = windSpeed;
        }

        public Weather(){}

        public double GetTemperature()
        {
            return temperature;
        }

        public void SetTemperature(double temperature)
        {
            this.temperature = temperature;
        }
        public double GetHumidity()
        {
            return humidity;
        }

        public void SetHumidity(double humidity)
        {
            this.humidity = humidity;
        }
        public double GetWindSpeed()
        {
            return windSpeed;
        }

        public void SetWindSpeed(double windSpeed)
        {
            this.windSpeed = windSpeed;
        }

        public double CalculateFeelsLikeTemperature() 
        {
            double formula;

            double c1 = -8.78469475556;
            double c2 = 1.61139411;
            double c3 = 2.33854883889;
            double c4 = -0.14611605;
            double c5 = -0.012308094;
            double c6 = -0.0164248277778;
            double c7 = 0.002211732;
            double c8 = 0.00072546;
            double c9 = -0.000003582;

            formula = c1 + c2 * temperature + c3 * humidity + c4 * humidity * temperature + c5 * Math.Pow(temperature, 2) + c6 * Math.Pow(humidity, 2) + c7 * Math.Pow(temperature, 2) * humidity + c8 * temperature * Math.Pow(humidity, 2) + c9 * Math.Pow(temperature, 2) * Math.Pow(humidity, 2);


            return formula;
        }

        public double CalculateWindChill()
        {
            double formula;
            formula = 13.12 + (0.6215 * temperature) - (11.37 * Math.Pow(windSpeed, 0.16)) + (0.3965 * temperature * Math.Pow(windSpeed, 0.16));
            
            if (windSpeed<= 4.8 || temperature >= 10)
            {
                return 0;
            }
            else return formula;
        }






    }
}
