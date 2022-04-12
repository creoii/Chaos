using System;
using UnityEngine;

[Serializable]
public class Attack
{
    public string name = null;
    public string sprite;
    public float lifetime;
    public float speed;
    public int projectileCount = 1;
    public float rateOfFire = 1f;
    public float minDamage;
    public float maxDamage;
    public bool ignoreArmor;
    public int angleOffset = 0;
    public int angleGap = 0;
    public int angleChange;
    public bool onMouse = false;
    public string target = null;
    public MultiplierData acceleration = null;
    public PositionData2d positionOffset = null;
    public StatusEffect[] statusEffects;

    public Attack(string sprite, float lifetime, float speed, int projectileCount, float rateOfFire, float minDamage, float maxDamage, bool ignoreArmor, int angleOffset, int angleGap, int angleChange, bool onMouse, string target, MultiplierData acceleration, PositionData2d positionOffset, StatusEffect[] statusEffects)
    {
        this.sprite = sprite;
        this.lifetime = lifetime;
        this.speed = speed;
        this.projectileCount = projectileCount;
        this.rateOfFire = rateOfFire;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.ignoreArmor = ignoreArmor;
        this.angleOffset = angleOffset;
        this.angleGap = angleGap;
        this.angleChange = angleChange;
        this.onMouse = onMouse;
        this.target = target;
        this.acceleration = acceleration;
        this.positionOffset = positionOffset;
        this.statusEffects = statusEffects;
    }

    public void Start()
    {
        if (statusEffects != null)
        {
            for (int i = 0; i < statusEffects.Length; ++i)
            {
                if (statusEffects[i].name != null)
                {
                    foreach (StatusEffect effect in StatusEffectBuilder.statusEffects)
                    {
                        if (statusEffects[i].name.Equals(effect.name))
                        {
                            statusEffects[i] = StatusEffect.Override(statusEffects[i], effect);
                        }
                    }
                }
            }
        }
    }

    public static Attack Override(Attack one, Attack two)
    {
        return new Attack(
            two.sprite == null ? one.sprite : two.sprite,
            two.lifetime == 0 ? one.lifetime : two.lifetime,
            two.speed == 0 ? one.speed : two.speed,
            two.projectileCount == 0 ? one.projectileCount : two.projectileCount,
            two.rateOfFire == 0 ? one.rateOfFire : two.rateOfFire,
            two.minDamage == 0 ? one.minDamage : two.minDamage,
            two.maxDamage == 0 ? one.maxDamage : two.maxDamage,
            two.ignoreArmor,
            two.angleOffset == 0 ? one.angleOffset : two.angleOffset,
            two.angleGap == 0 ? one.angleGap : two.angleGap,
            two.angleChange == 0 ? one.angleChange : two.angleChange,
            two.onMouse,
            two.target == null ? one.target : two.target,
            MultiplierData.Override(one.acceleration, two.acceleration),
            PositionData2d.Override(one.positionOffset, two.positionOffset),
            two.statusEffects == null ? one.statusEffects : two.statusEffects
        );
    }

    public Vector3 GetTargetPosition(string target, Enemy enemy, GameObject character)
    {
        switch (target)
        {
            case "mouse":
                return MouseUtil.GetMouseWorldPos();
            case "origin":
                return enemy.GetOrigin();
            case "self":
                return enemy.GetPosition();
            default:
                return character.transform.position;
        }
    }

    public void Shoot(Character character, ObjectPool pool)
    {
        if (projectileCount > 0)
        {
            Vector3 position = (onMouse ? MouseUtil.GetMouseWorldPos() : character.transform.position) + positionOffset.GetAsVector3();
            float angle = MouseUtil.GetMouseAngle(position) + angleOffset;
            if (angle < 0) angle += 360f;
            if (projectileCount > 1) angle -= angleGap * (((projectileCount - 1f) / 2f) + 1);

            for (int i = 0; i < projectileCount; ++i)
            {
                GameObject obj = pool.GetObject();
                if (obj != null)
                {
                    obj.GetComponent<Projectile>().SetProperties(position, this, MathUtil.GetDirection((MouseUtil.GetMouseWorldPos() - position).normalized, angle += angleGap), Mathf.RoundToInt(UnityEngine.Random.Range(minDamage, maxDamage)) * ((character.stats.attack + 25f) / 50f));
                    obj.SetActive(true);
                }
            }
        }
    }

    public void Shoot(Enemy enemy, GameObject character, ObjectPool pool)
    {
        if (projectileCount > 0)
        {
            Vector3 position = (onMouse ? MouseUtil.GetMouseWorldPos() : enemy.GetPosition()) + positionOffset.GetAsVector3();
            Vector3 targetPosition = GetTargetPosition(target, enemy, character);
            float angle = MathUtil.ToAngle(targetPosition - position) + angleOffset;
            if (angle < 0) angle += 360f;
            if (projectileCount > 1) angle -= angleGap * (((projectileCount - 1f) / 2f) + 1);

            for (int i = 0; i < projectileCount; ++i)
            {
                GameObject obj = pool.GetObject();
                if (obj != null)
                {
                    obj.GetComponent<Projectile>().SetProperties(position, this, MathUtil.GetDirection((targetPosition - position).normalized, angle += angleGap), Mathf.RoundToInt(UnityEngine.Random.Range(minDamage, maxDamage)) * ((enemy.stats.attack + 25f) / 50f));
                    obj.SetActive(true);
                    angleOffset += angleChange;
                }
            }
        }
    }
}
