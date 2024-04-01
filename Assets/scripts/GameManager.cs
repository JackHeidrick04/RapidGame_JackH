using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int currentGold = 0;
    private int currentPrestige = 0;
    private int currentDay = 1;

    [SerializeField] private UnityEvent<int> OnGoldChanged;
    [SerializeField] private UnityEvent<int> OnPrestigeChanged;

    public void incrementDays()
    {
        currentDay++;
    }
    public int getGold() { return currentGold; }
    public int getPrestige() {  return currentPrestige; }
    public int getDay() { return currentDay;}
    public void setGold(int gold) {  
        currentGold = gold; 
        OnGoldChanged?.Invoke(gold);
    }
    public void setPrestige(int prestige) {  
        currentPrestige = prestige; 
        OnPrestigeChanged?.Invoke(prestige);
    }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
