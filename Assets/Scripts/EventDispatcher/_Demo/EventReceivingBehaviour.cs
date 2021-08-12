using UnityEngine;

public class EventReceivingBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool m_enableEventListeners = false;
    [SerializeField]
    private bool m_enableDispatcherDebugging = false;

    private bool m_enableEventListenersPrevious;

    void Start()
    {
        m_enableEventListenersPrevious = !m_enableEventListeners;
    }

    void Update()
    {
        EventDispatcher.DebugEnabled = m_enableDispatcherDebugging;

        if (m_enableEventListeners != m_enableEventListenersPrevious)
        {
            if (m_enableEventListeners)
            {
                EventDispatcher.AddEventListener("enterFrame", enterFrame);
                EventDispatcher.AddEventListener("lateUpdate", lateUpdate);
            }
            else
            {
                EventDispatcher.RemoveEventListener("enterFrame", enterFrame);
                EventDispatcher.RemoveEventListener("lateUpdate", lateUpdate);
            }

            m_enableEventListenersPrevious = m_enableEventListeners;
        }
    }

    public void enterFrame(EventData eventData)
    {
        Debug.Log("Entering Frame: " + eventData.GetFloat("time"));
    }

    public void lateUpdate(EventData eventData)
    {
        Debug.Log("Late Updating: " + eventData.GetFloat("time"));
    }
}
