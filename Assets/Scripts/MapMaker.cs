using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MapManager.Instance.CreateMap(transform);   
    }
}
