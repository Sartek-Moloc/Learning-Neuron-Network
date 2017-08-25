using NeuralNetwork.Objects.Interfaces;

namespace NeuralNetwork.Factories.Interfaces
{
    public interface INeuronFactory
    {
        INeuron ConstructNeuron(int previousLayerOutputCount);
    }
}