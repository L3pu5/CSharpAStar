using System;
using System.Collections.Generic;

public class AStar{
    Tile start;
    Tile finish;
    public List<Tile> Path;
    
    Tile getLowestTile(List<Tile> _list){
        int lowest = 1000000000;
        Tile output = null;
        foreach (var tile in _list)
        {
            if(tile.f < lowest){
                lowest = tile.f;
                output = tile;
            }
        }
        return output;
    }

    void reconstructPath(){
        Path = new List<Tile>();
        Tile currentTile = finish;
        while(currentTile != null){
            if(currentTile == start){
                Path.Add(start);
                return;
            }
            Path.Add(currentTile);
            if(currentTile != finish)
                currentTile.Symbol = 'X';
            currentTile = currentTile.parent;
        }
    }

    void performAStar(Map _map){
        List<Tile> openTiles = new List<Tile>();
        start.g = 0;
        openTiles.Add(start);
        
        //While we have tiles to search
        while(openTiles.Count > 0){
            //Get the next closest tile in our open tiles/
            Tile currentTile = getLowestTile(openTiles);
            //If the tile is the targest, finish
            if(currentTile == finish){
                reconstructPath();
                return;
            }
            // Remove from the open set
            openTiles.Remove(currentTile);
            //Grab all the neighbours of currenTile;
            List<Tile> neighbours = _map.GetTileNeigbhours(currentTile, true);

            //Foreach Tile in our beighbours
            foreach(Tile neighbourTile in neighbours){
                //Calculate a new G score for the neighbour from the current tile
                int gScore = currentTile.g + _map.Distance(currentTile, neighbourTile);
                //If the new Gscore is cheaper, update
                if(gScore < neighbourTile.g){
                    //Set the neighbour's parent to the current Tile
                    neighbourTile.parent = currentTile;
                    //Update G and F
                    neighbourTile.g = gScore;
                    neighbourTile.f = gScore + _map.HDistance(neighbourTile, finish);
                    //Put it in the open tiles.
                    if(!openTiles.Contains(neighbourTile))
                    {
                        openTiles.Add(neighbourTile);
                    }
                }
            }
        }
    }

    public AStar(Tile _start, Tile _finish, Map _map) // Heuristic?
    {
        start = _start;
        start.Symbol = 'A';
        finish = _finish;
        finish.Symbol = 'B';
        Graphics.DrawMap(_map);
        performAStar(_map);
    }
}