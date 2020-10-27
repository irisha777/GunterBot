using System.Collections.Generic;
using GunterBot.MongoDb;
using GunterBot.MongoDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GunterBot.Controllers
{
    [Route("db")]
    [ApiController]
    public class MongoDbController : ControllerBase
    {
        private readonly RateDBServices _rateDBServices;

        public MongoDbController(RateDBServices rateDBServicesService)
        {
            _rateDBServices = rateDBServicesService;
        }

        [HttpGet]
        public ActionResult<List<RateDB>> Get() =>
            _rateDBServices.Get();

        [HttpGet("{id:length(24)}", Name = "GetRateDB")]
        public ActionResult<RateDB> Get(string id)
        {
            var rateDB = _rateDBServices.Get(id);

            if (rateDB == null)
            {
                return NotFound();
            }

            return rateDB;
        }

        [HttpPost]
        public ActionResult<RateDB> Create(RateDB rateDB)
        {
            _rateDBServices.Create(rateDB);

            return CreatedAtRoute("GetRateDB", new { id = rateDB.Id.ToString() }, rateDB);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, RateDB rateDBIn)
        {
            var rateDB = _rateDBServices.Get(id);

            if (rateDB == null)
            {
                return NotFound();
            }

            _rateDBServices.Update(id, rateDBIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var rateDB = _rateDBServices.Get(id);

            if (rateDB == null)
            {
                return NotFound();
            }

            _rateDBServices.Remove(rateDB.Id);

            return NoContent();
        }
    }
}
