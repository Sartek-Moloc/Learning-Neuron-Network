using NeuralNetworkInterfaces.Objects;

namespace NeuralNetworkInterfaces.Factories
{
    public interface ILayerFactory
    {
        ILayer ConstructLayer(double layerBias,int inputCount,int neuronNumber, string name ="");
    }
}