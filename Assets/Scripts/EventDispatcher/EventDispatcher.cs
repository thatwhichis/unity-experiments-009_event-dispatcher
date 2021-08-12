using System; // Action
using System.Collections.Generic; // Dictionary
using UnityEngine;

public static class EventDispatcher
{
    internal static bool DebugEnabled = false;

    private static Dictionary<string, Action<EventData>>
        m_stringActionEventDataDictionary =
        new Dictionary<string, Action<EventData>>();

    public static bool AddEventListener(string eventName, Action<EventData> listener)
    {
        if (m_stringActionEventDataDictionary
            .TryGetValue(eventName, out Action<EventData> action))
        {
            // Removing and adding the delegate ensures it is not duplicated
            action -= listener;
            action += listener;

            m_stringActionEventDataDictionary[eventName] = action;
        }
        else
        {
            action += listener;
            m_stringActionEventDataDictionary.Add(eventName, action);
        }

        return true;
    }

    // eventData must contain "name" property of event to dispatch
    public static void DispatchEvent(EventData eventData)
    {
        string eventName = eventData.GetString("name");

        if (eventName != null)
        {
            if (m_stringActionEventDataDictionary
                .TryGetValue(eventName, out Action<EventData> action))
            {
                // action should never be null in this configuration,
                // but we'll check anyway
                action?.Invoke(eventData);
            }
            else
            {
                if (DebugEnabled)
                    Debug.Log("EventDispatcher.DispatchEvent(EventData): " +
                    "No matching name found in events: " + eventName);
            }
        }
        else
        {
            if (DebugEnabled)
                Debug.Log("EventDispatcher.DispatchEvent(EventData): " +
                "No name found in eventData");
        }
    }

    public static bool RemoveEventListener(string eventName,
        Action<EventData> listener)
    {
        bool ret = false;

        if (m_stringActionEventDataDictionary
            .TryGetValue(eventName, out Action<EventData> action))
        {
            action -= listener;

            // Have to pass the action back; value type
            m_stringActionEventDataDictionary[eventName] = action;

            if (action == null)
            {
                m_stringActionEventDataDictionary.Remove(eventName);
            }

            ret = true;
        }
        else
        {
            if (DebugEnabled)
                Debug.Log("EventDispatcher.RemoveEventListener(string, Action<EventData>): " +
                "Event not removed: no matching event name found in events.");
        }

        return ret;
    }
}
