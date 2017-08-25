using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningAlgorithm
{
    public class Backpropagation
    {
        IEnumerable<double> ErrorCalculation(int numberOfIteration, IEnumerable<double> neuralNetworkOutput,
            IEnumerable<double> expectedOutput)
        {
            List<double> computedErrors = new List<double>();
            for (int valueIndex = 0; valueIndex < neuralNetworkOutput.Count(); valueIndex++)
            {
                computedErrors.Add(Math.Sqrt(expectedOutput.ElementAt(valueIndex)-neuralNetworkOutput.ElementAt(valueIndex))* (0.5 / numberOfIteration));
            }
            return computedErrors;
        }
    }
}
