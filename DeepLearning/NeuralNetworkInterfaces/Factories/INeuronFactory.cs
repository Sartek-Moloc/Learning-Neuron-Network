using NeuralNetworkInterfaces.Objects;

namespace NeuralNetworkInterfaces.Factories
{
    public interface INeuronFactory
    {
        INeuron ConstructNeuron(int previousLayerOutputCount);
    }
}