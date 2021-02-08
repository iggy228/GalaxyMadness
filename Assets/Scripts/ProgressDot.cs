using System.Collections;
using UnityEngine;

public class ProgressDot : MonoBehaviour
{
    public int max = 0;

    private int progress = 0;
    
    private Vector2 position;

    public void AddProgress()
    {
        progress++;
    }

    public void ResetProgress()
    {
        progress = 0;
    }

    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();   
    }

    private void UpdatePosition()
    {
        transform.position = new Vector2(
            max <= 0 ? position.x : position.x + (4f * progress / max),
            position.y
        );
    }
}
