namespace CurrencyConverter
{
    public class Converter
    {
        private static readonly string[] numberInWords = new[]
        {
            "hundred ", "thousand ", "million "
        };
        public string GetNumIntoWords(string inNumbers)
        {
            string words = "";
            string[] wholeAndDecimalPart = inNumbers.Split(',');
            string[] wholePart = wholeAndDecimalPart[0].Split(' ');

            for (int i = 0; i < wholePart.Length; i++)
            {
                int part = int.Parse(wholePart[i]);
                if (part <= 0)
                    continue;

                int lengthOfWholenumber = wholePart[i].Length;
                int temp = (int)Math.Pow(10.0, lengthOfWholenumber - 1);

                int firstdigit = part / temp;
                if (firstdigit != 0)
                    words += $"{GetOnes(firstdigit)}{((lengthOfWholenumber == 3) ? " hunderd " : "")} ";

                int remainingDigit = part % temp;
                words += $"{GetTens((remainingDigit / 10) * 10)} ";
                words += $"{GetOnes(remainingDigit % 10)} ";

                if (i != wholePart.Length - 1)
                    words += numberInWords[wholePart.Length - i - 1];
            }

            words += "dollars ";
            if (wholeAndDecimalPart[1].Length > 0)
            {
                words += $" and {CentsLogic(wholeAndDecimalPart[1])}";
            }

            return words;
        }

        private string CentsLogic(string centNumbers)
        {
            if (centNumbers.Length == 1)
            {
                centNumbers += "0";
            }

            int cents = int.Parse(centNumbers);
            string centWords = "";
            if (cents > 0)
            {
                int digits = cents / 10;
                if (digits > 0)
                {
                    centWords = GetTens(digits * 10);
                }

                digits = cents % 10;
                if (digits > 0)
                {
                    centWords += $"{GetOnes(digits)} ";
                }
            }

            if (centWords.Length > 0)
            {
                centWords += $" cents";
            }

            return centWords;
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
