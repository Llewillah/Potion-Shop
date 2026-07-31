using UnityEngine;

public class RoomChangeButton : MonoBehaviour, IClickable
{
    public Transform cam, frontRoom, backRoom;
    public void OnClick() 
    {


        if ((Vector2)cam.position == (Vector2)frontRoom.position)
        {
            cam.position = new Vector3(backRoom.position.x, backRoom.position.y, -10);
        }
        else 
        { 
            cam.position = new Vector3(frontRoom.position.x, frontRoom.position.y, -10);
        }
    }

    public void CancelClick() { }
}
