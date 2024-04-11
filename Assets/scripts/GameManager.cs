using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int currentGold = 0;
    private int currentPrestige = 0;
    private int currentDay = 1;

    [SerializeField] private UnityEvent<int> OnGoldChanged;
    [SerializeField] private UnityEvent<int> OnPrestigeChanged;
    [SerializeField] private IngredientSpawner bitch;

    public void incrementDays()
    {
        currentDay++;
        bitch.setIngredientsSpawned(0);
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
        if (currentDay == 11)
        {
            PlayerPrefs.SetInt("Gold", getGold());
            PlayerPrefs.SetInt("Prestige", getPrestige());
            PlayerPrefs.SetInt("Score", getGold() + getPrestige());

            SceneManager.LoadScene(1);
        }
    }
}
