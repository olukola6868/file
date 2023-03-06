using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WORK.models
{
    public class Card
    {
        public long CardPin { get; set; }
        public int Price { get; set; }
        public int ID { get; set; }
        public Card(long cardPin, int price)
        {
            CardPin = cardPin;
            Price = price;
            // ID = id;
        }

        public override string ToString()
        {
            return $"Card           {CardPin}           {Price}";
        }
        public int Test(long cardPin, int price)
        {
            return price;
        }
        public string ConvertToFileFormat()
        {
            return $"{CardPin}***{Price}";
        }
        public static Card ConvertToCard(string cardInfo)
        {
            string[] info = cardInfo.Split("***");
            return new Card(long.Parse(info[0]), int.Parse(info[1]));
        }
    }
}