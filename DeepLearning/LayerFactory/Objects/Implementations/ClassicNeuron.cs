using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Objects.Interfaces;

namespace NeuralNetwork.Objects.Implementations
{
    public class ClassicNeuron : INeuron
    {
        public List<double> Weight { get; set; }
        public List<double> CachedInput { get; set; }
        public double Compute(double bias, IEnumerable<double> inputData)
        {
            CachedInput = inputData.ToList();
            double sum = 0.0;
            for(int index=0; index < inputData.Count(); ++index)
            {
                sum += inputData.ElementAt(index) * Weight[index];
            }
            return sum + bias;
        }
    }
}