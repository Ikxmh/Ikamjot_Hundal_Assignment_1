using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float backgroundScrollSpeed = 0.1f;
    private Renderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        render.material.mainTextureOffset = new Vector2(Time.time * backgroundScrollSpeed, 0);
    }
}
