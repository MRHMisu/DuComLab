using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class CardGenerator
    {
        private DateTime productionDate;
        private int numberOfCards;

        public CardGenerator(DateTime productionDate, int numberOfCards)
        {
            this.productionDate = productionDate;
            this.numberOfCards = numberOfCards;
        }

        private string findCardNumberPrefix()
        {

            String day = productionDate.Day.ToString();
            if (Convert.ToInt32(day) < 10) day = "0" + day;

            String month = productionDate.Month.ToString();
            if (Convert.ToInt32(month) < 10) month = "0" + month;

            String year = productionDate.Year.ToString();
            char firstDigitOfYear = year.ElementAt<char>(2);
            char secondDigitOfYear = year.ElementAt<char>(3);
            year = firstDigitOfYear + "" + secondDigitOfYear;

            String cardNumberPrefix = day + month + year;

            return cardNumberPrefix;

        }
        private string findCardnumberSuffix(int number)
        {
            string suffix;

            int length = 4;
            suffix = number.ToString("D" + length);
            return suffix;
        }
        private String generateRandomLetters(Random randomGenerator)
        {
            int asciiForRandomLetter = randomGenerator.Next(65, 90);

            char randomLetter = (char)asciiForRandomLetter;

            return randomLetter.ToString();

        }
        private String generateRandomNumber(Random randomGenerator)
        {

            int randomNumber = randomGenerator.Next(0, 9);

            return randomNumber.ToString();
        }

        public string GetFirstCardOnProducedDate()
        {
            string prefix = findCardNumberPrefix();
            string FirstCardNumber=prefix + findCardnumberSuffix(0);
            return FirstCardNumber;
        }

        public List<String> produceCardNumbers()
        {
            List<String> cardNumbersList = new List<string>();

            string prefix = findCardNumberPrefix();
            string cardNumber;
            for (int i = 0; i < numberOfCards; i++)
            {
                cardNumber = prefix + findCardnumberSuffix(i);
                cardNumbersList.Add(cardNumber);

            }

            return cardNumbersList;
        }

        public List<String> producePinNumbers(List<String> CardNumbersList)
        {
            int numberOfCards = CardNumbersList.Count;

            List<String> pinNumbersList = new List<string>();
            Random randomGenerator = new Random();
            String pinNumber = null;

            for (int i = 0; i < numberOfCards; i++)
            {
                pinNumber = null;
                for (int j = 0; j < 8; j++)
                {
                    if ((j % 2) == 0)
                    {
                        String randomLetrer = generateRandomLetters(randomGenerator);
                        pinNumber = pinNumber + randomLetrer;
                    }
                    else
                    {
                        String randomNumber = generateRandomNumber(randomGenerator);
                        pinNumber = pinNumber + randomNumber;
                    }

                }
                pinNumbersList.Add(pinNumber);

            }
            return pinNumbersList;

        }

        public List<Card> GetCardsList()
        {
            List<Card> CardsList = new List<Card>();
            List<String> CardNumber = produceCardNumbers();
            List<String> PinNumber = producePinNumbers(CardNumber);

            for (int i = 0; i < numberOfCards; i++)
            {
                Card card = new Card(CardNumber[i], PinNumber[i]);
                CardsList.Add(card);
            }
            return CardsList;



        }

    }
}
