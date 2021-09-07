﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagster.DataAccess.Models;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.Factories
{
    public class TagFactory
    {
        public static ICollection<Tag> Create(int maxTagsPerProfile, FakeData fakeData)
        {
            Random rand = new();
            var tags = new List<Tag>();

            for (int j = 0; j < rand.Next(maxTagsPerProfile); j++)
            {
                string tagName = fakeData.Tags[rand.Next(fakeData.Tags.Length)];
                Tag tag = new Tag();
                tag.TagName = tagName;
                tags.Add(tag);
            }
            return tags;
        }
    }
}