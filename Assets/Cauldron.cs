using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cauldron : MonoBehaviour, IClickable
{
    public float cookTime;
    bool cooking = false;
    float timer = 0;

    List<int> curMix = new List<int>();
    public GameObject timeObj;
    SpriteRenderer timeObjSprite;

    private void Start()
    {
        timeObjSprite = timeObj.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooking && timer < cookTime * 2) 
        {
            timer += Time.deltaTime;
            timeObj.transform.localScale = new Vector2(timer / (cookTime * 2), 1);

            if (timer < cookTime / 3)
            {
                timeObjSprite.color = Color.red;
            }
            else if (timer < cookTime)
            {
                timeObjSprite.color = Color.yellow;
            }
            else if (timer > cookTime * 2)
            {
                timeObjSprite.color = Color.red;
            }
            else if (timer > cookTime + cookTime / 2)
            {
                timeObjSprite.color = Color.yellow;
            }
            else
            {
                timeObjSprite.color = Color.green;
            }
        }
    }

    public void AddToMix(int index) 
    {
        if (!cooking)
        {
            curMix.Add(index);            
        }
    }

    public void ToggleFlame() 
    {
        if (curMix.Count > 0)
        {
            cooking ^= true;
        }
    }

    void ResetCooking() 
    {
        cooking = false;
        timer = 0;
        timeObj.transform.localScale = new Vector2(0, 1);
        curMix.Clear();
    } 

    public void FinishCook() 
    {
        int quality = 0;

        if (timer < cookTime / 3)
        {
            quality = 0;
        }
        else if (timer < cookTime) 
        {
            quality = 1;
        }
        else if (timer > cookTime * 2)
        {
            quality = 0;
        }
        else if (timer > cookTime + cookTime / 2)
        {
            quality = 1;
        }
        else
        {
            quality = 2;
        }

        if (OutputManager.instance.DoOutput(curMix, quality))
        {
            ResetCooking();
        }
    }

    public void OnClick() 
    {
        if (!cooking && timer > 0)
        {
            FinishCook();
        }
    }

    public void CancelClick() 
    { 
    
    }
}
