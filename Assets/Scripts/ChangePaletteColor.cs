using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePaletteColor : MonoBehaviour
{
    public Material material;
    public Color color1 = new Color(0f, 0f, 0f, 1f);
    public Color color2 = new Color(0.25f, 0.25f, 0.25f, 1f);
    public Color color3 = new Color(0.5f, 0.5f, 0.5f, 1f);
    public Color color4 = new Color(0.75f, 0.75f, 0.75f, 1f);

    public bool changeOnAwake = true;
    public float interpolateTime = 0f;

    public static void ChangeMaterialColors(Material material, Color color1, Color color2, Color color3, Color color4)
    {
        material.SetColor("_Color1", color1);
        material.SetColor("_Color2", color2);
        material.SetColor("_Color3", color3);
        material.SetColor("_Color4", color4);
    }

    public static IEnumerator ChangeMaterialColors(Material material, Color color1, Color color2, Color color3, Color color4, float interpolateTime)
    {
        Color initialColor1 = material.GetColor("_Color1");
        Color initialColor2 = material.GetColor("_Color2");
        Color initialColor3 = material.GetColor("_Color3");
        Color initialColor4 = material.GetColor("_Color4");
        float currentTime = 0f;
        do
        {
            currentTime += Time.deltaTime;
            float t = currentTime / interpolateTime;
            ChangeMaterialColors(
                material,
                Color.Lerp(initialColor1, color1, t),
                Color.Lerp(initialColor2, color2, t),
                Color.Lerp(initialColor3, color3, t),
                Color.Lerp(initialColor4, color4, t)
            );
            yield return null;
        }
        while (currentTime <= interpolateTime);
    }

    public void ChangeMaterialColors()
    {
        if (interpolateTime <= 0f)
        {
            ChangeMaterialColors(material, color1, color2, color3, color4);
        }
        else
        {
            StartCoroutine(ChangeMaterialColors(material, color1, color2, color3, color4, interpolateTime));
        }
    }

    void Awake()
    {
        if (changeOnAwake)
        {
            ChangeMaterialColors();
        }
    }
}
