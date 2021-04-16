using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore.Examples.HelloAR;

public class DrawerScript : MonoBehaviour
{
    [SerializeField]
    private HelloARController arController;

    [SerializeField]
    private GameObject drawerPanel;

    [Space]

    [SerializeField]
    private Animator drawerAnimator;

    private void Start()
    {
        //Hide the panel at start in case it's left active
        HideDrawerPanel();
    }

    /// <summary>
    /// Sets the drawel panel active
    /// </summary>
    public void ShowDrawerPanel()
    {
        //drawerPanel.SetActive(true);
        drawerAnimator.SetBool("DrawerOpen", true);
    }

    /// <summary>
    /// Disables the drawer panel
    /// </summary>
    public void HideDrawerPanel()
    {
        //drawerPanel.SetActive(false);
        drawerAnimator.SetBool("DrawerOpen", false);
    }

    /// <summary>
    /// Sets the given object as the placement object, hides the drawer panel and enables placement mode
    /// </summary>
    /// <param name="gameObject"></param>
    public void ChooseObject (GameObject gameObject)
    {
        arController.InstantPlacementPrefab = gameObject;
        HideDrawerPanel();
        arController.placementMode = true;
        arController.SetPlacementObjectsActive(true);
    }
}