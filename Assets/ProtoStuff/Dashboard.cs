using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashboard : MonoBehaviour
{
    public string dashboardName = "Dashboard";

    public string creationMessage = "Dashboard has been created.";

    [Space]

    public string destroyMessage = "Dashboard has been removed.";

    private NotificationManager notificationManager;

    /*private void OnMouseDown()
    {
        if (DestroyManager.INSTANCE.destroyModeOn)
        {
            DestroyManager.INSTANCE.TurnDestroyModeOff();

            OnDestroyClick();
        }
    }
    */
    private void Start()
    {
        notificationManager = NotificationManager.INSTANCE;

        notificationManager.ShowNotification(dashboardName, creationMessage);
    }

    public virtual void OnDestroyClick()
    {
        notificationManager.ShowNotification(dashboardName, destroyMessage);

        Destroy(gameObject);
    }
}
