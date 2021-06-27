using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tagster.Application.Interfaces;

namespace TagsterWebAPI.Controllers
{
    [ApiController]
    [Route("Tagster")]
    public class TagsterController : ControllerBase
    {
        private readonly ITagsterDbContext _tagsterDb;

        public TagsterController(ITagsterDbContext tagsterDb)
        {
            _tagsterDb = tagsterDb;
        }

        [HttpGet]
        public string StartMessage()
        {
            var mess = "Welcome!";
            return mess;
        }

        [Route("tags/{name}")]
        public Array TagsOnProfile(string name)
        {
            var tagsList = _tagsterDb
                .Profiles
                .Where(profile => profile.Name.Equals(name))
                .Include(profile => profile.ProfileTags)
                .Select(profile => profile.ProfileTags)
                .ToArray();

            return tagsList;
        }
    }
}