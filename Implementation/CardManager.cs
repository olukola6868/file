
using System;
using System.Collections.Generic;
using System.IO;
using WORK.Interface;
using WORK.models;

namespace WORK.Implementation
{
    public class CardManager : ICardManager
    {
        public static List<Card> Cards = new List<Card>();
        public string filePath = "./Files/card.txt";
        public void CreateCard(int price, long cardPin)
        {
            Random rand = new Random();
            int id = rand.Next(10, 99);
            Card card = new Card(cardPin, price);
            Cards.Add(card);
            Console.WriteLine(id);
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(card.ConvertToFileFormat());
            }
            Console.WriteLine($"Created successfully and your id is {id}");
        }

        public void CreateFiveHundredNairaCard(int price)
        {
            List<Card> listOfFiveHundredNairaCard = new List<Card>();
            Random rand = new Random();
            long cardPin = rand.NextInt64(100000000000000, 999999999999999);

            Random random = new Random();
            int FiveHundredNairaCardId = random.Next(100, 999);

            Card card = new Card(cardPin, price);
            listOfFiveHundredNairaCard.Add(card);

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(card.ConvertToFileFormat());
            }
            Console.WriteLine($"Congrats you have successfully bought your #500 card,and your card pin is: {cardPin} and your id is {FiveHundredNairaCardId}");
        }



        public void CreateHundredNairaCard(int price)
        {
            List<Card> listOfHundredNairaCard = new List<Card>();
            Random rand = new Random();
            long cardPin = rand.NextInt64(1000000000, 9999999999);

            Random random = new Random();
            int HundredNairaCardId = random.Next(100, 999);

            Card card = new Card(cardPin, price);
            listOfHundredNairaCard.Add(card);

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(card.ConvertToFileFormat());
            }

            Console.WriteLine($"Congrats you have successfully bought your #100 card,and your card pin is: {cardPin} and your card id is {HundredNairaCardId}");
        }

        public void CreateOneThousandHundredNairaCard(int price)
        {
            List<Card> listOfOneThousandHundredNairaCard = new List<Card>();
            Random rand = new Random();
            long cardPin = rand.NextInt64(10000000000000000, 99999999999999999);

            Random random = new Random();
            int OneThousandHundredNairaCardId = random.Next(100, 999);

            Card card = new Card(cardPin, price);
            listOfOneThousandHundredNairaCard.Add(card);

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(card.ConvertToFileFormat());
            }

            Console.WriteLine($"Congrats you have successfully bought your #1000 card and your card pin is: {cardPin} and your card id is {OneThousandHundredNairaCardId}");
        }
        public void CreateTwoHundredNairaCard(int price)
        {
            List<Card> listOfTwoHundredNairaCard = new List<Card>();
            Random rand = new Random();
            long cardPin = rand.NextInt64(100000000000, 999999999999);

            Random random = new Random();
            int TwoHundredNairaCardId = random.Next(100, 999);

            Card card = new Card(cardPin, price);
            listOfTwoHundredNairaCard.Add(card);

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(card.ConvertToFileFormat());
            }
            Console.WriteLine($"Congrats you have successfully bought your #200 card,and your card pin is: {cardPin} and your card id is {TwoHundredNairaCardId}");
        }
        public void DeleteCard(long cardPin, int price)
        {
            foreach (var item in Cards)
            {
                if (item.CardPin == cardPin && item.Price == price)
                {
                    Cards.Remove(item);
                    RewriteFile();
                    break;
                }
            }
            Console.WriteLine("Deleted sucessfully");
        }
        public void GetAllCard()
        {
            foreach (var item in Cards)
            {
                Console.WriteLine(item);
            }
        }
        public Card GetCard(int price, long cardPin)
        {
            foreach (var item in Cards)
            {
                if (item.Price == price && item.CardPin == cardPin)
                {
                    return item;
                }
            }
            return null;
        }
        public void ReadFromFile()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.Peek() > -1)
                {
                    string cardInfo = reader.ReadLine();
                    Cards.Add(Card.ConvertToCard(cardInfo));
                }
            }
        }

        public void RewriteFile()
        {
            File.WriteAllText(filePath, string.Empty);
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                foreach (var item in Cards)
                {
                    writer.WriteLine(item.ConvertToFileFormat());
                }
            }
        }
        public void UpdateCard(int price, long cardPin)
        {
            Card cardToUpdate = GetCard(price, cardPin);
            if (cardToUpdate != null)
            {
                cardToUpdate.Price = price;
                cardToUpdate.CardPin = cardPin;
                Console.WriteLine("card update is successful");
            }
            else
            {
                Console.WriteLine("Card not found");
            }
        }
    }
}