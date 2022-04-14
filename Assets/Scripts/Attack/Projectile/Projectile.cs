using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Entity owner;
    public Attack attack;
    public Vector3 direction;
    public float speed;
    public float rate;
    private float damage;
    private float life;

    public Projectile WithProperties(Entity owner, Vector3 position, Attack attack, Vector3 direction, float damage)
    {
        this.owner = owner;
        transform.position = position;
        this.attack = attack;
        speed = attack.speed * 10f;
        rate = attack.acceleration.rate;
        this.damage = damage;
        this.direction = direction;
        return this;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (attack.acceleration != null)
        {
            if (attack.acceleration.rate != 0f)
            {
                if (life >= attack.acceleration.offset)
                {
                    speed += rate * attack.acceleration.multiplier;
                }
            }
        }

        life += Time.deltaTime;
    }

    void OnEnable()
    {
        SpriteUtil.SetSprite(GetComponent<SpriteRenderer>(), "Sprites/Projectiles/" + attack.sprite);
        Invoke("Disable", attack.lifetime);
    }

    void Disable()
    {
        gameObject.SetActive(false);
        life = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Character") && gameObject.tag.Equals("EnemyProjectile"))
        {
            collision.gameObject.GetComponent<Character>().OnHit(this, damage, attack.ignoreArmor);
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag.Equals("Enemy") && gameObject.tag.Equals("PlayerProjectile"))
        {
            collision.gameObject.GetComponent<Enemy>().OnHit(this, damage, attack.ignoreArmor);
            gameObject.SetActive(false);
        }
    }
}
