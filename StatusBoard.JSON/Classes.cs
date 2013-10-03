using System.Collections.Generic;
using Newtonsoft.Json;

namespace StatusBoard.JSON
{
    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented,
                                               new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
        }
    }

    public class Rootobject
    {
        public Rootobject()
        {
            graph = new Graph();
        }

        public Graph graph { get; set; }

        public Graph AddGraph(string graphTitle)
        {
            graph = new Graph { title = graphTitle };
            return graph;
        }
    }

    public class Graph
    {
        public Graph()
        {
            datasequences = new List<Datasequence>();
            title = "Graph";
        }

        public int? refreshEveryNSeconds { get; set; }

        public string color { get; set; }

        public bool? total { get; set; }

        public string type { get; set; }

        public Xaxis xAxis { get; set; }

        public Yaxis yAxis { get; set; }

        public string title { get; set; }

        public Error error { get; set; }

        public List<Datasequence> datasequences { get; set; }

        public Graph AddDataSequence(string titleDatasequence, Datasequence datasequence)
        {
            datasequence.title = titleDatasequence;
            datasequences.Add(datasequence);
            return this;
        }
    }

    public class Xaxis
    {
        public bool showEveryLabel { get; set; }
    }

    public class Yaxis
    {
        public bool hide { get; set; }
        public int minValue { get; set; }
        public int maxValue { get; set; }
        public Units units { get; set; }
    }

    public class Units
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class Error
    {
        public string message { get; set; }
        public string detail { get; set; }
    }

    public class Datasequence
    {
        public Datasequence()
        {
            datapoints = new List<Datapoint>();
            title = "Title";
        }

        public string title { get; set; }
        public List<Datapoint> datapoints { get; set; }

        public Datasequence AddDataPoint(string title, float value)
        {
            datapoints.Add(
                new Datapoint
                    {
                        title = title,
                        value = value
                    });
            return this;
        }
    }

    public class Datapoint
    {
        public string title { get; set; }
        public float value { get; set; }
    }
}