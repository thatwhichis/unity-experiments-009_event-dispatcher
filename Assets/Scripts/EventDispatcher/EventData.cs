using System; // Convert
using System.Collections.Generic; // List
using UnityEngine; // GameObject

/// <summary>
/// Generic EventData class for data flexibility when using EventDispatcher.
/// Built using the PlayerPrefs API as reference.
/// </summary>
public class EventData
{
    private List<string> m_keys;
    private List<object> m_values;

    public EventData()
    {
        InitializeLists();
    }

    public EventData(string name)
    {
        InitializeLists();

        SetData("name", name);
    }

    private void InitializeLists()
    {
        m_keys = new List<string>();
        m_values = new List<object>();
    }

    #region Private Instance Methods
    private T GetValue<T>(string key, T defaultValue)
    {
        if (m_keys.Contains(key))
        {
            defaultValue = (T)m_values[m_keys.IndexOf(key)];
        }
        else
        {
            SetData(key, defaultValue);
        }

        return defaultValue;
    }
    #endregion

    #region Public EventData Management Methods
    // Summary: Removes all m_keys and m_values from the preferences.
    // Use with caution.
    public void DeleteAll()
    {
        for (int i = m_keys.Count - 1; i > -1; i--)
        {
            m_keys.RemoveAt(i);
            m_values.RemoveAt(i);
        }
    }
    // Summary: Removes key and its corresponding value from the preferences.
    //
    // Parameters:
    //   key:
    public void DeleteKey(string key)
    {
        if (m_keys.Contains(key))
        {
            int i = m_keys.IndexOf(key);
            m_keys.RemoveAt(i);
            m_values.RemoveAt(i);
        }
    }
    // Summary: Returns the value corresponding to key in the preference file
    // if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public bool GetBool(string key, bool defaultValue)
    {
        return GetValue(key, defaultValue);
    }
    // Summary: Returns the value corresponding to key in the preference file
    // if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public bool GetBool(string key)
    {
        return GetBool(key, false);
    }
    // Summary: Returns the value corresponding to key in the preference file
    // if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public int GetInt(string key, int defaultValue)
    {
        return GetValue(key, defaultValue);
    }
    // Summary: Returns the value corresponding to key in the preference file
    // if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public int GetInt(string key)
    {
        return GetInt(key, 0);
    }
    // Summary: Returns the value corresponding to key in the preference file
    // if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public float GetFloat(string key, float defaultValue)
    {
        return GetValue(key, defaultValue);
    }
    // Summary: Returns the value corresponding to key in the preference file
    // if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public float GetFloat(string key)
    {
        return GetFloat(key, 0);
    }
    // Summary: Returns the value corresponding to key in the preference file
    // if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public GameObject GetGameObject(string key, GameObject defaultValue)
    {
        return GetValue(key, defaultValue);
    }
    // Summary: Returns the value corresponding to key in the preference file
    // if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public GameObject GetGameObject(string key)
    {
        return GetGameObject(key, null);
    }
    // Summary: Returns the value corresponding to key in the preference file
    // if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public object GetObject(string key, object defaultValue)
    {
        return GetValue(key, defaultValue);
    }
    // Summary: Returns the value corresponding to key in the preference file
    // if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public object GetObject(string key)
    {
        return GetObject(key, null);
    }
    // Summary: Returns the value corresponding to key in the preference file
    // if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public string GetString(string key, object defaultValue)
    {
        return (string)GetValue(key, defaultValue);
    }
    // Summary: Returns the value corresponding to key in the preference file
    // if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public string GetString(string key)
    {
        return GetString(key, null);
    }
    // Summary: Returns true if key exists in the preferences.
    //
    // Parameters:
    //   key:
    public bool HasKey(string key)
    {
        return m_keys.Contains(key);
    }
    // Summary: Sets the value of the preference identified by key.
    //
    // Parameters:
    //   key:
    //
    //   value:
    public void SetData(string key, object value)
    {
        if (m_keys.Contains(key))
        {
            m_values[m_keys.IndexOf(key)] = value;
        }
        else
        {
            m_keys.Add(key);
            m_values.Add(value);
        }
    }
    #endregion
}
