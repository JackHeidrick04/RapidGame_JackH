using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHelpers
{
    /// <summary>
    /// Using the mouse's current position, gets the "topmost" game object in the UI that is
    /// hittable by a raycast.
    /// </summary>
    /// <returns></returns>
    public static GameObject GetTopmostElementFromMousePos()
    {
        PointerEventData event_data = new(EventSystem.current);
        event_data.position = Input.mousePosition;
        var results = new List<RaycastResult>();

        // shot the rays into the UI from our event to see what they hit
        EventSystem.current.RaycastAll(event_data, results);

        GameObject topmost = null;
        float highest_sortorder = float.MinValue;

        // iterate through the raycast results to find the topmost UI element
        foreach (var result in results)
        {
            // check if the UI element is visible and has a higher sorting order
            if (result.isValid && result.gameObject.activeInHierarchy && result.sortingOrder > highest_sortorder)
            {
                topmost = result.gameObject;
                highest_sortorder = result.sortingOrder;
            }
        }

        return topmost;
    }
}
