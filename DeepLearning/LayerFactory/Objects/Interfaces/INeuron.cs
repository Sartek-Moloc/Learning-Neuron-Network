using System.Collections.Generic;

namespace NeuralNetwork.Objects.Interfaces
{
    public interface INeuron
    {
        //TODO: rework needed
        List<double> Weight { get; set; }

        double Compute(double bias,IEnumerable<double> inputData);
    }
}