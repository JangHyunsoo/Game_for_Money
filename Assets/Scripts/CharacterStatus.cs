using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatus : ScriptableObject
{
    public string m_strName;
    public Sprite m_cpSprite;
    public List<string> m_listSynergy;
}