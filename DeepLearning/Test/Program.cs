using System;
using System.Collections.Generic;
using NeuralNetwork.Factories.Implementations;
using NeuralNetwork.Objects.Implementations;

namespace Test
{
    class Program
    {
        static void Main()
        {
            LayerDescription desciption = new LayerDescription() { Bias = 0.0, LayerFactory = new SimpleLayerFactory(), Name = "Single", NeuronNumber = 5};
            Network neuralNetwork = new Network(5,new List<LayerDescription> { desciption });
            IEnumerable<IEnumerable<double>> inputData = new List<IEnumerable<double>>
            {
                new List<double> {0,1,2,3,4},
                new List<double> {0,1,2,3,4},
                new List<double> {0,1,2,3,4},
                new List<double> {0,1,2,3,4},
                new List<double> {0,1,2,3,4}
            }; 
            IEnumerable<double> result = neuralNetwork.Compute(inputData);
            Console.WriteLine(string.Join(" , ", result));
            Console.ReadKey();
        }
    }
}
