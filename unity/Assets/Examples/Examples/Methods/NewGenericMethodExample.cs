using UnityEngine;

public class NewGenericMethodExample : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    void Start()
    {
        var enemyPrefab = Resources.Load<Enemy>("Prefabs/Enemy");
        var enemy = Instantiate(enemyPrefab);
    }
}
