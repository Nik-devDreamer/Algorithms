using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_Dangerous_route__1._3_
{
    // Поиск кратчайшего пути
    public class Dijkstra
    {
        Graph graph;

        List<GraphVertexInfo> infos;

        public Dijkstra(Graph graph)
        {
            this.graph = graph;
        }

        private void InitInfo()
        {
            infos = new List<GraphVertexInfo>();
            foreach (var v in graph.Vertices)
            {
                infos.Add(new GraphVertexInfo(v));
            }
        }

        // Получение информации о вершине графа
        private GraphVertexInfo GetVertexInfo(GraphVertex v)
        {
            foreach (var i in infos)
            {
                if (i.Vertex.Equals(v))
                {
                    return i;
                }
            }

            return null;
        }

        // Поиск непосещенной вершины с минимальным значением суммы
        private GraphVertexInfo FindUnvisitedVertexWithMinSum()
        {
            var minValue = int.MaxValue;
            GraphVertexInfo minVertexInfo = null;
            foreach (var i in infos)
            {
                if (i.IsUnvisited && i.EdgesWeightSum < minValue)
                {
                    minVertexInfo = i;
                    minValue = i.EdgesWeightSum;
                }
            }

            return minVertexInfo;
        }

        // Поиск кратчайшего пути по названиям вершин
        public Tuple<string, double> FindShortestPath(string startName, string finishName)
        {
            return FindShortestPath(graph.FindVertex(startName), graph.FindVertex(finishName));
        }

        // Поиск кратчайшего пути по вершинам
        private Tuple<string, double> FindShortestPath(GraphVertex startVertex, GraphVertex finishVertex)
        {
            InitInfo();
            var first = GetVertexInfo(startVertex);
            first.EdgesWeightSum = 0;
            while (true)
            {
                var current = FindUnvisitedVertexWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }

            return Tuple.Create(RestorePath(startVertex, finishVertex), chance);
        }

        // Вычисление суммы весов ребер для следующей вершины
        private void SetSumToNextVertex(GraphVertexInfo info)
        {
            info.IsUnvisited = false;
            foreach (var e in info.Vertex.Edges)
            {
                var nextInfo = GetVertexInfo(e.ConnectedVertex);
                var sum = info.EdgesWeightSum + e.EdgeWeight;
                if (sum < nextInfo.EdgesWeightSum)
                {
                    nextInfo.EdgesWeightSum = sum;
                    nextInfo.PreviousVertex = info.Vertex;
                }
            }
        }

        // Вычисление вероятности
        double chance = 1;
        private void Chance(string value)
        {
            string[] valueMas = value.Split(" - ");

            for (int i = 0; i < valueMas.Length; i++)
            {
                for(int j = 0; j < infos.Count; j++)
                {
                    if (infos[j].Vertex.Name == valueMas[i] && i != valueMas.Length - 1)
                    {
                        for(int k = 0; k < infos[j].Vertex.Edges.Count; k++)
                        {
                            if(valueMas[i + 1] == infos[j].Vertex.Edges[k].ConnectedVertex.Name)
                            {
                                chance *= 1 - (double)infos[j].Vertex.Edges[k].EdgeWeight / 100;
                                break;
                            }
                        }
                    }
                }
            }

            chance = 1 - chance;
        }

        // Формирование пути
        private string RestorePath(GraphVertex startVertex, GraphVertex endVertex)
        {
            var path = endVertex.ToString();
            while (startVertex != endVertex)
            {
                endVertex = GetVertexInfo(endVertex).PreviousVertex;
                path = endVertex.ToString() + " - " + path;
            }

            Chance(path);
            return path;
        }
    }
}
