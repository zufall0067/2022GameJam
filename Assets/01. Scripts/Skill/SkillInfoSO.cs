using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/SkillSO")]
public class SkillInfoSO : ScriptableObject
{
    public List<Sprite> skillSprite;
    public List<string> skillText;  
}           
