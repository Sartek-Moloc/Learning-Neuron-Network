using NeuralNetwork.Objects.Implementations;
using NUnit.Framework;
using System.Collections.Generic;

namespace NeuralNetwork.UT.Objects
{
    [TestFixture]
    public class ClassicNeuronTests
    {
        [Test]
        public void ClassicNeuronComputeTest()
        {
            //given
            List<double> weigts = new List<double> { 1.0, 1.0 };
            ClassicNeuron neuron = new ClassicNeuron() {Weight = weigts };
            List<double> input = new List<double> { 1.0, 1.0 };
            double bias = 1;

            //when
            double result = neuron.Compute(bias,input);

            //then
            Assert.AreEqual(3.0, result);

        }
    }
}
