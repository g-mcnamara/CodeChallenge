using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CodeChallenge
{
    /// <summary>
    /// This class contains the solution for the first stage on the Advent of Code in https://adventofcode.com/2015/day/1
    /// </summary>
    public static class Function1
    {
        /// <summary>
        /// This is the first Assure funciton for the CodeChallenge project
        /// </summary>
        /// <remarks>
        /// This function needs the "puzzle" GET parameter
        /// </remarks>
        /// <example>
        /// http://localhost/api/Function1?puzzle=((((()(()()(())(()))))))))()()()()())()))))))))))))()()()((((())))()()()()))))(((
        /// </example>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns>
        /// The function will return the same puzzle string with the current 
        /// Santa's floor location and the number of the first basement floor
        /// </returns>
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string puzzle = req.Query["puzzle"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            puzzle = puzzle ?? data?.name;


            string responseMessage = "";

            if (string.IsNullOrEmpty(puzzle))
            {
                responseMessage = "This HTTP triggered function executed successfully. Pass a puzzle";
            }
            else
            {
                int intSantasFloor = E1_FindFloor(puzzle);
                int firstBasement = E2_FirstBasement(puzzle);

                responseMessage = $"Hello, Santa is on floor {intSantasFloor.ToString()}. The first basement is {firstBasement.ToString()}";
            }

            responseMessage += "\r\rPuzzle:\r\r" + puzzle;



            return new OkObjectResult(responseMessage);
        }

        /// <summary>
        /// Private function to find the current Santa's location
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns>Floor number</returns>
        public static int E1_FindFloor(String puzzle)
        {
            char[] chPuzzle = puzzle.ToCharArray();

            char[] ups = Array.FindAll(chPuzzle, x => x.Equals('('));
            char[] dws = Array.FindAll(chPuzzle, x => x.Equals(')'));

            return ups.Length - dws.Length;
        }

        /// <summary>
        /// Private function to find the first basement floor
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns>Floor number</returns>
        public static int E2_FirstBasement(String puzzle)
        {
            char[] chPuzzle = puzzle.ToCharArray();
            int floorPos = 0;
            int basement = 0;

            for (int i = 0; i < chPuzzle.Length; i++)
            {
                if (chPuzzle[i].Equals(')'))
                {
                    floorPos--;
                }
                else if(chPuzzle[i].Equals('('))
                {
                    floorPos++;
                }

                if (floorPos < 0)
                {
                    basement = i + 1;
                    break;
                }
            }

            return basement;
        }
    }
}
