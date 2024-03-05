using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrLevelUpSkill : MonoBehaviour
{
    public int skillnum;
    public Sprite skill13;
    public Sprite skill14;
    public Sprite skill15;
    public Sprite skill23;
    public Sprite skill24;
    public Sprite skill25;
    public Image image;
    public CtrGenerateCharacter ctrGenerateCharacter;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        skillnum = (int)Time.time % 3;
        if(ctrGenerateCharacter.receivevalue == 1)
        {
            switch (skillnum)
            {
                case 0:image.sprite = skill13;break;
                case 1:image.sprite = skill14;break;
                case 2:image.sprite = skill15;break;
                default:image.sprite = skill13;break;
            }
            switch (skillnum)
            {
                case 1:image.sprite = skill23;break;
                case 2:image.sprite = skill24;break;
                case 3:image.sprite = skill25;break;
                default :image.sprite = skill23;break;
            }
        }
    }
}
