using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEachExample : MonoBehaviour
{
    [SerializeField]
    PlayerBehaviour playerBehaviourPrefab;

    void Start()
    {
        var players = new List<Player> {
            new Player(playerName: "Taro", maxHp: 4),
            new Player(playerName: "Jiro", maxHp: 3),
            new Player(playerName: "Saburo", maxHp: 2)
        };

        List<PlayerBehaviour> playerBehaviours = new List<PlayerBehaviour>();

        foreach (var player in players)
        {
            PlayerBehaviour playerBehaviour = Instantiate(playerBehaviourPrefab);
            playerBehaviour.SetData(player);
            playerBehaviour.OnDead.AddListener(p =>
            {
                Debug.LogFormat("{0} : {1}", p.PlayerName, player.PlayerName);
            });
            playerBehaviours.Add(playerBehaviour);
        }

        foreach(var playerBehaviour in playerBehaviours)
        {
            playerBehaviour.AddDamage(10);
        }
    }
}
