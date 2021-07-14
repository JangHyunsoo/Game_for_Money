using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector2Int m_tGamePos { get; set; }

    private Team m_pTeam;
    private SpriteRenderer m_rdRenderer;

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
        // do somehting
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
