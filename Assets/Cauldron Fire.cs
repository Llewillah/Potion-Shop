using UnityEngine;

public class CauldronFire : MonoBehaviour, IClickable
{
    public Cauldron caul;
    public void OnClick() 
    {
        caul.ToggleFlame();
    }

    public void CancelClick() { }
}
