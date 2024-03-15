using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Unity.PolySpatial.InputDevices;

public class SharedSpaceInputManager : MonoBehaviour
{
    private GameObject m_SelectedObject;

    private void Start()
    {
        EnhancedTouchSupport.Enable();
    }

    private void Update()
    {
        var activeTouches = Touch.activeTouches;
        if (activeTouches.Count > 0)
        {
            var primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(activeTouches[0]);
            var touchPhase = activeTouches[0].phase;

            if (touchPhase == UnityEngine.InputSystem.TouchPhase.Began &&
                (primaryTouchData.Kind == UnityEngine.InputSystem.LowLevel.SpatialPointerKind.IndirectPinch || primaryTouchData.Kind == UnityEngine.InputSystem.LowLevel.SpatialPointerKind.DirectPinch))
            {
                if (primaryTouchData.targetObject != null)
                {
                    m_SelectedObject = primaryTouchData.targetObject;
                }
            }
            else if (touchPhase == UnityEngine.InputSystem.TouchPhase.Moved)
            {
                if (m_SelectedObject != null)
                {
                    m_SelectedObject.transform.position = primaryTouchData.interactionPosition;
                }
            }
            else if (touchPhase == UnityEngine.InputSystem.TouchPhase.Ended || touchPhase == UnityEngine.InputSystem.TouchPhase.Canceled)
            {
                if (m_SelectedObject != null)
                {
                    m_SelectedObject = null;
                }
            }
        }
    }
}
