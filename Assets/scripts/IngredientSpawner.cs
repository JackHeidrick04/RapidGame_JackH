using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// The class that handles the spawning of potion ingredients via the Draw Ingredients buton
public class IngredientSpawner : MonoBehaviour
{
    private struct IngredientData
    {
        public int Gold;
        public int Prestige;
        public IngredientData(int gold, int prestige)
        {
            Gold = gold;
            Prestige = prestige;
        }
    }

    public RectTransform Target;
    public AnimationCurve FrequencyCurve;
    private List<IngredientData> data;

    [SerializeField, Tooltip("the ingredient prefab to be spawned.")] 
    private GameObject m_prefab;

    [SerializeField, Tooltip("the transform of the ingredient bar to spawn the ingredients in.")]
    private Transform m_ingredientBar;

    [SerializeField, Tooltip("the rect transform to be made the parent of the spawned gameobjects.")]
    private Transform m_parentTransform;

    /// <summary>
    /// This method is exposed and used by the Button component of the DrawIngredients UI element.
    /// </summary>
    public void Spawn()
    {
        GameObject g = GameObject.Instantiate(m_prefab, m_ingredientBar);
        g.transform.SetParent(m_parentTransform, true);
        (g.transform as RectTransform).anchoredPosition = Target.anchoredPosition + (m_parentTransform.childCount- 1) *Vector2.right*125;
        var component = g.GetComponent<DraggableComponent>();
        var item = data.First<IngredientData>();
        data.RemoveAt(0);
        component.setValue(item.Gold, item.Prestige);
    }

    public void Start()
    {
        data = new();
        for (int i = 1; i < 11; i++) { 
            int value = (int)FrequencyCurve.Evaluate(i);
            for (int j = 1; j <= value*3; j++) {
                data.Add(new IngredientData(i, j));
            }
        }
        data = data.ToArray().OrderBy<IngredientData, float>(Entry => UnityEngine.Random.Range(0, 90)).ToList<IngredientData>();
    }
}
