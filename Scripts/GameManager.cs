using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Completed
{
	using System.Collections.Generic;		
	using UnityEngine.UI;					
	
	public class GameManager : MonoBehaviour
	{
		public float levelStartDelay = 2f;						
		public float turnDelay = 0.1f;
        //public int playerFoodPoints = 100;	
        //public static int hp = GameObject.Find("BattleAttack").GetComponent<GameControl>().HP;
        public int playerFoodPoints;
        public static GameManager instance = null;				
		[HideInInspector] public bool playersTurn = true;
        private Animator Healthbar;
        private HealthStat HS;


        private Text levelText;									
		public GameObject levelImage;							
		private BoardManager boardScript;						
		private int level;									
		private List<Enemy> enemies;							
		private bool enemiesMoving;								
		public bool doingSetup = true;							
		
		
		
		void Awake()
		{
            playerFoodPoints= GameObject.Find("BattleAttack").GetComponent<GameControl>().HP;
            level = GameObject.Find("BattleAttack").GetComponent<GameControl>().level;
            instance = this;
            /*if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);*/

			
			enemies = new List<Enemy>();
			
			boardScript = GetComponent<BoardManager>();
			
			InitGame();
		}

        /*[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static public void CallbackInitialization()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            GameObject.Find("BattleAttack").GetComponent<GameControl>().level += 1;
            //instance.level++;
            instance.InitGame();
        }*/

        /*void OnEnable()
        {
            SceneManager.sceneLoaded += Loadedscene;
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= Loadedscene;
        }

        void Loadedscene(Scene scene, LoadSceneMode mode)
        {
            //scene = SceneManager.GetActiveScene();
            //instance.InitGame();
            InitGame();
            GameObject.Find("BattleAttack").GetComponent<GameControl>().level += 1;
        }*/



        void InitGame()
		{
            //playerFoodPoints = GameObject.Find("BattleAttack").GetComponent<GameControl>().HP;
            Healthbar = GameObject.Find("BattleHealthBarCanvas/Healthbarbackground").GetComponent<Animator>();

            Healthbar.SetBool("HealthBarIsAppear", false);

            doingSetup = true;
			
			levelImage = GameObject.Find("LevelImage");
			
			levelText = GameObject.Find("LevelText").GetComponent<Text>();
			
			levelText.text = "Hollow Cave Floor " + GameObject.Find("BattleAttack").GetComponent<GameControl>().level;
			
			levelImage.SetActive(true);
			
			Invoke("HideLevelImage", levelStartDelay);

            Healthbar.SetBool("HealthBarIsAppear", true);

            HS = FindObjectOfType<HealthStat>();

            Debug.Log(HS.MyCurrentFill);


            enemies.Clear();
			
			boardScript.SetupScene(GameObject.Find("BattleAttack").GetComponent<GameControl>().level);
			
		}
		
		
		public void HideLevelImage()
		{
			levelImage.SetActive(false);
			
			doingSetup = false;
		}
		
		void Update()
		{
            Healthbar = GameObject.Find("BattleHealthBarCanvas/Healthbarbackground").GetComponent<Animator>();
            if (playersTurn || enemiesMoving || doingSetup)
				return;
			
			StartCoroutine (MoveEnemies ());
		}
		
		public void AddEnemyToList(Enemy script)
		{
			enemies.Add(script);
		}
		
		
		public void GameOver()
		{
            levelText.text = "On Floor " + GameObject.Find("BattleAttack").GetComponent<GameControl>().level + ", Thomas died in the cave.";

            levelImage.SetActive(true);
			
			enabled = false;
            GameObject.Find("Move").GetComponent<MoveCave>().isAtCave = true;
            SceneManager.LoadScene("Forest");
		}
		
		IEnumerator MoveEnemies()
		{
			enemiesMoving = true;
			
			yield return new WaitForSeconds(turnDelay);
			
			if (enemies.Count == 0) 
			{
				yield return new WaitForSeconds(turnDelay);
			}
			
			for (int i = 0; i < enemies.Count; i++)
			{
				enemies[i].MoveEnemy ();
				
				yield return new WaitForSeconds(enemies[i].moveTime);
			}
			playersTurn = true;
			
			enemiesMoving = false;
		}
	}
}

