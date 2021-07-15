using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static MapManager m_pInstance = null;

    public static MapManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!m_pInstance)
            {
                m_pInstance = FindObjectOfType(typeof(MapManager)) as MapManager;

                if (m_pInstance == null)
                    Debug.Log("Cannot Find MapManager Instnace...");
            }
            return m_pInstance;
        }
    }

    private void Awake()
    {
        if (m_pInstance == null)
        {
            m_pInstance = this;
        }
        else if (m_pInstance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private int m_iHeight;
    [SerializeField] private int m_iWidth;
    [SerializeField] private Vector2 m_tZero;

    [SerializeField] private GameObject m_goNodePrefab;

    private Node[,] m_arrNode;
    private Transform m_trMapHolder;

    public bool Init()
    {
        m_arrNode = new Node[m_iWidth, m_iHeight];

        return true;
    }

    private bool IsOurTeam(int x, int y) // ture : team1 | false : team2
    {
        int iXhalf = (int)Mathf.Round(m_iWidth / 2);
        int[] arrYHalf = { 0, 3, 4 };

        if (x == iXhalf)
        {
            foreach (int iYHalf in arrYHalf)
            {
                if (y == iYHalf) return false;
            }
        }

        return x >= 0 && x <= iXhalf;
    }

    public void CreateMap(Transform _trHolder)
    {
        m_arrNode = new Node[m_iWidth, m_iHeight];
        m_trMapHolder = _trHolder;

        for(int x = 0; x < m_iWidth; x++)
        {
            for (int y = 0; y < m_iHeight; y++)
            {
                if (IsOurTeam(x, y))
                    m_arrNode[x, y] = RuleManager.Instance.MyTeam.CreateNodeWithGamePos(new Vector2Int(x, y));
                else
                    m_arrNode[x, y] = RuleManager.Instance.EmptyTeam.CreateNodeWithGamePos(new Vector2Int(x, y));
            }
        }
    }

    public Node CreateNodeWithGamePos(Vector2Int _tGamePos)
    {
        GameObject go = Instantiate(m_goNodePrefab, ToWorldPos(_tGamePos), new Quaternion((_tGamePos.x + _tGamePos.y) % 2 * 180, 0f, 0f, 0f));
        go.transform.SetParent(m_trMapHolder);
        Node node = go.GetComponent<Node>();
        node.GamePos = _tGamePos;
        return node;
    }

    public Vector2Int ToGamePos(Vector2 _tWorldPos)
    {
        return new Vector2Int((int)_tWorldPos.x, (int)_tWorldPos.y);
    }

    public Vector2 ToWorldPos(Vector2Int _tGamePos)
    {
        return new Vector2(m_tZero.x + _tGamePos.x, m_tZero.y + _tGamePos.y);
    }
}
