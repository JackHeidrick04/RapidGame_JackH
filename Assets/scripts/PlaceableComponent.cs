using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class PlaceableComponent : MonoBehaviour
{
    private int m_fullness;
    private int m_currentGoldValue;
    private int m_currentPValue;


    [SerializeField] private UnityEvent<int> OnDayChanged;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<DraggableComponent>(out var component)){ 
            if(component.isPlaced())
            {
                m_currentGoldValue += component.getGoldValue();
                m_currentPValue += component.getpValue();
                m_fullness += 1;
                if (m_fullness == 3)
                {
                    GameManager.Instance.setGold(m_currentGoldValue);
                    GameManager.Instance.setPrestige(m_currentPValue);
                    m_fullness = 0;
                    GameManager.Instance.incrementDays();
                    OnDayChanged?.Invoke(GameManager.Instance.getDay());
                }
                Destroy(component.gameObject);
            }
        }
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
