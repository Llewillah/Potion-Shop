using System.Collections.Generic;
using UnityEngine;

public class OutputManager: MonoBehaviour
{
    public Vector2 outputPos;
    public float dist;
    public static OutputManager instance;
    Queue<PotionOutput> unused = new Queue<PotionOutput>();
    
    private void Awake()
    {
        instance = this;
    }


    public void AddUnused(PotionOutput outp) 
    { 
        unused.Enqueue(outp);
        outp.gameObject.SetActive(false);
    }

    public bool DoOutput(List<int> mix, int quality) 
    {
        if (unused.Count > 0)
        {
            PotionOutput p = unused.Dequeue();
            p.SetMix(mix, quality);
            p.gameObject.transform.position = new Vector2(outputPos.x - dist * unused.Count, outputPos.y);

            p.gameObject.SetActive(true);
            return true;
        }

        return false;
    }
}
