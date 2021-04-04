using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroSungero.Kernel.API;

namespace MicroSungero.Planning.WebAPI.Controllers
{
  [Produces("application/json")]
  [ApiController]
  [Route("[controller]")]
  public class TodoController : ControllerBase
  {
    private readonly IQueryService queryService;

    private readonly ICommandService commandService;

    public TodoController(IQueryService queryService, ICommandService commandService)
    {
      this.queryService = queryService;
      this.commandService = commandService;
    }
  }
}
