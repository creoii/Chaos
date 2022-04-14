using UnityEngine;
using System.Collections;

public class Character : Entity
{
    public PlayerInterface playerInterface;
    public CharacterStatistics statistics;
    public PlayerClass playerClass = Classes.Warrior;
    public LevelData level = new LevelData();
    public float inCombat = 0f;

    private SpriteRenderer sprite;
    private Vector3 movement;
    private float movementModifier = .1f;

    void Awake()
    {
        statistics = new CharacterStatistics();
        stats = playerClass.maxStats;
    }

    void Start()
    {
        //This will all be rewritten when the inventory is manipulatable from the game screen
        if (playerClass.classInventory.slots[0] == null) Debug.Log("null");
        playerClass.classInventory.slots[0].SetItem(ItemBuilder.weapons[0]);
        playerClass.classInventory.slots[1].SetItem(ItemBuilder.abilities[0]);

        sprite = GetComponent<SpriteRenderer>();
        pool = GetComponentInChildren<ObjectPool>();
        playerInterface = GetComponentInChildren<PlayerInterface>();
        StartInventory(playerClass.classInventory);

        SpriteUtil.SetSprite(sprite, "Sprites/Characters/Classes/" + playerClass.sprite);

        StartCoroutine(UpdateRegeneration(.12f * (stats.healthRegeneration + 8.3f), .12f * (stats.manaRegeneration + 8.3f)));
    }

    void Update()
    {
        UpdateMovement();
        UpdateInventory(playerClass.classInventory);
        if (Input.GetKey(KeyCode.Mouse0)) UpdateAttacks(playerClass.classInventory);
        if (Input.GetKey(Game.settings.useAbilityKey)) UpdateAbilities();

        if (inCombat > 0f) inCombat -= Time.deltaTime;
        else inCombat = 0f;
    }

    void UpdateMovement()
    {
        if (stats.speed > 0)
        {
            if (Input.GetKey(Game.settings.leftKey)) movement.x -= 1f;
            if (Input.GetKey(Game.settings.downKey)) movement.y -= 1f;
            if (Input.GetKey(Game.settings.upKey)) movement.y += 1f;
            if (Input.GetKey(Game.settings.rightKey)) movement.x += 1f;

            movement *= 1 / (4f + (stats.speed * .07467f));
            if (movement != Vector3.zero)
            {
                transform.position += movement * movementModifier;
                movement = Vector3.zero;
            }
        }

        if (Input.GetKey(Game.settings.rotateLeftKey)) transform.Rotate(Vector3.forward * Game.settings.rotationSpeed * Time.deltaTime);
        if (Input.GetKey(Game.settings.rotateRightKey)) transform.Rotate(Vector3.forward * -Game.settings.rotationSpeed * Time.deltaTime);
        if (Input.GetKeyDown(Game.settings.resetRotationKey)) transform.rotation = Quaternion.identity;
    }

    void StartInventory(ClassInventory inventory)
    {
        WeaponItem weapon = inventory.slots[0].item as WeaponItem;
        weapon.Start();
        weapon.sigils[0] = ItemBuilder.sigils[0];

        (inventory.slots[1].item as AbilityItem).Start();
    }

    void UpdateInventory(ClassInventory inventory)
    {
        if (!inventory.slots[0].empty)
        {
            (inventory.slots[0].item as WeaponItem).IncrementAttackTime(Time.deltaTime);
        }

        if (!inventory.slots[1].empty)
        {
            (inventory.slots[1].item as AbilityItem).IncrementAttackTime(Time.deltaTime);
        }
    }

    void UpdateAttacks(ClassInventory inventory)
    {
        if (stats.attackSpeed > 0)
        {
            if (!inventory.slots[0].empty)
            {
                (inventory.slots[0].item as WeaponItem).Use(this);
            }
        }
    }

    void UpdateAbilities()
    {
        if (playerClass.classInventory.slots[1] != null || (!playerClass.classInventory.slots[1].empty))
        {
            AbilityItem ability = playerClass.classInventory.slots[1].item as AbilityItem;
            ability.Activate(this);
        }
    }

    public void UpdateLeveling(float xp)
    {
        level.xp += xp;
        if (level.xp > LevelData.XpRequired(level.level) && level.level < 40) ++level.level;
    }

    IEnumerator UpdateRegeneration(float amount, float manaAmount)
    {
        for (; ; ) {
            Heal(amount);
            playerInterface.UpdateHealthBar();
            HealMana(manaAmount);
            playerInterface.UpdateManaBar();
            yield return new WaitForSeconds(1f);
        }
    }

    public override void OnHit(Projectile projectile, float damage, bool ignoreArmor)
    {
        base.OnHit(projectile, damage, ignoreArmor);
    }

    public override void Heal(float amount)
    {
        base.Heal(amount);
        playerInterface.UpdateHealthBar();
    }

    public override void HealMana(float amount)
    {
        base.HealMana(amount);
        playerInterface.UpdateManaBar();
    }

    public override void Damage(float amount, bool ignoreArmor)
    {
        base.Damage(amount, ignoreArmor);
        inCombat = 5f;
        playerInterface.UpdateHealthBar();
    }

    public override void DamageMana(float amount)
    {
        base.DamageMana(amount);
        playerInterface.UpdateManaBar();
    }

    public void AddMaxHealth(float maxHealth)
    {
        if (stats.maxHealth + maxHealth > playerClass.maxStats.maxHealth)
        {
            stats.maxHealth = playerClass.maxStats.maxHealth;
        }
        else stats.maxHealth += maxHealth;
    }

    public void AddMaxMana(float maxHealth)
    {
        if (stats.maxMana + maxHealth > playerClass.maxStats.maxMana)
        {
            stats.maxMana = playerClass.maxStats.maxMana;
        }
        else stats.maxMana += maxHealth;
    }

    public void AddSpeed(float maxHealth)
    {
        if (stats.speed + maxHealth > playerClass.maxStats.speed)
        {
            stats.speed = playerClass.maxStats.speed;
        }
        else stats.speed += maxHealth;
    }

    public void AddAttackSpeed(float maxHealth)
    {
        if (stats.attackSpeed + maxHealth > playerClass.maxStats.attackSpeed)
        {
            stats.attackSpeed = playerClass.maxStats.attackSpeed;
        }
        else stats.attackSpeed += maxHealth;
    }

    public void AddArmor(float maxHealth)
    {
        if (stats.armor + maxHealth > playerClass.maxStats.armor)
        {
            stats.armor = playerClass.maxStats.armor;
        }
        else stats.armor += maxHealth;
    }

    public void AddAttack(float maxHealth)
    {
        if (stats.attack + maxHealth > playerClass.maxStats.attack)
        {
            stats.attack = playerClass.maxStats.attack;
        }
        else stats.attack += maxHealth;
    }

    public void AddHealthRegeneration(float maxHealth)
    {
        if (stats.healthRegeneration + maxHealth > playerClass.maxStats.healthRegeneration)
        {
            stats.healthRegeneration = playerClass.maxStats.healthRegeneration;
        }
        else stats.healthRegeneration += maxHealth;
    }

    public void AddManaRegeneration(float maxHealth)
    {
        if (stats.manaRegeneration + maxHealth > playerClass.maxStats.manaRegeneration)
        {
            stats.manaRegeneration = playerClass.maxStats.manaRegeneration;
        }
        else stats.manaRegeneration += maxHealth;
    }
}
