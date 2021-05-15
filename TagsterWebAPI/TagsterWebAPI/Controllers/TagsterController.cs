using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagsterWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsterController : ControllerBase
    {
        private static readonly string[] Tags = new[]
        {
            "pOLAK", "Donkey", "Nice guy"
        };

        private readonly ILogger<TagsterController> _logger;

        public TagsterController(ILogger<TagsterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Tagster> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Tagster
            {
                Terms = Tags[rng.Next(Tags.Length)]
                
                
            })
            .ToArray();
        }
    }
}
