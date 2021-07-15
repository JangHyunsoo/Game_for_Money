using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // variable
    private Vector2Int m_tGamePos;
    private CharacterStatus m_pStatus;
    private SpriteRenderer m_cpSpriteRender;

    // get set
    public Vector2Int GamePos { get { return m_tGamePos; } set { m_tGamePos = value; } }
    public CharacterStatus Status { get { return m_pStatus; } set { m_pStatus = value; } }

    // Start is called before the first frame update
    void Start()
    {
        m_cpSpriteRender = GetComponent<SpriteRenderer>();
        m_cpSpriteRender.sprite = m_pStatus.m_cpSprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
