using System;
using System.Collections.Generic;

public static class Graphics{
    public static void DrawMap(Map _map){
        Console.Clear();
        for (int i = 0; i < _map.Height; i++)
        {
            List<Tile> row = _map.GetRow(i);
            for(int j = 0; j < row.Count; j++){
                Console.Write(row[j].Symbol);
            }
            Console.Write("\r\n");
        }
    }

}