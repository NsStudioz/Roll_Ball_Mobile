using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class AndroidNotificationHandler : MonoBehaviour
{

    private const string ChannelId = "Notification_Channel";

    public void ScheduleNotification(DateTime dateTime)
    {
#if UNITY_ANDROID
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel
        {
            Id = ChannelId,
            Name = "Notification Channel",
            Description = "Random Notification",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Energy Recharged!",
            Text = "Your Energy is now full, come back to play again!",
            SmallIcon = "icon_small",
            LargeIcon = "default",
            FireTime = dateTime
        };

        AndroidNotificationCenter.SendNotification(notification, ChannelId);
    }
#endif
}
