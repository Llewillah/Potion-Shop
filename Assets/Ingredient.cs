using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ingredient : MonoBehaviour, IClickable
{
    IngrediantScriptable ingreScrip;
    TargetJoint2D joint;

    private void Start()
    {
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
            gameObject.SetActive(false);
        }
    }

    public void SetIngredient(IngrediantScriptable scrip) 
    {
        ingreScrip = scrip;
        GetComponent<SpriteRenderer>().sprite = ingreScrip.sprite;
        gameObject.SetActive(true);
    }
}
