using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager m_pInstance = null;

    public static CharacterManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!m_pInstance)
            {
                m_pInstance = FindObjectOfType(typeof(CharacterManager)) as CharacterManager;

                if (m_pInstance == null)
                    Debug.Log("Cannot Find CharacterManager Instnace...");
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

    [SerializeField] private List<CharacterStatus> m_listStatus;
    [SerializeField] private GameObject m_goCharacterPrefab;

    private Dictionary<string, int> m_dicKey;
    private List<Character> m_listCharacter;

    private List<CharacterStatus> m_listPickedCharacter;
    private CharacterStatus m_pSelectCharacter;

    // get set
    public List<CharacterStatus> ListStatus { get { return m_listStatus; } }

    public bool Init()
    {
        int num = 0;
        m_dicKey = new Dictionary<string, int>();
        m_listCharacter = new List<Character>();
        m_listPickedCharacter = new List<CharacterStatus>();

        foreach (var item in m_listStatus)
        {
            m_dicKey[item.m_strName] = num++;
        }

        for(int i = 0; i < 8; i++)
        {
            m_listPickedCharacter.Add(m_listStatus[i % m_listStatus.Count]);
        }

        m_pSelectCharacter = m_listPickedCharacter[0];

        return true;
    }

    public Transform CreateCharacter(CharacterStatus _pState, Vector2Int _tGamePos)
    {
        GameObject goCharacter = Instantiate(m_goCharacterPrefab, MapManager.Instance.ToWorldPos(_tGamePos), Quaternion.identity);
        Character cpCharacter = goCharacter.GetComponent<Character>();
        cpCharacter.Status = _pState;
        cpCharacter.GamePos = _tGamePos;
        m_listCharacter.Add(cpCharacter);
        return goCharacter.transform;
    }

    public Transform CreateCharacterWithSelect (Vector2Int _tGamePos)
    {
        return CreateCharacter(m_pSelectCharacter, _tGamePos);
    }

    public void CharacterSelectBtn(int _iSelect)
    {
        m_pSelectCharacter = m_listPickedCharacter[_iSelect];
    }
}
