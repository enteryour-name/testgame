using UnityEngine;
using TMPro;

public class DeathGlowText : MonoBehaviour
{
    public Material textMaterial; // ���TextMeshPro����
    public Color glowColor = Color.red; // ������ɫ
    public float glowPower = 1.0f; // ����ǿ��

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