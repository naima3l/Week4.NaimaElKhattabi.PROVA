using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Week4.NaimaElKhattabi.Client.Contract;

namespace Week4.NaimaElKhattabi.Client
{
    public class Menu
    {
        internal static void Start()
        {
            bool quit = false;
            char choice;
            do
            {
                Console.WriteLine("Seleziona un'opzione del menu" +
                        "\n[ 1 ] - Inserisci un nuovo ordine " +
                        "\n[ 2 ] - Elimina un ordine" +
                        "\n[ 3 ] - Modifica dati di un ordine" +
                        "\n[ 4 ] - Visualizza tutti gli ordini" +
                        "\n" +
                        "\n[ 5 ] - Inserisci un nuovo cliente " +
                        "\n[ 6 ] - Elimina un cliente" +
                        "\n[ 7 ] - Modifica dati di un cliente" +
                        "\n[ 8 ] - Visualizza tutti i clienti" +
                        "\n" +
                        "\n[ q ] - ESCI");

                choice = Console.ReadKey().KeyChar;

                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        AddNewOrder();
                        break;
                    case '2':
                        DeleteOrder();
                        break;
                    case '3':
                        EditOrder();
                        break;
                    case '4':
                        FetchOrders();
                        break;
                    case '5':
                        AddNewCustomer();
                        break;
                    case '6':
                        DeleteCustomer();
                        break;
                    case '7':
                        EditCustomer();
                        break;
                    case '8':
                        FetchCustomers();
                        break;
                    case 'q':
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Scelta sconosciuta.");
                        break;
                }

            } while (!quit);
        }

        #region Customer
        //Metodi che, dopo aver chiesto all'utente delle informazioni (se servono), chiamano un metodo dell'istanza di proxy class

        public static void AddNewCustomer()
        {
            throw new NotImplementedException();

        }

        public static void FetchCustomers()
        {
            throw new NotImplementedException();
        }

        public static void EditCustomer()
        {
            throw new NotImplementedException();
        }


        public static void DeleteCustomer()
        {
            throw new NotImplementedException();

        }
        #endregion



        #region Order
        public static void FetchOrders()
        {
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44305/api/order")
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            //if(response.StatusCode == System.Net.HttpStatusCode.OK) //se risp da ok  -> la recupero come stringa
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                //Deserializzazione (da stringa (json) -> oggetto di C#)
                var result = JsonConvert.DeserializeObject<List<OrderContract>>(data);

                foreach (OrderContract o in result)
                {
                    Console.WriteLine($"\nId ordine : {o.Id} - Codice ordine : {o.CodiceOrdine} - Codice Prodotto : {o.CodiceProdotto} - Data Ordine : {o.DataOrdine} - Id Cliente : {o.ClienteId}");
                }
            }
        }

        private static void AddNewOrder()
        {
            throw new NotImplementedException();
        }


        public static void EditOrder()
        {
            throw new NotImplementedException();

        }
        public static void DeleteOrder()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
