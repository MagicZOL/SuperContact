using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private static Dictionary<string, Sprite> cachedSprites
        = new Dictionary<string, Sprite>();

    public static Sprite[] Load()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("photo");

        foreach (Sprite sprite in sprites)
        {
            if (!cachedSprites.ContainsKey(sprite.name))
            {
                cachedSprites.Add(sprite.name, sprite);
            }
        }
        return sprites;
    }

    public static Sprite GetSprite(string name)
    {
        if (!cachedSprites.ContainsKey(name))
        {
            Sprite sprite = Resources.Load<Sprite>("photo/" + name);
            if (sprite) cachedSprites.Add(sprite.name, sprite);

            return sprite;
        }
        else
        {
            return cachedSprites[name];
        }
    }

}
