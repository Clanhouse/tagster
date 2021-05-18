using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tagster.Database;

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

        private readonly IServiceProvider _mServiceProvider;
        private readonly ILogger<TagsterController> _logger;

        public TagsterController(ILogger<TagsterController> logger, IServiceProvider serviceProvider)
        {
            _mServiceProvider = serviceProvider;
            _logger = logger;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<Tagster> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Tagster
                {
                    Terms = Tags[rng.Next(Tags.Length)]

                })
                .ToArray();
        }

        public string StartMessage()
        {
            var mess = "type /get to display or /tags to display tags";
            return mess;
        }

        [Route("tags")]
        public Array Tagsik()
        {
            var database = _mServiceProvider.GetService(typeof(TagsterDbContext)) as TagsterDbContext;
            var tagsList = database
                .Profiles
                .Include(a => a.Tags)
                .Select(a => new {a.Tags, a.Name})
                .ToArray();

            

            return tagsList;


        }
    }
}
