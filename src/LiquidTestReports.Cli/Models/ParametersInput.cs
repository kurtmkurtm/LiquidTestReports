using DotLiquid;
using System;
using System.Collections.Generic;

namespace LiquidTestReports.Cli.Models
{
    /// <summary>
    /// Input parameters
    /// </summary>
    public class ParametersInput
    {
        /// <summary>
        /// Parameters for configuration and template usage.
        /// </summary>
        public IReadOnlyDictionary<string, string> Parameters { get; }

        /// <summary>
        /// Generates parameter inputs from string.
        /// </summary>
        /// <param name="inputString">parameter input containing string.</param>
        /// <exception cref="ArgumentNullException">error if string provided is empty.</exception>
        /// <exception cref="ArgumentException">error if sting does not follow convention.</exception>
        public ParametersInput(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                throw new ArgumentNullException(nameof(inputString));

            var splitInputs = inputString.Split(';');
            var parameters = new Dictionary<string, string>(Template.NamingConvention.StringComparer);
            foreach (var input in splitInputs)
            {
                var parameter = input.Split('=');
                if (parameter.Length == 2 && !string.IsNullOrEmpty(parameter[0]) && !string.IsNullOrEmpty(parameter[1]))
                {
                    parameters.Add(parameter[0], parameter[1]);
                }
                else
                {
                    throw new ArgumentException($"Incorrect number of arguments provided, Confirm parameter '{inputString}' uses the convention of 'key=value;'");
                }
            }
            Parameters = parameters;
        }
    }
}
