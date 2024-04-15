using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sellspot : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<DraggableComponent>(out var component))
        {
            if (component.isPlaced())
            {
                GameManager.Instance.setGold(GameManager.Instance.getGold() + component.getGoldValue());
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
