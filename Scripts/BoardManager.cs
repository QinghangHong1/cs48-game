using UnityEngine;
using System;
using System.Collections.Generic; 		//Allows us to use Lists.
using Random = UnityEngine.Random; 		//Tells Random to use the Unity Engine random number generator.

namespace Completed
	
{
	
	public class BoardManager : MonoBehaviour
	{
		// Using Serializable allows us to embed a class with sub properties in the inspector.
		[Serializable]
		public class Count
		{
			public int minimum; 			//Minimum value for our Count class.
			public int maximum; 			//Maximum value for our Count class.
			
			
			//Assignment constructor.
			public Count (int min, int max)
			{
				minimum = min;
				maximum = max;
			}
		}
		
		
		public int columns = 8; 										//Number of columns in our game board.
		public int rows = 8;											//Number of rows in our game board.
		public Count wallCount = new Count (5, 8);						//Lower and upper limit for our random number of walls per level.
		public Count foodCount = new Count (1, 2);						//Lower and upper limit for our random number of food items per level.
		public GameObject exit;
        public GameObject quit;                                     //Prefab to spawn for exit.
        public GameObject[] floorTiles;									//Array of floor prefabs.
		public GameObject[] wallTiles;									//Array of wall prefabs.
		public GameObject[] foodTiles;									//Array of food prefabs.
		public GameObject[] enemyTiles;									//Array of enemy prefabs.
		public GameObject[] outerWallTiles;								//Array of outer tile prefabs.
		

		private Transform boardHolder;									//A variable to store a reference to the transform of our Board object.
		private List <Vector3> gridPositions = new List <Vector3> ();   //A list of possible locations to place tiles.

        public int enemy_count;
		
		void InitialiseList ()
		{
			gridPositions.Clear ();
			
			for(int x = 1; x < columns-1; x++)
			{
				for(int y = 1; y < rows-1; y++)
				{
					gridPositions.Add (new Vector3(x, y, 0f));
				}
			}
		}
		
		
		void BoardSetup ()
		{
			boardHolder = new GameObject ("Board").transform;
			
			for(int x = -1; x < columns + 1; x++)
			{
				for(int y = -1; y < rows + 1; y++)
				{
					GameObject toInstantiate = floorTiles[Random.Range (0,floorTiles.Length)];
					
					if(x == -1 || x == columns || y == -1 || y == rows)
						toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];
					
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					
					instance.transform.SetParent (boardHolder);
				}
			}
		}
		
		
		Vector3 RandomPosition ()
		{
			int randomIndex = Random.Range (0, gridPositions.Count);
			
			Vector3 randomPosition = gridPositions[randomIndex];
			
			gridPositions.RemoveAt (randomIndex);
			
			return randomPosition;
		}
		
		
		void LayoutObjectAtRandom (GameObject[] tileArray, int minimum, int maximum)
		{
			int objectCount = Random.Range (minimum, maximum+1);
			
			for(int i = 0; i < objectCount; i++)
			{
				Vector3 randomPosition = RandomPosition();
				
				GameObject tileChoice = tileArray[Random.Range (0, tileArray.Length)];
				
				Instantiate(tileChoice, randomPosition, Quaternion.identity);
			}
		}
		
		
		public void SetupScene (int level)
		{
			BoardSetup ();
			
			InitialiseList ();
			
			LayoutObjectAtRandom (wallTiles, wallCount.minimum, wallCount.maximum);
			
			LayoutObjectAtRandom (foodTiles, foodCount.minimum, foodCount.maximum);

            int enemyCount = (int)Mathf.Log(level, 2f);
            enemy_count = enemyCount;
			LayoutObjectAtRandom (enemyTiles, enemyCount, enemyCount);
			
			Instantiate (exit, new Vector3 (columns - 1, rows - 1, 0f), Quaternion.identity);
            Instantiate(quit, new Vector3(0, 7, 0f), Quaternion.identity);
        }
	}
}
