using UnityEngine;

// this means that this MonoBehaviour component can only go on UI elements.
[RequireComponent(typeof(RectTransform))]
public class CursorFollowComponent : MonoBehaviour
{
    [SerializeField, Tooltip("how fast should we smoothly move towards the cursor?")]
    private float m_lerpRate = 0.0125f;

    [SerializeField, Tooltip("the name of the canvas gameobject to source the rect transform from.")]
    private string m_canvasName = "Canvas";

    // the cached rect transform to use to convert the mouse coordinate to the proper screen space.
    private RectTransform m_canvasTransform;

    // the cached rect transform of the ui element
    private RectTransform m_rectTransform;

    private void Awake()
    {
        // get the Canvas' rect transform.
        GameObject canvas = GameObject.Find(m_canvasName);

        if (!canvas)
        {
            Debug.LogError("GameObject by name {m_canvasName} could not be found! Do you have it in the scene hierarchy?");
            return;
        }

        m_canvasTransform = canvas.transform as RectTransform;

        // UI elements have a transform like every other gameobject, but they have a special subclass
        // called RectTransform that allows for some UI-specific stuff.
        m_rectTransform = transform as RectTransform;
    }

    /// <summary>
    /// The basic Update loop. Exposed for modification in subclasses.
    /// </summary>
    protected virtual void Update()
    {
        // we always want to follow the mouse.
        FollowMouse();
    }

    /// <summary>
    /// When called, smoothly moves this element to the mouse position
    /// </summary>
    protected void FollowMouse()
    {
        // transform the mouse's screen point location into the canvas' local space.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            m_canvasTransform, 
            Input.mousePosition, 
            null, // we don't have an overlay/world space canvas, so we don't need to pass in a camera
            out Vector2 mouse_pos);

        // normally, we would multiply m_lerpRate by Time.deltaTime to keep it framerate-independent, but
        // that doesn't matter in this case since the framerate-independence of the element is
        // never significant to the actual gameplay.
        m_rectTransform.anchoredPosition =
            Vector2.Lerp(
                m_rectTransform.anchoredPosition,
                mouse_pos,
                m_lerpRate);
    }
}
