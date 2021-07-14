using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    private int m_iID;
    private Color m_eColor;
    private List<Node> m_listNode;
    public Color color { get { return m_eColor; } set { m_eColor = value; } }
    
    public Team()
    {
        m_iID = -1;
        m_eColor = Color.white;
        m_listNode = new List<Node>();
    }

    public Team(int _iID, Color _eColor)
    {
        m_iID = _iID;
        m_eColor = _eColor;
        m_listNode = new List<Node>();
    }

    public Node CreateNodeWithGamePos(Vector2Int _tGamePos)
    {
        Node pNode = MapManager.Instance.CreateNodeWithGamePos(_tGamePos);
        pNode.SetTeam(this);
        m_listNode.Add(pNode);
        return pNode;
    }

}
