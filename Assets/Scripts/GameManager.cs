using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_pInstance = null;

    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
            if (!m_pInstance)
            {
                m_pInstance = FindObjectOfType(typeof(GameManager)) as GameManager;

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

    [SerializeField] private float m_fDeltaTime = 0f;
    [SerializeField] private float m_fTimeScale = 1f;

    private void Start()
    {
        if (!MapManager.Instance.Init()) return;
        if (!RuleManager.Instance.Init()) return;
        if (!CharacterManager.Instance.Init()) return;
    }

    private void Update()
    {
        m_fDeltaTime = m_fTimeScale * Time.deltaTime;
    }

}
