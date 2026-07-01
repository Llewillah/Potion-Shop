using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ingredient : MonoBehaviour, IClickable
{
    public IngrediantScriptable ingreScrip;
    Rigidbody2D rb;
    TargetJoint2D joint;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = ingreScrip.sprite;
        rb = GetComponent<Rigidbody2D>();
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
    public void OnClick() 
    {
        joint.enabled = true;
        joint.anchor = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Mouse.current.position.value));
    }

    public void CancelClick() 
    {
        joint.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Cauldron>(out Cauldron c))
        {
            c.AddToMix(ingreScrip.index);
            Destroy(gameObject);
        }
    }
}
