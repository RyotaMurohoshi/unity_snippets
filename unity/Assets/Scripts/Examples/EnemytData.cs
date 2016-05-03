using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    int level;
    [SerializeField]
    string playerName;

    public int Level { get { return level; } }
    public string PlayerName { get { return playerName; } }
}
