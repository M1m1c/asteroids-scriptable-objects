using UnityEngine;

public class SplitData
{
    public Vector3 SpawnPos { get; private set; }
    public float Size { get; private set; }
    public SplitData(Vector3 spawnPos, float size)
    {
        SpawnPos = spawnPos;
        Size = size;
    }
}
