using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Vector2Int m_tGamePos;
    private Team m_pTeam;
    private SpriteRenderer m_rdRenderer;
    private Transform m_trCharacter;

    // get set
    public Vector2Int GamePos { get { return GamePos; } set { m_tGamePos = value; } }
    public Transform trCharacter { get { return m_trCharacter; } set { m_trCharacter = value; } }

    // Start is called before the first frame update
    void Start()
    {
        m_rdRenderer = GetComponent<SpriteRenderer>();
        m_rdRenderer.color = m_pTeam.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(m_trCharacter == null)
            m_trCharacter = CharacterManager.Instance.CreateCharacterWithSelect(m_tGamePos);
    }

    private void OnMouseUp()
    {
        // do somehting
    }

    private void OnMouseOver()
    {
        m_rdRenderer.color = Color.gray;
    }

    private void OnMouseExit()
    {
        m_rdRenderer.color = m_pTeam.color;
    }

    public void SetTeam(Team pTeam)
    {
        m_pTeam = pTeam;
    }
}
