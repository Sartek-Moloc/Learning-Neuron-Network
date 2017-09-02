using System;
using NeuralNetwork.Objects.Implementations;
using System.Collections.Generic;
using NeuralNetworkInterfaces.Factories;
using NeuralNetworkInterfaces.Objects;

namespace NeuralNetwork.Factories.Implementations
{
    class SimpleNeuronFactory : INeuronFactory
    {
        public INeuron ConstructNeuron(int previousLayerOutputCount)
        {
            List<double> weights = InitWeigths(previousLayerOutputCount);
            return new ClassicNeuron { Weight = weights };
        }

        private List<double> InitWeigths(int weightsCount)
        {
            List<double> weights = new List<double>();
            Random random = new Random();

            for (int weightIndex = 0; weightIndex < weightsCount; ++weightIndex)
            {
                weights.Add(random.NextDouble());
            }
            return weights;
        }
    }
}
