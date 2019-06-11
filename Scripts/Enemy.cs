using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Completed
{
	public class Enemy : MovingObject
	{
        public int playerDamage;
		private Animator animator;							
		private Transform target;							
		public bool skipMove;
        public int hp;
        private Text goldText;
        public GameControl playerAttributes;

       
        protected override void Start ()
		{
            playerAttributes = FindObjectOfType<GameControl>();
            goldText = GameObject.Find("/Canvas/MoneyText").GetComponent<Text>();
            hp = playerAttributes.level * 3;
            GameManager.instance.AddEnemyToList (this);
            //GameManager.AddEnemyToList(this);


            animator = GetComponent<Animator> ();
			target = GameObject.FindGameObjectWithTag ("Player").transform;
            playerDamage = playerAttributes.level*3;
            //Debug.Log(playerDamage);

            base.Start ();
		}
		
		
		public override void AttemptMove <T> (int xDir, int yDir)
		{
			if(skipMove)
			{
				skipMove = false;
				return;
				
			}
			
			base.AttemptMove <T> (xDir, yDir);
			
			skipMove = true;
		}

       public void DamageEnemy(int loss)
        {
            hp -= loss;
            if (hp <= 0)
            {
                int add_amount = playerAttributes.level * 2;
                playerAttributes.EnemyKilled++;
                if (playerAttributes.EnemyKilled >= 3)
                {
                    if (playerAttributes.QuestCount == 1)
                    {
                        playerAttributes.isQuestComplete = true;
                    }
                }

                FindObjectOfType<Player>().enemyLeft--;
                goldText.text = "+"+add_amount+ " Gold: " + playerAttributes.money;
                playerAttributes.money += (playerAttributes.level * 2);
                playerDamage = 0;
                gameObject.SetActive(false);
                //Destroy(this);
                //DestroyImmediate(this, true);
            }


        }


        public void MoveEnemy ()
		{
			int xDir = 0;
			int yDir = 0;
			
			if(Mathf.Abs (target.position.x - transform.position.x) < float.Epsilon)
            {
                yDir = target.position.y > transform.position.y ? 1 : -1;
            }else
				xDir = target.position.x > transform.position.x ? 1 : -1;
			
			AttemptMove <Player> (xDir, yDir);
		}


        protected override void OnCantMove <T> (T component)
		{

            Player hitPlayer = component as Player;

            animator.SetTrigger("enemyAttack");
            //DamageEnemy(playerAttributes.attack);
            if(playerDamage>0)
            {
                hitPlayer.LoseFood(playerDamage);
            }



        }

        /*protected override void OnCantMove<T>(T component)
        {

        }*/

    }
}
