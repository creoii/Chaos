using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SpriteUtil
{
    public static Sprite GetSprite(string path)
    {
        return Resources.Load<Sprite>(path);
    }

    public static void SetSprite(SpriteRenderer spriteRenderer, string path)
    {
        spriteRenderer.sprite = GetSprite(path);
    }

    public static void SetSprite(Image image, string path)
    {
        image.sprite = GetSprite(path);
    }
}