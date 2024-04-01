using TMPro;
using UnityEngine;

// The circle collider is for whether the element is being hovered or not.
[RequireComponent(typeof(CircleCollider2D))]
public class DraggableComponent : CursorFollowComponent
{
    // is this element currently being hovered?
    private bool m_isHovered = false;

    private bool m_isDragging = false;

    private int m_goldValue;
    private int m_pValue;

    public int getGoldValue() { return m_goldValue; }
    public int getpValue() { return m_pValue; }

    public TextMeshProUGUI m_value;
    public void setValue(int value, int pValue) {
        m_goldValue = value;
        m_pValue = pValue;
        m_value.text = m_goldValue.ToString();
    }

    // while the "Cursor" gameobject (which is just where the user's cursor is) is "hovering" over
    // this element, we want to check to see if the player is trying to move it.
    private void OnTriggerEnter2D(Collider2D collision) => m_isHovered = true;
    private void OnTriggerExit2D(Collider2D collision) => m_isHovered = false;

    protected override void Update()
    {
        // if we are hovered, the mouse was just clicked, and was just clicked on us, we should start being dragged.
        if (m_isHovered
            && Input.GetMouseButtonDown(0)
            && UIHelpers.GetTopmostElementFromMousePos().GetInstanceID() == this.gameObject.GetInstanceID())
        {
            m_isDragging = true;
        }

        // if we are being dragged, we follow the mouse
        if (m_isDragging) FollowMouse();

        // if we are no longer being hovered or the mouse is lifted, we are no longer dragging
        if (!m_isHovered || Input.GetMouseButtonUp(0)) m_isDragging = false;
    }

    public bool isPlaced()
    {
        return !m_isDragging;
    }
}
