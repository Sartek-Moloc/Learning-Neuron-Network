using NeuralNetwork.Objects.Implementations;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Linq;
using NeuralNetworkInterfaces.Factories;
using NeuralNetworkInterfaces.Objects;

namespace NeuralNetwork.UT.Objects
{
    [TestFixture]
    class NetworkTests
    {
        [Test]
        public void NetworkComputeTest()
        {
            //given
            ILayer firstLayer = MockRepository.GenerateMock<ILayer>();
            List<List<double>> firstLayerResults = new List<List<double>>
            {
                new List<double> { 1.0, 2.0, 3.0, 4.0 },
                new List<double> { 1.0, 2.0, 3.0, 4.0 },
                new List<double> { 1.0, 2.0, 3.0, 4.0 },
                new List<double> { 1.0, 2.0, 3.0, 4.0 },
            };
            firstLayer.Stub(layer => layer.Compute(Arg<IEnumerable<IEnumerable<double>>>.Is.Anything, Arg<int>.Is.Anything)).Return(firstLayerResults);
            firstLayer.Stub(layer => layer.Neurons).Return(new List<INeuron>
            {
                MockRepository.GenerateMock<INeuron>(),
                MockRepository.GenerateMock<INeuron>(),
                MockRepository.GenerateMock<INeuron>(),
                MockRepository.GenerateMock<INeuron>()
            });
            List<double> secondLayerResults = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0 };
            ILayer secondLayer = MockRepository.GenerateMock<ILayer>();
            secondLayer.Stub(layer => layer.Compute(Arg<IEnumerable<IEnumerable<double>>>.Is.Anything)).Return(secondLayerResults);
            secondLayer.Stub(layer => layer.Neurons).Return(new List<INeuron>
            {
                MockRepository.GenerateMock<INeuron>(),
                MockRepository.GenerateMock<INeuron>(),
                MockRepository.GenerateMock<INeuron>(),
                MockRepository.GenerateMock<INeuron>(),
                MockRepository.GenerateMock<INeuron>(),
                MockRepository.GenerateMock<INeuron>(),
            });
            int expectedNeuronNumber = secondLayer.Neurons.Count();
            ILayerFactory layerFactory = MockRepository.GenerateMock<ILayerFactory>();
            layerFactory.Stub(lf => lf.ConstructLayer(
                Arg<double>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything, 
                Arg<string>.Is.Equal("First"))
                ).Return(firstLayer);
            layerFactory.Stub(lf => lf.ConstructLayer(
                Arg<double>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything,
                Arg<string>.Is.Equal("Second"))
                ).Return(secondLayer);
            List<List<double>> inputs = new List<List<double>> { new List<double> { 1.0, 2.0 }, new List<double> { 1.0, 2.0 } };
            List<LayerDescription> layersDescriptions = new List<LayerDescription>
            {
                new LayerDescription { Bias = 1.0, LayerFactory = layerFactory, Name = "First", NeuronNumber = 4},
                new LayerDescription { Bias = 1.0, LayerFactory = layerFactory, Name = "Second", NeuronNumber = 6 }
            };
            Network network = new Network(2, layersDescriptions);

            //when
            List<double> results = network.Compute(inputs).ToList();

            //then
            CollectionAssert.AreEqual(secondLayerResults, results);
            firstLayer.AssertWasCalled(layer=>layer.Compute(Arg<IEnumerable<IEnumerable<double>>>.Is.Equal(inputs), Arg<int>.Is.Equal(expectedNeuronNumber)));
            secondLayer.AssertWasCalled(layer => layer.Compute(Arg<IEnumerable<IEnumerable<double>>>.Is.Equal(firstLayerResults)));
        }

        [Test]
        public void NetworkConstructorTest()
        {
            //given
            ILayer firstLayer = MockRepository.GenerateMock<ILayer>();
            ILayer secondLayer = MockRepository.GenerateMock<ILayer>();
            ILayerFactory layerFactory = MockRepository.GenerateMock<ILayerFactory>();
            layerFactory.Stub(lf => lf.ConstructLayer(
                Arg<double>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything,
                Arg<string>.Is.Equal("First"))
                ).Return(firstLayer);
            layerFactory.Stub(lf => lf.ConstructLayer(
                Arg<double>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything,
                Arg<string>.Is.Equal("Second"))
                ).Return(secondLayer);
            List<LayerDescription> layersDescriptions = new List<LayerDescription>
            {
                new LayerDescription { Bias = 1.0, LayerFactory = layerFactory, Name = "First", NeuronNumber = 4},
                new LayerDescription { Bias = 1.0, LayerFactory = layerFactory, Name = "Second", NeuronNumber = 6 }
            };
            List<ILayer> expectedLayers = new List<ILayer> { firstLayer, secondLayer};

            //when
            Network network = new Network(2, layersDescriptions);

            //then
            CollectionAssert.AreEqual(expectedLayers, network.Layers);
            layerFactory.AssertWasCalled(lf => lf.ConstructLayer(Arg<double>.Is.Equal(1.0),Arg<int>.Is.Equal(2), Arg<int>.Is.Equal(4), Arg<string>.Is.Equal("First")));
            layerFactory.AssertWasCalled(lf => lf.ConstructLayer(Arg<double>.Is.Equal(1.0), Arg<int>.Is.Equal(4), Arg<int>.Is.Equal(6), Arg<string>.Is.Equal("Second")));
        }
    }
}
