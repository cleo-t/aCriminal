using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject tree;
    [SerializeField]
    private float treeRadius = 3.5f;
    [SerializeField]
    private float spawnRadius = 25;
    [SerializeField]
    private float spread = 0.2f;
    [SerializeField]
    private List<string> layerMask;

    void Start()
    {
        this.SpawnTrees(this.RealTreePoints(this.FlatTreePoints()));
    }

    private List<Vector2> FlatTreePoints()
    {
        List<Vector2> result = new List<Vector2>();
        for (float x = -spawnRadius + treeRadius; x < spawnRadius - treeRadius; x += (treeRadius * 2) + this.RandomSpreadValue())
        {
            float arcY = this.ArcY(x);
            for (float y = -arcY + treeRadius; y < arcY - treeRadius; y += (treeRadius * 2) + this.RandomSpreadValue())
            {
                result.Add(new Vector2(x, y));
            }
        }
        return result;
    }

    private List<Vector3> RealTreePoints(List<Vector2> flatPoints)
    {
        List<Vector3> result = new List<Vector3>();
        int layerMask = this.GetMask();
        foreach(Vector2 pos in flatPoints)
        {
            Vector3 origin = this.transform.position + (this.transform.right * pos.x) + (this.transform.forward * pos.y);
            Ray ray = new Ray(origin, Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, layerMask))
            {
                result.Add(hit.point);
                continue;
            }
        }
        return result;
    }

    private void SpawnTrees(List<Vector3> points)
    {
        foreach(Vector3 pos in points)
        {
            Instantiate(this.tree, pos, Quaternion.identity, this.transform);
        }
    }

    private float ArcY(float x)
    {
        return Mathf.Sqrt(Mathf.Pow(this.spawnRadius, 2) - Mathf.Pow(x, 2));
    }

    private int GetMask()
    {
        return LayerMask.GetMask(this.layerMask.ToArray());
    }

    private float RandomSpreadValue()
    {
        return Random.value * this.spread * this.treeRadius * 2;
    }
}
