//References: https://en.wikipedia.org/wiki/A*_search_algorithm

using System;



namespace CSharpAStar
{
    class Program
    {
        static void Main(string[] args)
        {
            Map testMap = new Map(15,6);
            Graphics.DrawMap(testMap); 
            AStar path = new AStar(testMap.GetTile(2, 3), testMap.GetTile(10, 1), testMap);
            if(path.Path != null)
                Graphics.DrawMap(testMap);
            else
                Console.WriteLine("Path failed!");
            Graphics.DrawMap(testMap);
        }
    }
}
