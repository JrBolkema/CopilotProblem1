// This file contains source code modified by GitHub Copilot.

namespace CopilotProblem.Models
{
	public class ApiRequest
	{
		// here is the json {"method": "add", "inputs":[1,2,3]}
		public string Method { get; set; }
		public int[] Inputs { get; set; }
	}
}
