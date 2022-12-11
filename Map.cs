using System.Collections.Generic;
using System;

public class Map{
    public int Width;
    public int Height;

    public Tile[,] Tiles;

    public Tile GetTile(int x, int y){
        return Tiles[x, y];
    }

    public int Distance(Tile _a, Tile _b){
        if(_a.x == _b.x || _a.y == _b.y)
            return 10;
        return 14;
    }

    public int HDistance(Tile _a, Tile _b){
        if (_a.x == _b.x)
            return (int) Math.Abs(10 * (_a.y - _b.y));
        if(_a.y == _b.y)
            return (int) Math.Abs(10 * (_a.x - _b.x));
        
        //If not a line, return the hypot
        return (int) Math.Sqrt(Math.Pow(Math.Abs(10 * (_a.y - _b.y)), 2) + Math.Pow(Math.Abs(10 * (_a.x - _b.x)),2));
    }

    public List<Tile> GetTileNeigbhours(Tile _tile, bool _diagonals = false){
        List<Tile> output = new List<Tile>();
        //Include diagonals?
        if(_diagonals){
            //Grab above if we can
            if(_tile.y < Height - 1){
                output.Add(Tiles[_tile.x, _tile.y + 1]);
                //Can we grab left?
                if(_tile.x != 0)
                    output.Add(Tiles[_tile.x-1, _tile.y +1]);
                //Can we grab right?
                if(_tile.x < Width -1)
                    output.Add(Tiles[_tile.x+1, _tile.y + 1]);
            }
            if(_tile.y > 0){
                output.Add(Tiles[_tile.x, _tile.y - 1]);
                //Can we grab left?
                if(_tile.x != 0)
                    output.Add(Tiles[_tile.x-1, _tile.y -1]);
                //Can we grab right?
                if(_tile.x < Width -1)
                    output.Add(Tiles[_tile.x+1, _tile.y - 1]);
            }
            if(_tile.x != 0)
                output.Add(Tiles[_tile.x -1, _tile.y]);
            if(_tile.x != Width-1)
                output.Add(Tiles[_tile.x+1,_tile.y]);
        }
        else{
            if(_tile.y < Height - 1){
                output.Add(Tiles[_tile.x, _tile.y +1]);
            }
            if(_tile.x < Width - 1){
                output.Add(Tiles[_tile.x + 1, _tile.y]);
            }
            if(_tile.y > 0){
                output.Add(Tiles[_tile.x, _tile.y -1]);
            }
            if(_tile.x > 0){
                output.Add(Tiles[_tile.x - 1, _tile.y]);
            }
        }
        return output;
    }

    public Map(int _width, int _height){
        this.Height = _height;
        this.Width = _width;

        Tiles = new Tile[Width, Height];
        fillTiles();
    }

    public List<Tile> GetRow(int _row){
        List<Tile> output = new List<Tile>();
        for (int i = 0; i < Width; i++)
        {
            output.Add(Tiles[i, _row]);
        }
        return output;
    }
    
    void fillTiles(){
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                Tiles[i,j] = new Tile(i,j);
            }
        }
    }

}


public class Tile{
    public int x;
    public int y;
    public Tile parent = null;
    
    public char Symbol = '.';

    public int g = 100000;
    public int f = 100000;

    public Tile (int _x, int _y){
        this.x = _x;
        this.y = _y;
    }
}