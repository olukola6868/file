namespace WORK.Interface
{
    public interface ICardManager
    {
        public void CreateCard(int price,long cardPin);
        public void CreateHundredNairaCard(int price);
        public void CreateTwoHundredNairaCard(int price);
        public void CreateFiveHundredNairaCard(int price);
        public void CreateOneThousandHundredNairaCard(int price);
        public void UpdateCard(int price, long cardPin);
        public void DeleteCard(long cardPin,int price);
        public void GetAllCard();
        public void ReadFromFile();
        public void RewriteFile();

       
    }
}
