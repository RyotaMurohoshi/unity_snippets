using UnityEngine;

[CreateAssetMenu]
public class MagicScriptableObject : ScriptableObject, IContainer<Magic>
{
    [SerializeField]
    Magic data;
    public Magic Data { get { return data; } }
}
