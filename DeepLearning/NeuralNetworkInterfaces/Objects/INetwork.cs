using System.Collections.Generic;

namespace NeuralNetworkInterfaces.Objects
{
    public interface INetwork
    {
        IEnumerable<ILayer> Layers { get; }
        IEnumerable<double> Compute(IEnumerable<IEnumerable<double>> inputData, int layerIndex = 0);
    }
}