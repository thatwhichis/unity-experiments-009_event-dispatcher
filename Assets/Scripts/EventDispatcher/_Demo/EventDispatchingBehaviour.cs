using UnityEngine;

public class EventDispatchingBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool m_enableEventDispatch = false;

    private EventData m_eventDataEnterFrame;
    private EventData m_eventDataLateUpdate;

    void Start()
    {
        m_eventDataEnterFrame = new EventData("enterFrame");
        m_eventDataLateUpdate = new EventData("lateUpdate");
    }

    void Update()
    {
        if (m_enableEventDispatch)
        {
            m_eventDataEnterFrame.SetData("time", Time.realtimeSinceStartup);
            EventDispatcher.DispatchEvent(m_eventDataEnterFrame);
        }
    }

    private void LateUpdate()
    {
        if (m_enableEventDispatch)
        {
            m_eventDataLateUpdate.SetData("time", Time.realtimeSinceStartup);
            EventDispatcher.DispatchEvent(m_eventDataLateUpdate);
        }
    }
}
