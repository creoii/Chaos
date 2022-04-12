using UnityEngine;

public class Entity : MonoBehaviour
{
    public Enemy enemy;
    public ObjectPool pool;

    void Start()
    {
        enemy = EnemyBuilder.enemies[Random.Range(0, 2)];
        enemy.Start(transform.position);
        pool = GetComponentInChildren<ObjectPool>();

        SpriteUtil.SetSprite(GetComponent<SpriteRenderer>(), "Sprites/Characters/Enemies/" + enemy.sprite);
    }

    void Update()
    {
        transform.position = enemy.GetPosition();
        enemy.UpdatePhase(pool);

        if (enemy.stats.health <= 0) gameObject.SetActive(false);
    }
}
