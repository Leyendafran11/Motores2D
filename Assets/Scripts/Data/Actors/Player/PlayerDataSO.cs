using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "new PlayerData", menuName = "Actor/PlayerData", order = 1)]
public class PlayerDataSO : ScriptableObject
{
    [Header("Info")]
    public Sprite sprite;
    public AnimatorController animator;
    public Color color = Color.white;

   // [Header("Stats")]
   // public playerStats playerStats;

    public void Initialize(PlayerController player)
    {
        GameObject g = player.getGameObject();
        SpriteRenderer ren = g.GetComponentInChildren<SpriteRenderer>();
        Animator  ani = g.GetComponentInChildren<Animator>();

        ren.sprite = sprite;
        ren.color = color;
        ani.runtimeAnimatorController = animator;

		if (ren)
		{
			if (sprite != null) ren.sprite = sprite;
			ren.color = color;
		}
		if (ani)
		{
			if (animator != null) ani.runtimeAnimatorController = animator;
		}

		Collider2D col = g.GetComponentInChildren<Collider2D>();
		if (col)
		{
			if (col is BoxCollider2D boxCol)
			{
				boxCol.size = new Vector2(ren.bounds.size.x, ren.bounds.size.y);
				boxCol.offset = new Vector2(ren.bounds.center.x - g.transform.position.x, ren.bounds.center.y - g.transform.position.y);
			}

			if (col is CapsuleCollider2D capCol)
			{
				capCol.size = new Vector2(ren.bounds.size.x, ren.bounds.size.y);
				capCol.offset = new Vector2(ren.bounds.center.x - g.transform.position.x, ren.bounds.center.y - g.transform.position.y);
			}
		}


		//playerStats gStats = (playerStats) player.getStats();

       // gStats.Update(playerStats);

    }
    
}
