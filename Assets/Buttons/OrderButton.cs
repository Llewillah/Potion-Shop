using UnityEngine;

public class OrderButton : MonoBehaviour, IClickable
{
    public CustomerManager cm; 
    public void OnClick() 
    {
        cm.StartCustomerRequest();
    }

    public void CancelClick() { }
}
