using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject[] cityBlocks;
    [SerializeField] private GameObject[] cityObstacles;
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject gem;
    [SerializeField] private GameObject player;

    [SerializeField] private int minBlock = 3;
    [SerializeField] private int currentRail = 1;
    [SerializeField] private int movementSpeed = 5;
    [SerializeField] private int levelSpeed = 5;

    private int gemCount = 0;

    public void addGem()
    {
        gemCount++;
        Debug.Log(gemCount);
    }

    public int MovementSpeed
    {
        get => movementSpeed;
    }

    public int LevelSpeed
    {
        get => levelSpeed;
        set => levelSpeed = value;
    }


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

    public void AddBlockAtEnd()
    {
        AddBlock(minBlock - 1);
    }

    private void AddBlock(int position)
    {
        GameObject newBlock = Instantiate(cityBlocks[Random.Range(0, 2)], new Vector3(0, 0, position * 12),
            Quaternion.identity);

        for (int i = 0; i < 4; i++)
        {
            Instantiate(
                Random.Range(0f, 1f) > 0.25 ? gem : health,
                newBlock.transform.position
                + new Vector3(Random.Range(-3, 4), 2, Random.Range(-1, -11)),
                Quaternion.identity,
                newBlock.transform
            );
        }

        for (int i = 0; i < 6; i++)
        {
            Instantiate(
                cityObstacles[Random.Range(0, cityObstacles.Length)],
                newBlock.transform.position
                + new Vector3(Random.Range(-3, 4), 0, Random.Range(-1, -11)),
                Quaternion.identity,
                newBlock.transform
            );
        }
    }
}