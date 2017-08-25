using System.Collections.Generic;

namespace NeuralNetwork.Objects.Interfaces
{
    public interface INetwork
    {
        IEnumerable<ILayer> Layers { get; }
        IEnumerable<double> Compute(IEnumerable<IEnumerable<double>> inputData, int layerIndex = 0);
    }
}