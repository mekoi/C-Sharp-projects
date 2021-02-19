using System;
using System.Collections.Generic;
using System.Linq;

namespace CountriesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Country> originalCountriesList = Country.GetCountries();

            #region Original list of countries
            Console.WriteLine("Original list of all countries:");

            foreach (Country country in originalCountriesList)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            #endregion

            #region Names of countries in alphabetical order
            Console.WriteLine("1. List the names of the countries in alphabetical order\n");

            var sortedCountriesByName = from country in originalCountriesList
                                        orderby country.Name ascending
                                        select country;

            foreach (Country country in sortedCountriesByName)
            {
                Console.WriteLine(country.Name);
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            #endregion

            #region Names of countries in descending order of number of resources
            Console.WriteLine("2. List the names of the countries in descending order of number of resources\n");

            var sortedCountriesByResources = from country in originalCountriesList
                                             let numberOfResources = country.Resources.Count()
                                             orderby numberOfResources descending
                                             select country;

            foreach (Country country in sortedCountriesByResources)
            {
                Console.WriteLine(country.Name);
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            #endregion

            #region Names of the countries that shares a border with Argentina
            Console.WriteLine("3. List the names of the countries that shares a border with Argentina\n");

            var countriesBorderWithArgentina = from country in originalCountriesList
                                               where country.Borders.Contains("Argentina")
                                               select country;

            foreach (Country country in countriesBorderWithArgentina)
            {
                Console.WriteLine(country.Name);
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            #endregion

            #region Names of the countries with more than 10,000,000 population 
            Console.WriteLine("4. List the names of the countries that has more than 10,000,000 population \n");

            var countriesMoreTenMillion = from country in originalCountriesList
                                          where country.Population > 10000000
                                          select country;

            foreach (Country country in countriesMoreTenMillion)
            {
                Console.WriteLine(country.Name);
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            #endregion

            #region Country with highest population 
            Console.WriteLine("5. List the country with highest population\n");

            var countryHighestPopulation = (from country in originalCountriesList
                                            orderby country.Population descending
                                            select country).Take(1);

            foreach (Country country in countryHighestPopulation)
            {
                Console.WriteLine(country.Name);
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            #endregion

            #region Religion in south America in dictionary order 
            Console.WriteLine("6. List all the religion in south America in dictionary order\n");

            var allReleigions = from country in originalCountriesList
                                from relig in country.Religions
                                orderby relig ascending
                                select relig;

            allReleigions = allReleigions.Distinct();

            foreach (var religion in allReleigions)
            {
                Console.WriteLine(religion);
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            #endregion
        }
    }
}
