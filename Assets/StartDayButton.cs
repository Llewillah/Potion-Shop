using UnityEngine;

public class StartDayButton : MonoBehaviour, IClickable
{

    public CustomerManager cm;
    public void OnClick() 
    { 
        cm.StartDay();
    }

    public void CancelClick() { }
}
