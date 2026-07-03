using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public GameObject[] customerObjs;
    float timer = 0, customerSpawnRate;
    int curCustomer, totalCustomers, minRequests, maxRequests;

    private void Start()
    {
        
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > customerSpawnRate && curCustomer < totalCustomers) 
        {
            timer = 0;
            SpawnCustomer();
        }
    }

    void SpawnCustomer() 
    {
        int numRequests = Random.Range(minRequests, maxRequests);
        curCustomer++;
    }

    void StartDay() 
    {
        totalCustomers = ImportantInfo.numCustomers[ImportantInfo.level];
        minRequests = ImportantInfo.levelsRequestMin[ImportantInfo.level];
        maxRequests = ImportantInfo.levelsRequestMax[ImportantInfo.level];
        customerSpawnRate = ImportantInfo.customerSpawnRate[ImportantInfo.level];
    }
    void EndDay() 
    {
        ImportantInfo.level++;
    }
}
