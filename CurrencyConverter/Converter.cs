using System;

namespace CurrencyConverter
{
    public class Converter
    {
        private static readonly string[] numberInWords = new[]
        {
            "hundred", "thousand", "million"
        };

        private static List<string> result;

        public Converter() { 
            result = new List<string>();
        }

        public string GetNumIntoWords(string inNumbers)
        {
            string[] wholeAndDecimalPart = inNumbers.Split(',');

            // If string is not in right format
            if (wholeAndDecimalPart.Length == 0)
                return "Invalid String";

            // Dollars Logic
            if (wholeAndDecimalPart.Length <= 2)
            {
                if (wholeAndDecimalPart[0] is null)
                    return "Invalid String";

                string[] wholePart = wholeAndDecimalPart[0].Split(' ');
                if (wholePart is null)
                    return "Invalid String";

                AddIfNotEmpty(result, DollarsLogic(wholePart));
                if (result.Count != 0)
                    AddIfNotEmpty(result, "dollars");
            }

            // Dollars and Cents
            if (result.Count > 1 && wholeAndDecimalPart.Length>1)
            {
                AddIfNotEmpty(result, "and");
            }

            // Cents Logic
            if (wholeAndDecimalPart.Length == 2 && wholeAndDecimalPart[1] is not null)
            {
                CentsLogic(wholeAndDecimalPart[1]);
                AddIfNotEmpty(result, "cents");
            }

            return String.Join(" ", result.ToArray());
        }

        private static string DollarsLogic(string[] wholePart)
        {
            string words = "";
            for (int i = 0; i < wholePart.Length; i++)
            {
                int part = int.Parse(wholePart[i]);
                if (part <= 0)
                    continue;

                int lengthOfWholenumber = wholePart[i].Length;
                if (lengthOfWholenumber <= 2)
                {
                    TwoDigitLogic(part);
                    if (i != wholePart.Length - 1)
                        AddIfNotEmpty(result, numberInWords[wholePart.Length - i - 1]);
                    continue;
                }
                int temp = (int)Math.Pow(10.0, lengthOfWholenumber - 1);

                int firstdigit = part / temp;
                if (firstdigit != 0)
                {
                    AddIfNotEmpty(result, GetOnes(firstdigit));
                    if(lengthOfWholenumber == 3)
                        AddIfNotEmpty(result, "hundred");
                }
                int remainingDigit = part % temp;
                if (remainingDigit.ToString().Length == 2)
                {
                    var val = GetTens(remainingDigit);
                    if (val != string.Empty)
                    {
                        AddIfNotEmpty(result, val);
                        continue;
                    }
                }
                AddIfNotEmpty(result, GetTens((remainingDigit / 10) * 10));
                AddIfNotEmpty(result, GetOnes(remainingDigit % 10));

                if (i != wholePart.Length - 1)
                    AddIfNotEmpty(result, numberInWords[wholePart.Length - i - 1]);
            }

            return words;
        }

        private static void AddIfNotEmpty(List<string> result, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                result.Add(value);
            }
        }

        private static void CentsLogic(string centNumbers)
        {
            if (centNumbers.Length == 1)
            {
                centNumbers += "0";
            }

            int cents = int.Parse(centNumbers);
            if (cents > 0)
            {
                TwoDigitLogic(cents);
            }
        }

        private static void TwoDigitLogic(int num)
        {
            var val = GetTens(num);
            if (val != string.Empty)
            {
                AddIfNotEmpty(result, val);
            }
            else
            {
                int digits = num / 10;
                if (digits > 0)
                {
                    AddIfNotEmpty(result, GetTens(digits * 10));
                }

                digits = num % 10;
                if (digits > 0)
                {
                    AddIfNotEmpty(result, GetOnes(digits));
                }
            }
        }

        private static string GetOnes(int number)
        {
            return number switch
            {
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

        private static string GetTens(int number)
        {
            return number switch
            {
                10 => "ten",
                11 => "eleven",
                12 => "twelve",
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
