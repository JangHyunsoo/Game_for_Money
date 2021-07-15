using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    private static RuleManager m_pInstance = null;

    public static RuleManager Instance
    {
        get
        {
            if (!m_pInstance)
            {
                m_pInstance = FindObjectOfType(typeof(RuleManager)) as RuleManager;

                if (m_pInstance == null)
                    Debug.Log("Cannot Find RuleManager Instnace...");
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


    [SerializeField] private int m_iMyTeam;
    [SerializeField] private Color[] m_arrTeamColor;

    private List<Team> m_listTeam;
    private Team m_pEmptyTeam;

    public List<Team> listTeam { get { return m_listTeam; }}
    public Team EmptyTeam { get { return m_pEmptyTeam; } }
    public Team MyTeam { get { return m_listTeam[m_iMyTeam]; } }

    public bool Init()
    {
        m_listTeam = new List<Team>();
        m_pEmptyTeam = new Team();
        int iTeamSize = m_arrTeamColor.Length;

        for (int i = 0; i < iTeamSize; i++)
        {
            m_listTeam.Add(new Team(i, m_arrTeamColor[i]));
            Debug.Log(m_arrTeamColor[i]);
        }

        return true;
    }

}
