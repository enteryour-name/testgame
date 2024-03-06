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
    public CtrLevelUpMenu ctrLevelUpMenu;
    private GameObject character;
    private CtrSkill ctrSkill;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        character = ctrGenerateCharacter.character;
        ctrSkill = character.GetComponent<CtrSkill>();
    }
    // Update is called once per frame
    private void OnEnable()
    {
        skillnum = 10 * ctrGenerateCharacter.receivevalue + ctrLevelUpMenu.skillnum;
        switch (skillnum)
        {
            case 13: image.sprite = skill13; break;
            case 14: image.sprite = skill14; break;
            case 15: image.sprite = skill15; break;
            case 23: image.sprite = skill23; break;
            case 24: image.sprite = skill24; break;
            case 25: image.sprite = skill25; break;
            default: image.sprite = skill13; break;
        }
    }
        
        
    
}
