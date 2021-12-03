using System;
using System.Collections.Generic;
using Tagster.DataAccess.Models;
using Tagster.Domain.Entities;

namespace Tagster.Application.Factories;

public class TagFactory
{
    public static ICollection<Tag> Create(int maxTagsPerProfile, FakeData fakeData)
    {
        Random rand = new();
        List<Tag> tags = new();

        for (int j = 0; j < rand.Next(maxTagsPerProfile); j++)
        {
            tags.Add(new()
            {
                Name = fakeData.Tags[rand.Next(fakeData.Tags.Length)]
            });
        }

        return tags;
    }
}
