using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConvexHell
{
    class DatasetFactory
    {
        uint datasetSize = 10;
        uint lowerBoundX = 50;
        uint higherBoundX = 800;
        uint lowerBoundY = 50;
        uint higherBoundY = 800;

        Random random = new Random();

        public DatasetFactory(uint datasetSize, uint lowerBoundX, uint higherBoundX, uint lowerBoundY, uint higherBoundY)
        {
            this.datasetSize = datasetSize;
            this.lowerBoundX = lowerBoundX;
            this.higherBoundX = higherBoundX;
            this.lowerBoundY = lowerBoundY;
            this.higherBoundY = higherBoundY;
        }


       

        public Vector[] GenerateDataset()
        {
            Vector[] vectors = new Vector[datasetSize];
            for (int i = 0; i < datasetSize; i++)
            {
                vectors[i] = new Vector(random.Next((int)lowerBoundX, (int)higherBoundX), random.Next((int)lowerBoundY, (int)higherBoundY));
            }


            return vectors;
        }
        public int[] GenerateOrder()
        {
            int[] order = new int[datasetSize];
            for (int i = 0; i < datasetSize; i++)
            {
                order[i] = i;
            }
            return order;
        }
    }
}
