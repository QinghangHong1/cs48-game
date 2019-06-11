using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;

namespace Completed
{
	public class Player : MovingObject
	{
		public float restartLevelDelay = 1f;	
		public int pointsPerFood = 10;				
		public int pointsPerSoda = 20;				
		public int wallDamage = 1;					
		public Text foodText;
        public Text bottleText;
        public Text goldText;
        private int gold_amount = 2;
        private Animator animator;
        public int enemyLeft;
        private GameControl playerAttributes;

        [SerializeField]
        private HealthStat health;

        private float initialHealth;
        //private int food;      

        protected override void Start ()
		{
            playerAttributes = FindObjectOfType<GameControl>();

            animator = GetComponent<Animator>();
            initialHealth = playerAttributes.HP;
            health.Initialize(initialHealth, 100);

            //food = GameManager.instance.playerFoodPoints;
            //food=GameObject.Find("BattleAttack").GetComponent<GameControl>().HP;
            foodText.text = "HP: " + playerAttributes.HP;
            bottleText.text = "Potion: " + playerAttributes.health;
            goldText.text = "Gold: " + playerAttributes.money;
            enemyLeft = FindObjectOfType<BoardManager>().enemy_count;
            base.Start ();
		}
		
		
		private void OnDisable ()
		{
			GameManager.instance.playerFoodPoints = playerAttributes.HP;
		}
		
		
		private void Update ()
		{
			if(!GameManager.instance.playersTurn)
            {
                return;
            }
            if(Input.GetKeyDown(KeyCode.P))
            {

                int hpincrease = 5;
                if(playerAttributes.health>0)
                {
                    if (playerAttributes.HP <= (100 - hpincrease))
                    {
                        playerAttributes.HP += hpincrease;
                        playerAttributes.health -= 1;
                        bottleText.text = "-1 Potion: " + playerAttributes.health;
                        foodText.text = "+" + hpincrease + " HP: " + playerAttributes.HP;
                    }
                    else if (playerAttributes.HP>(100 - hpincrease)&& playerAttributes.HP<100)
                    {
                        int hp_before = playerAttributes.HP;
                        playerAttributes.HP = 100;
                        playerAttributes.health -= 1;
                        bottleText.text = "-1 Potion: " + playerAttributes.health;
                        foodText.text = "+" + (100-hp_before) + " HP: " + playerAttributes.HP;

                    }

                }

            }


            int horizontal = 0;  	
			int vertical = 0;		
			
			horizontal = (int) (Input.GetAxisRaw ("Horizontal"));
			
			vertical = (int) (Input.GetAxisRaw ("Vertical"));
			
			if(horizontal != 0)
			{
				vertical = 0;
			}
				
			if(horizontal != 0 || vertical != 0)
			{
                AttemptMove<Wall> (horizontal, vertical);
                Debug.Log("Moved1");
                AttemptMove<Enemy>(horizontal, vertical);
                Debug.Log("Moved2");
            }
		}
		
		protected override void AttemptMove <T> (int xDir, int yDir)
		{
            //food--;
            foodText.text = "HP: " + playerAttributes.HP;
            bottleText.text = "Potion: " + playerAttributes.health;
            goldText.text = "Gold: " + playerAttributes.money;
            base.AttemptMove <T> (xDir, yDir);
           
            CheckIfGameOver ();
			
			GameManager.instance.playersTurn = false;
		}

       /*protected override void OnCantMove <T> (T component)
		{


            if (typeof(T)==typeof(Wall))
            {
                //Debug.Log("hit");
                Wall hitWall = component as Wall;
                hitWall.DamageWall(playerAttributes.attack);
                animator.SetTrigger("playerHit");
            }
            else
            {
                Enemy hitEnemy = component as Enemy;
                hitEnemy.DamageEnemy(playerAttributes.attack);
                animator.SetTrigger("playerChop");
            }
        }*/
        protected override void OnCantMove<T>(T component)
        {
            Vector3 component_postion = component.transform.position;
            float x = component_postion.x;
            float y = component_postion.y;
            //Debug.Log(x);
            //Debug.Log(y);
            Vector3 player_postion = GameObject.FindGameObjectWithTag("Player").transform.position;
            float a = player_postion.x;
            float b = player_postion.y;
            //Debug.Log(a);
            //Debug.Log(b);
            if (typeof(T) == typeof(Wall) && (x - a) >= 0)
            {
                Wall hitWall = component as Wall;
                hitWall.DamageWall(GameObject.Find("BattleAttack").GetComponent<GameControl>().attack);
                animator.SetTrigger("playerRightChop");
            }
            else if (typeof(T) == typeof(Wall) && (x - a) < 0)
            {
                Wall hitWall = component as Wall;
                hitWall.DamageWall(GameObject.Find("BattleAttack").GetComponent<GameControl>().attack);
                animator.SetTrigger("playerHit");
            }
            else if (x - a >= 0)
            {
                Enemy hitEnemy = component as Enemy;
                hitEnemy.DamageEnemy(GameObject.Find("BattleAttack").GetComponent<GameControl>().attack);
                animator.SetTrigger("playerRightHit");
            }
            else
            {
                Enemy hitEnemy = component as Enemy;
                hitEnemy.DamageEnemy(GameObject.Find("BattleAttack").GetComponent<GameControl>().attack);
                animator.SetTrigger("playerChop");
            }
        }


        private void OnTriggerEnter2D (Collider2D other)
		{
			if(other.tag == "Exit")
			{
                if (enemyLeft == 0)
                {
                    playerAttributes.level += 1;
                    Invoke("Restart", restartLevelDelay);

                    enabled = false;
                }
			}

            else if (other.tag == "Quit")
            {
                Debug.Log("Quiting");
                //GameObject.Find("Move").GetComponent<MoveCave>().isAtCave = true;
                FindObjectOfType<MoveCave>().isAtCave = true;
                SceneManager.LoadScene(sceneName: "Forest");


                enabled = false;
            }

            else if(other.tag == "Food")
			{
                //GameObject.Find("BattleAttack").GetComponent<GameControl>().HP += pointsPerFood;
                playerAttributes.health += 1;
                bottleText.text = "+1 Potion: " + playerAttributes.health;// + GameObject.Find("BattleAttack").GetComponent<GameControl>().HP;
				
				other.gameObject.SetActive (false);
			}
			
			else if(other.tag == "Soda")
			{
                //GameObject.Find("BattleAttack").GetComponent<GameControl>().HP += pointsPerSoda;
                //GameObject.Find("BattleAttack").GetComponent<GameControl>().health += 1;
                //bottleText.text = "+1 BOTTLE: "+GameObject.Find("BattleAttack").GetComponent<GameControl>().health;// + GameObject.Find("BattleAttack").GetComponent<GameControl>().HP;
                playerAttributes.money += gold_amount;
                goldText.text = "+" +gold_amount+ " Gold: " + playerAttributes.money;
                other.gameObject.SetActive (false);
			}
		}
		
		
		private void Restart ()
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            //SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
		
		
		public void LoseFood (int loss)
		{
            //animator.SetTrigger ("playerHit");
            if (playerAttributes.HP < loss)
            {
                int blood_amount = playerAttributes.HP;
                playerAttributes.HP = 0;
                foodText.text = "-" + blood_amount + " HP: " + playerAttributes.HP;
            }
            else
            {
                playerAttributes.HP -= loss;
                foodText.text = "-" + loss + " HP: " + playerAttributes.HP;
            }
			
			
			
			CheckIfGameOver ();
		}
		
		
		private void CheckIfGameOver ()
		{
			if (playerAttributes.HP <= 0) 
			{
				GameManager.instance.GameOver ();
			}
		}
	}
}

