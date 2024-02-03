using System;
using System.Formats.Asn1;

namespace CurrencyConverter
{
    public class Converter
    {
        private static readonly string[] lengthInToMod = new[]
        {
            "hundred", "thousand", "million"
        };
        public string GetDigitsIntoNumbers(string inNumbers)
        {
            string[] wholeAndDecimalPart = inNumbers.Split(',');
            string result = "";
            string[] wholePart = wholeAndDecimalPart[0].Split(' ');

            // Whole Part Logic
            for (int i = 0; i < wholePart.Length; i++)
            {
                int part = int.Parse(wholePart[i]);
                int lengthOfWholenumber = wholePart[i].Length;

                // 139 -> Length = 3

                string words = (lengthOfWholenumber == 3) ? "hunderd" : "";

                int temp = (int)Math.Pow(10.0, lengthOfWholenumber - 1);

                int firstdigit = part / temp;
                if (firstdigit != 0)
                    result += $"{GetOnes(firstdigit)} {words} ";

                int remainingDigit = part % temp;
                result += $" {GetTens((remainingDigit / 10) * 10)}";
                result += $" {GetOnes(remainingDigit % 10)} ";

                if(i  != wholePart.Length - 1)
                    result +=  lengthInToMod[wholePart.Length - i - 1];
            }

            result += " dollars ";
            result = CentsLogic(wholeAndDecimalPart, result);
            return result;
        }

        private string CentsLogic(string[] numbers, string num)
        {
            //char[] cents = numbers[1].ToCharArray();
            int cents = int.Parse(numbers[1]);
            string centNumber = "";
            if (cents > 0)
            {
                bool isOneDigit = false;
                int temp = cents / 10;
                if (temp == 0)
                {
                    temp = cents;
                    isOneDigit = true;
                }
                if (temp > 0)
                {
                    centNumber = GetTens(temp * 10);
                }

                temp = cents % 10;
                if (temp > 0 && !isOneDigit)
                {
                    centNumber += $" {GetOnes(temp)}";
                }
            }

            if (centNumber.Length > 0)
            {
                num += $"{centNumber} cents";
            }

            return num;
        }

        public string GetOnes(int number)
        {
            return number switch
            {
                0 => "Zero",
                1 => "one",
                2 => "two",
                3 => "three",
                4 => "four",
                5 => "five",
                6 => "six",
                7 => "seven",
                8 => "eight",
                9 => "nine",
                _ => "",
            };
        }

        public string GetTens(int number)
        {
            return number switch
            {
                10 => "ten",
                11 => "eleven",
                12 => "twevle",
                13 => "thirteen",
                14 => "forteen",
                15 => "fifteen",
                16 => "sixteen",
                17 => "seventeen",
                18 => "eigthteen",
                19 => "ninteen",
                20 => "twenty",
                30 => "thirty",
                40 => "forty",
                50 => "fifty",
                60 => "sixty",
                70 => "seventy",
                80 => "eighty",
                90 => "ninty",
                _ => "",
            };
        }
    }
}
