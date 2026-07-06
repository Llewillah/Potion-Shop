using UnityEngine;

public class BookButtons : MonoBehaviour, IClickable
{
    BookScript bs;
    int index;

    public void OnClick() 
    {
        bs.CreateIngredient(index);
    }

    public void CancelClick() 
    { 
        
    }

    public void SetIndex(int i, BookScript b) 
    {
        index = i;
        bs = b; 
    }

}
