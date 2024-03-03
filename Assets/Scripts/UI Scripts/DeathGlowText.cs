using UnityEngine;
using TMPro;

public class DeathGlowText : MonoBehaviour
{
    public Material textMaterial; // 你的TextMeshPro材质
    public Color glowColor = Color.red; // 发光颜色
    public float glowPower = 1.0f; // 发光强度

    void Start()
    {
        if (textMaterial != null && textMaterial.HasProperty(ShaderUtilities.ID_GlowColor))
        {
            textMaterial.SetColor(ShaderUtilities.ID_GlowColor, glowColor);
        }

        if (textMaterial != null && textMaterial.HasProperty(ShaderUtilities.ID_GlowPower))
        {
            textMaterial.SetFloat(ShaderUtilities.ID_GlowPower, glowPower);
        }
    }
}