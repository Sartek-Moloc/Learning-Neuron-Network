using NeuralNetwork.Objects.Interfaces;

namespace NeuralNetwork.Factories.Interfaces
{
    public interface ILayerFactory
    {
        ILayer ConstructLayer(double layerBias,int inputCount,int neuronNumber, string name ="");
    }
}