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

    [Header("Stats")]
    public playerStats playerStats;

    public void Initialize(PlayerController player)
    {
        GameObject g = player.getGameObject();
        SpriteRenderer ren = g.GetComponentInChildren<SpriteRenderer>();
        Animator  ani = g.GetComponentInChildren<Animator>();

        ren.sprite = sprite;
        ren.color = color;
        ani.runtimeAnimatorController = animator;


        playerStats gStats = (playerStats) player.getStats();

        gStats.Update(playerStats);

    }
    
}
