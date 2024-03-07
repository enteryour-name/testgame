using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrOtherLevel : MonoBehaviour
{
    public Sprite Fire1;
    public Sprite Fire2;
    public Sprite Leaf1;
    public Sprite Leaf2;
    public CtrGenerateCharacter generateCharacter;
    public int number;
    private Image im;
    // Start is called before the first frame update
    private void Start()
    {
        im = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(generateCharacter.receivevalue == 1)
        {
            im.sprite = Fire1;
        }
        else
        {
            im.sprite = Leaf1;
        }
    }
}
