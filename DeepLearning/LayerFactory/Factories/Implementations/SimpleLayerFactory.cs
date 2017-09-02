using NeuralNetwork.Objects.Implementations;
using NeuralNetworkInterfaces.Factories;
using NeuralNetworkInterfaces.Objects;

namespace NeuralNetwork.Factories.Implementations
{
    public class SimpleLayerFactory : ILayerFactory
    {
        public ILayer ConstructLayer(double layerBias, int inputCount,int neuronNumber, string name = "")
        {
            return new Layer(layerBias,inputCount,neuronNumber, new SimpleNeuronFactory(),name);
        }
    }
}
