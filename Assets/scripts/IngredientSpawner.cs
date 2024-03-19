using UnityEngine;

// The class that handles the spawning of potion ingredients via the Draw Ingredients buton
public class IngredientSpawner : MonoBehaviour
{
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
    }
}
