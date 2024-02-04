using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly Converter _converter;
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(ILogger<CurrencyController> logger)
        {
            _logger = logger;
            _converter = new Converter();
        }

        [HttpGet]
        [Route("api/v1/GetCurrencyInWords")]
        public string Get(string currency)
        {
            return _converter.GetNumIntoWords(currency);
        }
    }
}
