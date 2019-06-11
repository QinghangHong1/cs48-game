using UnityEngine;
using System.Collections;

namespace Completed
{
	public class Wall : MonoBehaviour
	{
		public Sprite dmgSprite;					//Alternate sprite to display after Wall has been attacked by player.
		public int hp = 3;							//hit points for the wall.
		
		
		private SpriteRenderer spriteRenderer;		//Store a component reference to the attached SpriteRenderer.
		
		
		void Awake ()
		{
			
			spriteRenderer = GetComponent<SpriteRenderer> ();
		}
		public void DamageWall (int loss)
		{
			spriteRenderer.sprite = dmgSprite;
			
			hp -= loss;
			
			if(hp <= 0)
				gameObject.SetActive (false);
		}
	}
}
