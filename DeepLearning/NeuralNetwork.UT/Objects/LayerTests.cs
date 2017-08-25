using NeuralNetwork.Factories.Interfaces;
using NeuralNetwork.Objects.Implementations;
using NeuralNetwork.Objects.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork.UT.Objects
{
    [TestFixture]
    class LayerTests
    {
        INeuronFactory _factory = MockRepository.GenerateMock<INeuronFactory>();

        [Test]
        public void LayerComputeTest()
        {
            //given
            INeuron firstNeuron = MockRepository.GenerateMock<INeuron>();
            firstNeuron.Stub(neuron => neuron.Compute(Arg<double>.Is.Anything, Arg<IEnumerable<double>>.Is.Anything)).Return(1.0);
            INeuron secondNeuron = MockRepository.GenerateMock<INeuron>();
            secondNeuron.Stub(neuron => neuron.Compute(Arg<double>.Is.Anything, Arg<IEnumerable<double>>.Is.Anything)).Return(2.0);
            bool first = true;
            _factory.Stub(fac => fac.ConstructNeuron(Arg<int>.Is.Anything)).IgnoreArguments().Do(
                (Func<int,INeuron>)((a)=>
                {
                    if(first)
                    {
                        first = false;
                        return firstNeuron;
                    }
                    else
                    { return secondNeuron; }
                }
                ));
            double bias = 1.0;
            int previousLayerOutputCount = 2;
            int neuronNumber = 2;
            Layer layer = new Layer(bias,previousLayerOutputCount,neuronNumber, _factory);
            List<List<double>> inputData = new List<List<double>> { new List<double> { 2.0, 1.0 }, new List<double> { 1.0, 2.0 } };

            //when
            IEnumerable<double> result = layer.Compute(inputData);

            //then
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1.0, result.ElementAt(0));
            Assert.AreEqual(2.0, result.ElementAt(1));
        }
    }
}
