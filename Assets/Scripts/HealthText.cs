using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public Vector3 speed =new Vector3(0,75,0);
    RectTransform texttransform;
    public float timetofade = 1f;
    private float timeelapsed=0f;
    TextMeshProUGUI textmeshpro;
    private Color startcolor;
    private void Awake()
    {
        texttransform = GetComponent<RectTransform>();
        textmeshpro = GetComponent<TextMeshProUGUI>();
        startcolor = textmeshpro.color;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        texttransform.position += speed * Time.deltaTime;
        timeelapsed += Time.deltaTime;
        if (timeelapsed < timetofade)
        {
            float fadealpha=startcolor.a*(1-(timeelapsed/timetofade));
            textmeshpro.color = new Color(startcolor.r,startcolor.g,startcolor.b,fadealpha);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
