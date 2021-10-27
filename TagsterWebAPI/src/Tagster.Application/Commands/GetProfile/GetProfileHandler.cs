using MediatR;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.CQRS.Commands.Handlers;
using Microsoft.AspNetCore.Http;

namespace Tagster.Application.Commands.GetProfile
{
    internal sealed class GetProfileHandler : ICommandHandler<GetProfile>
    {
        private readonly ITagsService _tagService;
        public GetProfileHandler(ITagsService tagService)
        {
            _tagService = tagService;
        }
        public async Task<Unit> Handle(GetProfile request, CancellationToken cancellationToken)
        {
            //gets href from website somehow
            //string href = 

            await _tagService.GetHref(request.Href);
            return Unit.Value;
        }
    }
}
