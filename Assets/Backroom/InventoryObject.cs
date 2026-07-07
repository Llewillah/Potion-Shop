using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InventoryObject : MonoBehaviour, IClickable
{
    List<int> mix;
    int quality;

    TargetJoint2D joint;
    bool reset = false;

    Vector2 invPos;

    private void Start()
    {
        joint = GetComponent<TargetJoint2D>();
        joint.enabled = false;
        InventoryManager.instance.AddUnused(this);
    }
    private void Update()
    {
        if (joint.enabled)
        {
            joint.target = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        }
    }

    public void SetInvObj(List<int> mix, int quality, Vector2 pos) 
    {
        this.mix = mix;
        this.quality = quality;
        invPos = pos;
    }
    public void OnClick()
    {
        joint.enabled = true;
        joint.anchor = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Mouse.current.position.value));
    }

    public void CancelClick()
    {
        joint.enabled = false;
        if (reset)
        {
            ResetObj();
        }
        else 
        {
            transform.position = invPos;
        }
    }

    void ResetObj() 
    {
        quality = 0;
        mix.Clear();
        InventoryManager.instance.AddUnused(this);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!joint.enabled)
        {
            if (collision.gameObject.CompareTag("Bin"))
            {
                ResetObj();
            }
            else if (collision.gameObject.CompareTag("Deposit"))
            {
                ResetObj();
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Bin"))
            {
                reset = true;
            }
            else if (collision.gameObject.CompareTag("Deposit"))
            {
                reset = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        reset = false;
    }
}
