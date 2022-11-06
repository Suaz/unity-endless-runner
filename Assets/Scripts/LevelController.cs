using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject[] cityBlocks;
    [SerializeField] int minBlock = 3;

    public static LevelController Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        for(int i=0; i< minBlock; i++)
        {
            AddBlock(i);
        }
    }

    public void AddBlockAtEnd()
    {
        AddBlock(minBlock - 1);
    }

    public void AddBlock(int position)
    {

        Debug.Log(position);
        Instantiate(cityBlocks[0], new Vector3(0, 0, position * 12), Quaternion.identity);
    }
}
