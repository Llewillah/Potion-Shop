using UnityEngine;

public class StartDayButton : MonoBehaviour, IClickable
{
    public Transform frontRoomPos;
    public CustomerManager cm;
    public BookScript bs;
    public Transform cam;
    public void OnClick() 
    { 
        cm.StartDay();
        bs.StartDay();
        gameObject.SetActive(false);
        cam.position = new Vector3(frontRoomPos.position.x, frontRoomPos.position.y, -10);
    }

    public void CancelClick() { }
}
