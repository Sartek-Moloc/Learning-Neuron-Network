using NeuralNetwork.Factories.Interfaces;

namespace NeuralNetwork.Objects.Implementations
{
    public class LayerDescription
    {
        public string Name { get; set; }
        public int NeuronNumber { get; set; }
        public ILayerFactory LayerFactory{ get;set; }
        public double Bias { get; set; }
    }
}