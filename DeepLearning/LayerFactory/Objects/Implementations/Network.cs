using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Factories.Interfaces;
using NeuralNetwork.Objects.Interfaces;

namespace NeuralNetwork.Objects.Implementations
{
    public class Network : INetwork
    {
        private readonly List<ILayer> _layers = new List<ILayer>();

        public IEnumerable<ILayer> Layers => _layers;
        public IEnumerable<double> Compute(IEnumerable<IEnumerable<double>> inputData, int layerIndex = 0)
        {
            if(layerIndex + 1 == _layers.Count)
            {
                return _layers[layerIndex].Compute(inputData);
            }
            return Compute(_layers[layerIndex].Compute(inputData, _layers[layerIndex].Neurons.Count()),layerIndex+1);
        }

        public Network(int inputCount ,IEnumerable<LayerDescription> layersDescription)
        {
            int previousLayerOutputCount = inputCount;
            foreach (LayerDescription layerDescription in layersDescription)
            {
                _layers.Add(layerDescription.LayerFactory.ConstructLayer(layerDescription.Bias, previousLayerOutputCount, layerDescription.NeuronNumber, layerDescription.Name));
                previousLayerOutputCount = layerDescription.NeuronNumber;
            }
        }
    }
}
