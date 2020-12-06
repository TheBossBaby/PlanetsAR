using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRAMSize : MonoBehaviour
{
    public GameObject m_ARStartButton, m_3DStartButton;

    void Start()
    {
        int m_RAMSize = SystemInfo.systemMemorySize;

        if (m_RAMSize > 2048)
        {
            m_ARStartButton.SetActive(true);
            m_3DStartButton.SetActive(false);
        }
        else
        {
            m_ARStartButton.SetActive(false);
            m_3DStartButton.SetActive(true);
        }
    }
}
