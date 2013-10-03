using System.IO;
using StatusBoard.JSON;

namespace SampleCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Rootobject();
            root.AddGraph("Graph1")
                .AddDataSequence("Seq1", new Datasequence()
                                     .AddDataPoint("Jan", 10)
                                     .AddDataPoint("Feb", 20)
                                     .AddDataPoint("Mar", 15)
                                     .AddDataPoint("Apr", 45)
                                     .AddDataPoint("May", 55)
                                     .AddDataPoint("Jun", 155)
                                     .AddDataPoint("Jul", 255)
                                     .AddDataPoint("Aug", 55)
                                     .AddDataPoint("Sep", 15));

            root.graph.type = "line";
            var str = root.ToJSON();

            File.WriteAllText("test.txt", str);
        }
    }
}
