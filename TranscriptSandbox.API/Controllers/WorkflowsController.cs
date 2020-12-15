using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace TranscriptSandbox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowsController : ControllerBase
    {
        public WorkflowsController(IWorkflowController workflowService)
        {
            WorkflowService = workflowService;
        }

        public IWorkflowController WorkflowService { get; }

        [HttpGet]
        public async Task<string> Get()
        {
            var workflowId = await WorkflowService.StartWorkflow("TestWorkflow");
            return $"TestWorkflow ({workflowId}) started";
        }

        [HttpGet("/api/version")]
        public string GetVersion()
        {
            return "0.0.1";
        }
    }
}
