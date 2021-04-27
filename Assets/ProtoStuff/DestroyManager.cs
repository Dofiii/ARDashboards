using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DestroyManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of this class
    /// </summary>
    public static DestroyManager INSTANCE;

    private void Awake()
    {
        if (INSTANCE == null) //Make sure that only one instance shall exist
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [SerializeField]
    private Text destroyText;

    [HideInInspector]
    public bool destroyModeOn = false;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (destroyModeOn && Input.touchCount > 0)
        {
            RaycastHit hit;
            Dashboard foundDashboard = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                foundDashboard = hit.collider.GetComponentInParent<Dashboard>();
            }

            if (foundDashboard != null)
            {
                foundDashboard.OnDestroyClick();

                TurnDestroyModeOff();
            }
        }
    }

    public void ToggleDestroyMode()
    {
        if (destroyModeOn)
        {
            TurnDestroyModeOff();
        }
        else
        {
            TurnDestroyModeOn();
        }
    }

    public void TurnDestroyModeOn()
    {
        destroyModeOn = true;
        destroyText.gameObject.SetActive(true);
    }

    public void TurnDestroyModeOff()
    {
        destroyModeOn = false;
        destroyText.gameObject.SetActive(false);
    }
}
