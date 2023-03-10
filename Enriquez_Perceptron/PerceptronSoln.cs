using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enriquez_Perceptron
{
    internal class PerceptronSoln
    {
        private double[] weights;
        private double learningRate;
        private double bias;
        
        /// <summary>
        /// Solves the perceptron algorithm
        /// </summary>
        /// <param name="inputsNum">how many inputs the user wants</param>
        /// <param name="learningRate">value between -1 and 1</param>
        public PerceptronSoln(int inputsNum, double learningRate = 0.1)
        {
            weights = new double[inputsNum];
            var rnd = new Random();
            for (int i = 0; i < inputsNum; i++)
            {
                weights[i] = rnd.NextDouble() * 2 - 1;
            }
            bias = 0;
            this.learningRate = learningRate;
        }

        /// <summary>
        /// Predicts the output of the given inputs
        /// </summary>
        /// <param name="inputs">inputs given by the user</param>
        /// <returns>prediction of the output</returns>
        public int Prediction(double[] inputs)
        {
            double weightSum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                weightSum += weights[i] * inputs[i];
            }
            weightSum += bias;
            return weightSum >= -1 ? 1 : -1;
        }

        /// <summary>
        /// Trains the perceptron for a single epoch.
        /// </summary>
        /// <param name="inputs">input from the user</param>
        /// <param name="targets">the target output of the perceptron</param>
        /// <param name="epochsNum">how many epochs the model is trained</param>
        public void Training(double[][] inputs, int[] targets, int epochsNum)
        {
            for (int epoch = 0; epoch < epochsNum; epoch++)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    double prediction = Prediction(inputs[i]);
                    double error = targets[i] - prediction;
                    for (int j = 0; j < weights.Length; j++)
                    {
                        weights[j] += learningRate * error * inputs[i][j];
                    }
                    bias += learningRate * error;
                }
            }
        }
    }
}
