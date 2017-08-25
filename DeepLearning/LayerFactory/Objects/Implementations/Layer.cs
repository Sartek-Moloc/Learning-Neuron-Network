using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Factories.Interfaces;
using NeuralNetwork.Objects.Interfaces;

namespace NeuralNetwork.Objects.Implementations
{
    public class Layer : ILayer
    {
        private readonly List<INeuron> _neurons = new List<INeuron>();
        public double Bias { get; private set; }
        public string Name { get; }
        public IEnumerable<INeuron> Neurons => _neurons;
        public IEnumerable<double> Compute(IEnumerable<IEnumerable<double>> inputData)
        {
            List<double> results = new List<double>();
            for (int neuronIndex = 0; neuronIndex < _neurons.Count; ++neuronIndex)
            {
                results.Add(_neurons[neuronIndex].Compute(Bias,inputData.ElementAt(neuronIndex)));
            }
            return results;
        }
        public IEnumerable<IEnumerable<double>> Compute(IEnumerable<IEnumerable<double>> inputData, int numberOfNeuronsInNextLayer)
        {
            List<IEnumerable<double>> result = new List<IEnumerable<double>>();
            IEnumerable<double> computingResult = Compute(inputData);
            for (int copyIndex = 0; copyIndex < numberOfNeuronsInNextLayer; ++copyIndex)
            {
                result.Add(computingResult);
            }
            return result;
        }

        public Layer(double layerBias,int previousLayerOutputCount,int neuronNumber, INeuronFactory factory,string name ="")
        {
            Bias = layerBias;
            Name = name;
            for(int neuronIndex = 0; neuronIndex < neuronNumber; ++neuronIndex)
            {
                _neurons.Add(factory.ConstructNeuron(previousLayerOutputCount));
            }
        }
    }
}