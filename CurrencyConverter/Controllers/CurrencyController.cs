using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CurrencyConverter.Controllers
{
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private static readonly string[] lengthInToMod = new[]
        {
            "", "", "hundred", "thousand", "ten thousand", "hundred thousand", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(ILogger<CurrencyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/v1/GetCurrencyInWords")]
        public string Get(string currency)
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
            if(cents > 0)
            {
                int temp = cents / 10;
                if(temp > 0)
                {
                    centNumber = GetTens(temp);
                }

                temp = cents % 10;
                if( temp > 0)
                {
                    centNumber = " ${GetTens(temp)";
                }
            }

            if(centNumber.Length > 0)
            {
                return $"{centNumber} {currencyName}";
            }
            return $"Zero {currencyName}";
        }

        public string GetOnes(string number)
        {
            return number switch
            {
                "0" => "Zero",
                "1" => "one",
                "2" => "two",
                "3" => "three",
                "4" => "four",
                "5" => "five",
                "6" => "six",
                "7" => "seven",
                "8" => "eight",
                "9" => "nine",
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
