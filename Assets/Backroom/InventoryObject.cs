using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InventoryObject : MonoBehaviour, IClickable
{
    List<int> mix;
    int quality;

    Rigidbody2D rb;
    TargetJoint2D joint;
    bool reset = false;
    bool deposit = false;
    Vector2 invPos;

    private void Start()
    {
        joint = GetComponent<TargetJoint2D>();
        joint.enabled = false;
        InventoryManager.instance.AddUnused(this);
        rb = GetComponent<Rigidbody2D>();
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
        gameObject.SetActive(true);
    }
    public void OnClick()
    {
        joint.enabled = true;
        joint.anchor = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Mouse.current.position.value));
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void CancelClick()
    {
        joint.enabled = false;
        if (reset)
        {
            ResetObj();
        }

        transform.position = invPos;
        transform.rotation = Quaternion.identity;
        rb.bodyType = RigidbodyType2D.Static;
    }

    void ResetObj() 
    {
        if (deposit) 
        {
            CustomerManager.instance.StartRecievePotion(mix);
        }

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
                deposit = true;
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
                deposit = true;
                reset = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        reset = false;
        deposit = false;
    }
}
