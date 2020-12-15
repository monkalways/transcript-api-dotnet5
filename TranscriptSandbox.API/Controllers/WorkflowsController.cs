using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranscriptSandbox.API.Workflows;
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
            return "0.0.123";
        }
    }
}
