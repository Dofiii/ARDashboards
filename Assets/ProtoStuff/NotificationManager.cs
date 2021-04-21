using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of this class
    /// </summary>
    public static NotificationManager INSTANCE;

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
    private Text notificationTitleText;

    [SerializeField]
    private Text notificationMessageText;

    [Space]

    [SerializeField]
    private Animator notificationPanelAnimator;

    private Coroutine notificationCoroutine;

    /// <summary>
    /// Shows a notification for the user on the bottom of their screen.
    /// </summary>
    /// <param name="title">Title of the notification</param>
    /// <param name="message">Message of the notification</param>
    public void ShowNotification(string title, string message)
    {
        //Stop the possible previous Coroutine
        if (notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
        }

        //Start the new one
        notificationCoroutine = StartCoroutine(NotificationRoutine(title, message));
    }

    private IEnumerator NotificationRoutine(string title, string message)
    {
        //Set title and message
        notificationTitleText.text = title;
        notificationMessageText.text = message;

        //Play animation of popping up
        notificationPanelAnimator.SetBool("NotificationShown", true);

        yield return new WaitForSeconds(2.5f);

        //Play animation of popping away
        notificationPanelAnimator.SetBool("NotificationShown", false);
    }
}
