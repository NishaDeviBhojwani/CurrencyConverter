namespace CurrencyConverter
{
    public class Converter
    {
        public string GetDigitsIntoNumbers(string currency)
        {
            string currencyName = "dollars";
            if (currency == "0")
                return $"Zero {currencyName}";

            string[] numbers = currency.Split(',');
            if (numbers.Length != 2)
                return "Invalid String";

            if (numbers[1].Length > 2)
                return "Invalid String";

            //char[] cents = numbers[1].ToCharArray();
            int cents = int.Parse(numbers[1]);
            string centNumber = "";
            if (cents > 0)
            {
                int temp = cents / 10;
                if (temp > 0)
                {
                    centNumber = GetTens(temp*10);
                }

                temp = cents % 10;
                if (temp > 0)
                {
                    centNumber += $" {GetOnes(temp)}";
                }
            }

            if (centNumber.Length > 0)
            {
                return $"{centNumber} cents";
            }
            return $"Zero {currencyName}";
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
