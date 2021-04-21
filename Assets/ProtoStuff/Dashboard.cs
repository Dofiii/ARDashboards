using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashboard : MonoBehaviour
{
    public string dashboardName = "Dashboard";

    public string creationMessage = "Dashboard has been created.";

    private NotificationManager notificationManager;

    private void Start()
    {
        notificationManager = NotificationManager.INSTANCE;

        notificationManager.ShowNotification(dashboardName, creationMessage);
    }
}
