using UnityEngine;
using System.Collections.Generic;

public class CustomerAgent : MonoBehaviour, IClickable
{
    public int speed;
    Vector2 startPos;
    Vector2 targetPos;
    public List<int> requestedMix = new List<int>();

    private void Update()
    {
        if (CheckDist())
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        }
    }

    public void SetTarget(Vector2 tar) 
    {
        startPos = transform.position;
        targetPos = tar;
    }

    public void SetMix(List<int> mix) 
    { 
        requestedMix = mix;
    }

    public bool CheckDist() 
    {
        return (targetPos - (Vector2)transform.position).magnitude > 0.1;
    }
    public void OnClick() 
    { 
        
    }

    public void CancelClick() 
    { 
    
    }
}
