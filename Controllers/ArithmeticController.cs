// This file contains source code modified by GitHub Copilot.

using CopilotProblem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CopilotProblem.Controllers
{
	[ApiController]
	[Route("")]
	public class ArithmeticController : ControllerBase
	{

		private readonly ILogger<ArithmeticController> _logger;

		public ArithmeticController(ILogger<ArithmeticController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public string Get()
		{
			return "Hello";
		}

		[HttpPost]
		public async Task<ActionResult<ApiResponse>> Post(ApiRequest request)
		{
			_logger.LogInformation("Request: " + JsonSerializer.Serialize(request));

			double result = 0;

			switch (request.Method)
			{
				case "add":
					result = request.Inputs.Sum();
					break;
				case "mode":
					var groups = request.Inputs.GroupBy(i => i).OrderByDescending(g => g.Count()).ToList();
					result = groups.Count > 1 && groups[0].Count() == groups[1].Count() ? 0 : groups[0].Key;
					break;
				case "mean":
					result = request.Inputs.Average();
					break;
				case "range":
					result = request.Inputs.Max() - request.Inputs.Min();
					break;
				case "stddev":
				    var mean = request.Inputs.Average();
					var squaredDifferences = request.Inputs.Select(i => Math.Pow(i - mean, 2));
					result = Math.Sqrt(squaredDifferences.Average());
					break;
				default:
					return BadRequest("Invalid method");
			}

			result = Math.Round(result, MidpointRounding.AwayFromZero);

			_logger.LogInformation("response: " + (int)result);


			return new ApiResponse
			{
				result = (int)result
			};
		}
	}
}