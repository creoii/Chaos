using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    public Character character;
    public Canvas canvas;
    public Image healthBar;
    public Image manaBar;
    public Image[] slots = new Image[4];

    void Start()
    {
        character = GetComponentInParent<Character>();
        for (int i = 0; i < slots.Length; i++)
        {
            character.playerClass.classInventory.slots[i].transform = slots[i].transform as RectTransform;
        }
        canvas = GetComponent<Canvas>();
        healthBar.color = Color.green;
        manaBar.color = Color.blue;
    }

    void Update()
    {
        //should only be called when changing inventory slots
        UpdateInventory();
    }

    void OnMouseDrag()
    {
        Debug.Log("mouse drag");
    }

    public void UpdateHealthBar()
    {
        if (character.inCombat <= 0f && character.stats.health >= character.stats.maxHealth) healthBar.color = Color.clear;
        else
        {
            healthBar.transform.localScale = new Vector3(character.stats.health / character.stats.maxHealth, 1f, 1f);

            if (character.stats.health < character.stats.maxHealth * .2f) healthBar.color = Color.red;
            else if (character.stats.health < character.stats.maxHealth * .5f) healthBar.color = Color.yellow;
            else healthBar.color = Color.green;
        }
    }

    public void UpdateManaBar()
    {
        manaBar.transform.localScale = new Vector3(character.stats.mana / character.stats.maxMana, 1f, 1f);
    }

    private void UpdateInventory()
    {
        for (int i = 0; i < 2; ++i)
        {
            Item item = character.playerClass.classInventory.slots[i].item;
            if (item.sprite != null)
            {
                SpriteUtil.SetSprite(slots[i], "Sprites/Items/" + item.sprite);
            }
        }
    }
}
