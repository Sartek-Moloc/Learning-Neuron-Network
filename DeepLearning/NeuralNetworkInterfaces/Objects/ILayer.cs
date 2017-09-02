using System.Collections.Generic;

namespace NeuralNetworkInterfaces.Objects
{
    public interface ILayer
    {
        string Name { get; }
        IEnumerable<INeuron> Neurons { get; }
        double Bias { get; }
        IEnumerable<double> Compute(IEnumerable<IEnumerable<double>> inputData);
        IEnumerable<IEnumerable<double>> Compute(IEnumerable<IEnumerable<double>> inputData, int numberOfNeuronsInNextLayer);
    }
}