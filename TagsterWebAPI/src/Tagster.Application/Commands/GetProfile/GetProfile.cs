using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagster.CQRS.Commands;

namespace Tagster.Application.Commands.GetProfile
{
    public class GetProfile :ICommand
    {
        public string Href { get; set; }
    }
}
