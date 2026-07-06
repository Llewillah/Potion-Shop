using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PotionOutput : MonoBehaviour, IClickable
{
    List<int> mix;
    int quality;
    TargetJoint2D joint;
    bool reset = false;
    private void Start()
    {
        OutputManager.instance.AddUnused(this);
        joint = GetComponent<TargetJoint2D>();
        joint.enabled = false;
    }

    private void Update()
    {
        if (joint.enabled)
        {
            joint.target = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        }
    }

    public void SetMix(List<int> mix, int quality)
    {
        this.mix = mix;
        this.quality = quality;
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
            ResetOutput();
        }
    }

    void ResetOutput()
    {
        reset = false;
        OutputManager.instance.AddUnused(this);
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!joint.enabled)
        {
            if (collision.gameObject.CompareTag("Bin"))
            {
                ResetOutput();
            }
            else if (collision.gameObject.CompareTag("Deposit"))
            {
                ResetOutput();
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
}
