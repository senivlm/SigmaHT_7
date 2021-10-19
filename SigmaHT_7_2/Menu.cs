using System;
using System.Collections.Generic;
using System.IO;

namespace SigmaHT_7_2
{
    class Menu
    {паовіфарвіппал
        Dictionary<string, double> productsWeights;
        Dictionary<string, double> productsPrices;

        public Menu(string menuFile,string priceTagFile)
        {
            productsWeights = GetProductsWeights(menuFile);

            productsPrices = GetProductsPrices(priceTagFile);
        }

        public Dictionary<string, double> GetProductsWeights(string filePath)
        {
            StreamReader streamReader;

            try
            {
                streamReader = new StreamReader(filePath);
            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }

            string text = streamReader.ReadToEnd().Replace("\r\n\r\n","\n").Replace("\r\n", " ");

            string[] dishes = text.Split('\n');

            Dictionary<string, double> productsWeights = new Dictionary<string, double>();

            for (int i = 0; i < dishes.Length; i++)
            {
                string[] products = dishes[i].Split();
                
                for (int j = 1; j < products.Length - 1; j+=2)
                {
                    double weight;
                    if (!double.TryParse(products[j + 1], out weight))
                        throw new ArgumentException("Invalid weight");

                    if (productsWeights.ContainsKey(products[j]))
                    {
                        productsWeights[products[j]] += weight;
                        continue;
                    }
                        
                    productsWeights.Add(products[j], weight);
                }
            }

            return productsWeights;
        }

        public Dictionary<string, double> GetProductsPrices(string filePath)
        {
            StreamReader streamReader;

            try
            {
                streamReader = new StreamReader(filePath);
            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }

            string text = streamReader.ReadToEnd().Replace("\r\n", "\n");

            string[] prices = text.Split('\n');

            Dictionary<string, double> productsPrices = new Dictionary<string, double>();

            for (int i = 0; i < prices.Length; i++)
            {
                double price;
                if (!double.TryParse(prices[i].Split(' ')[1], out price))
                    throw new ArgumentException("Invalid price");

                productsPrices.Add(prices[i].Split(' ')[0], price);
            }

            return productsPrices;
        }

        public override string ToString()
        {
            string productsList = String.Empty;

            foreach (var item in productsPrices)
            {
                productsList += String.Format("{0,-10} {1,-5} {2}\n",
                    item.Key, productsWeights[item.Key], productsPrices[item.Key] * productsWeights[item.Key]);
            }

            return productsList;
        }
    }
}
