using System;
using System.Collections.Generic;

public class Graph
{
    private List<string> vertices;
    private int[,] adjacencyMatrix;

    public Graph()
    {
        vertices = new List<string>();
        adjacencyMatrix = new int[0, 0];
    }

    public void AddVertex(string name)
    {
        if (vertices.Contains(name))
        {
            Console.WriteLine("Вершина вже існує.");
            return;
        }

        vertices.Add(name);
        int newSize = vertices.Count;
        var newMatrix = new int[newSize, newSize];

        for (int i = 0; i < newSize - 1; i++)
        {
            for (int j = 0; j < newSize - 1; j++)
            {
                newMatrix[i, j] = adjacencyMatrix[i, j];
            }
        }

        adjacencyMatrix = newMatrix;
    }

    public void AddEdge(string from, string to, int weight = 1)
    {
        int i = vertices.IndexOf(from);
        int j = vertices.IndexOf(to);

        if (i == -1 || j == -1)
        {
            Console.WriteLine("Одна з вершин не знайдена.");
            return;
        }

        adjacencyMatrix[i, j] = weight;
    }

    public void RemoveEdge(string from, string to)
    {
        int i = vertices.IndexOf(from);
        int j = vertices.IndexOf(to);

        if (i == -1 || j == -1)
        {
            Console.WriteLine("Одна з вершин не знайдена.");
            return;
        }

        adjacencyMatrix[i, j] = 0;
    }

    public void PrintMatrix()
    {
        Console.Write("\t");
        foreach (var v in vertices)
        {
            Console.Write(v + "\t");
        }
        Console.WriteLine();

        for (int i = 0; i < vertices.Count; i++)
        {
            Console.Write(vertices[i] + "\t");
            for (int j = 0; j < vertices.Count; j++)
            {
                Console.Write(adjacencyMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public void Clear()
    {
        vertices.Clear();
        adjacencyMatrix = new int[0, 0];
    }

    public void GenerateRandomGraph(int vertexCount, double density)
    {
        if (density < 0 || density > 1)
        {
            Console.WriteLine("Щільність має бути в межах від 0 до 1.");
            return;
        }

        for (int i = 0; i < vertexCount; i++)
        {
            AddVertex("V" + i);
        }

        int maxEdges = vertexCount * (vertexCount - 1) / 2;
        int targetEdgeCount = (int)(density * maxEdges);
        int edgeCount = 0;

        Random rand = new Random();
        HashSet<(int, int)> addedEdges = new HashSet<(int, int)>();

        while (edgeCount < targetEdgeCount)
        {
            int i = rand.Next(vertexCount);
            int j = rand.Next(vertexCount);

            if (i == j) continue;

            int a = Math.Min(i, j);
            int b = Math.Max(i, j);

            if (addedEdges.Contains((a, b))) continue;

            adjacencyMatrix[a, b] = 1;
            adjacencyMatrix[b, a] = 1;

            addedEdges.Add((a, b));
            edgeCount++;
        }

        Console.WriteLine($"Згенеровано граф з {vertexCount} вершинами і {edgeCount} ребрами (щільність ≈ {density:P0})");
    }


}
