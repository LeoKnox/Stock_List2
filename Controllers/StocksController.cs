using Microsoft.AspNetCore.Mvc;
using Stocks.Data;

namespace Stocks.Controllers
{
    [Route("api/[controller]")]
    public class StocksController: Controller
    {
        private IStockService _service;
        public StocksController(IStockService service)
        {
            this._service = service;
        }

        [HttpGet("GetStocks")]
        public IActionResult GetStocks()
        {
            var allStocks = _service.GetAllStocks();
            return Ok(allStocks);
        }

        [HttpPost("action")]
        public IActionResult AddStock([FromBody]Stock stock)
        {
            if(stock != null)
            {
                _service.AddStock(stock);
            }
            return Ok();
        }

        [HttpPut("UpdateStock/{id}")]
        public IActionResult UpdateStock(int id, [FromBody]Stock stock)
        {
            _service.UpdateStock(id,stock);
            return Ok(stock);
        }
    }
}