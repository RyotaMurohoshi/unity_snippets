using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    int level;
    [SerializeField]
    string playerName;
    [SerializeField]
    Sprite sprite;

    public int Level { get { return level; } }
    public string PlayerName { get { return playerName; } }
    public Sprite Sprite { get { return sprite; } }
}
