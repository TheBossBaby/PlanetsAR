using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using TMPro;

public class PlanetManager : MonoBehaviour
{
    public GameObject[] m_Planets;

    public GameObject m_ChoosePlanetMenu, m_BottomMenu, m_TopMenu;
    public GameObject m_PlanetsParentGameobject;
    public GameObject m_MovePlanetButton, m_RotatePlanetButton;

    public TMP_Text m_PlanetName;

    private static bool m_MovePlanet = false;

    void Start()
    {
        m_MovePlanet = false;
        m_MovePlanetButton.SetActive(true);
        m_RotatePlanetButton.SetActive(false);

        DeactivatePlanets();

        m_PlanetsParentGameobject.GetComponent<SwipeRotate>().enabled = true;
        m_PlanetsParentGameobject.GetComponent<LeanPinchScale>().enabled = true;
        m_PlanetsParentGameobject.GetComponent<LeanDragTranslate>().enabled = false;
    }

    public void OpenPlanetsMenu()
    {
        DeactivatePlanets();

        m_PlanetName.text = "";

        m_ChoosePlanetMenu.SetActive(true);
        m_BottomMenu.SetActive(false);
        m_TopMenu.SetActive(false);
    }

    public void SetActivePlanet(int planetIndex)
    {
        DeactivatePlanets();

        m_Planets[planetIndex].SetActive(true);
        m_PlanetName.text = "" + m_Planets[planetIndex].name;

        m_ChoosePlanetMenu.SetActive(false);
        m_BottomMenu.SetActive(true);
        m_TopMenu.SetActive(true);
    }

    private void DeactivatePlanets()
    {
        for (int i = 0; i < m_Planets.Length; i++)
        {
            m_Planets[i].SetActive(false);
        }
    }

    public void ToggleMoveRotatePlanet()
    {
        m_MovePlanet = !m_MovePlanet;

        if (m_MovePlanet)
        {
            m_MovePlanetButton.SetActive(false);
            m_RotatePlanetButton.SetActive(true);

            m_PlanetsParentGameobject.GetComponent<SwipeRotate>().enabled = false;
            m_PlanetsParentGameobject.GetComponent<LeanDragTranslate>().enabled = true;
        }
        else
        {
            m_MovePlanetButton.SetActive(true);
            m_RotatePlanetButton.SetActive(false);

            m_PlanetsParentGameobject.GetComponent<SwipeRotate>().enabled = true;
            m_PlanetsParentGameobject.GetComponent<LeanDragTranslate>().enabled = false;
        }
    }
}
