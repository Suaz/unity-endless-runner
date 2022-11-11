using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    GameObject[] cityBlocks;

    [SerializeField]
    int minBlock = 3;

    [SerializeField]
    int currentRail = 1;

    [SerializeField]
    GameObject player;

    [SerializeField]
    int speed;

    public static LevelController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < minBlock; i++)
        {
            AddBlock(i);
        }
        player.transform.position = new Vector3(getRoute(1), 4, -9);
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < minBlock; i++)
        {
            Gizmos.DrawWireCube(new Vector3(0, 0, (i * 12) - 6), new Vector3(12, 1, 12));
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(-3, 0, -6), new Vector3(2, 1, 12));
        Gizmos.DrawWireCube(new Vector3(-1, 0, -6), new Vector3(2, 1, 12));
        Gizmos.DrawWireCube(new Vector3(1, 0, -6), new Vector3(2, 1, 12));
        Gizmos.DrawWireCube(new Vector3(3, 0, -6), new Vector3(2, 1, 12));

        Gizmos.DrawWireSphere(new Vector3(currentRail, 0, -9), 0.5f);
        Gizmos.DrawWireSphere(new Vector3(currentRail, 2, -9), 0.5f);
    }

    private int getRoute(int route)
    {
        switch (route)
        {
            case 1:
                return -3;
            case 2:
                return -1;
            case 3:
                return 1;
            case 4:
                return 3;
        }
        return 1;
    }

    public void AddBlockAtEnd()
    {
        AddBlock(minBlock - 1);
    }

    public void AddBlock(int position)
    {
        Instantiate(cityBlocks[0], new Vector3(0, 0, position * 12), Quaternion.identity);
    }
}
