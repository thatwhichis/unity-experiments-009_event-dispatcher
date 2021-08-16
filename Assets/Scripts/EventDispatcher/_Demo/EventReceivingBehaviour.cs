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
        int i = eventData.GetInt("int");
        float f = eventData.GetFloat("float");
        GameObject gO = eventData.GetGameObject("gameObject");
        string s = eventData.GetString("string", "testing");

        if (eventData.GetBool("bool"))
        {
            Debug.Log(
                string.Concat(
                eventData.GetString("name"), ": ",
                eventData.GetFloat("time"),
                ", i: ", i,
                ", f: ", f,
                ", gO: ", gO.name,
                ", s: ", s
            ));

            eventData.DeleteKey("time");

            if (eventData.HasKey("time"))
            {
                Debug.Log("DeleteKey failed.");
            }
        }
    }

    public void lateUpdate(EventData eventData)
    {
        Debug.Log(
            string.Concat(
            eventData.GetString("name"), ": ",
            eventData.GetFloat("time")
        ));
    }
}
