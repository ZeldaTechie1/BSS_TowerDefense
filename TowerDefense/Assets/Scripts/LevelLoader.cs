using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour {

    public NodeTemplate[] nodeTypes;
    public int nodeScale;
	
    public void loadLevel(string levelName, bool isPlayerLevel, int levelSizeX, int levelSizeZ)
    {
        string[] fileInfo;
        if(!isPlayerLevel)//switches directory if the level was created by a player
        {
            fileInfo = System.IO.File.ReadAllLines("Assets/LevelFiles/SinglePlayerLevels/" + levelName + ".txt");
        }
        else
        {
            fileInfo = System.IO.File.ReadAllLines("Assets/LevelFiles/PlayerLevels/" + levelName + ".txt");
        }
        
        for(int count = 0; count < levelSizeX; count++)//loop to Spawn in foundation for level
        {
            for(int count2 = 0; count2 < levelSizeZ; count2++)
            {
                Spawn(1, count, 0, count2);
            }
        }

        int location = 0;
        //reads the information from the file and calls the Spawn function to spawn
        //the node at the location specified
        for (int y = 0; y < 2; y++)
        {
            for(int x = 0; x<levelSizeX; x++)
            {
                string line = fileInfo[location++];
                for(int z = 0; z<levelSizeZ; z++)
                {
                    Spawn(int.Parse(line[z] + ""), x, y + 1, z);
                }
            }
        }
    }

    void Spawn(int nodeVal, float x, float y, float z)//spawns node at location x,y,z with scale into consideration
    {
        if(nodeVal == 0)//value 0 is saved for air blocks
        {
            return;
        }
        if(y>1)
        {
            y -= .5f;
        }
        Vector3 position = new Vector3(x, y, z);
        position *= nodeScale;
        Instantiate(nodeTypes[nodeVal],position,Quaternion.identity);
    }
}
