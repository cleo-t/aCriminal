using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class FlowingTexture : MonoBehaviour
{
    [SerializeField]
    private float flowSpeed = 1;
    [SerializeField]
    private Vector2 flowDirection = Vector2.right;

    private Renderer renderer;
    private Vector2 currentOffset;

    void Start()
    {
        this.renderer = this.GetComponent<Renderer>();
        this.currentOffset = this.renderer.material.mainTextureOffset;
    }

    void Update()
    {
        this.currentOffset += this.flowDirection * this.flowSpeed * Time.deltaTime;
        this.renderer.material.SetTextureOffset(Shader.PropertyToID("_BaseMap"), this.currentOffset);
    }
}
