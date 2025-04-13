
namespace DmProject
{
    public class Algorithm
    {
        public int[,] GetReachabilityMatrix(int[,] adjacencyMatrix)
        {
            int n = adjacencyMatrix.GetLength(0);
            int[,] reachabilityMatrix = new int[n, n];

            for (int i = 0; i < n; i++)
                reachabilityMatrix[i, i] = 1;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    reachabilityMatrix[i, j] = adjacencyMatrix[i, j];

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (reachabilityMatrix[i, k] == 1 && reachabilityMatrix[k, j] == 1)
                            reachabilityMatrix[i, j] = 1;
                    }
                }
            }

            return reachabilityMatrix;
        }
    }
}
