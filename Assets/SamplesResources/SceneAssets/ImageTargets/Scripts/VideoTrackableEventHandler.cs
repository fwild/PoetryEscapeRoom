/*===============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.
 
Vuforia is a trademark of PTC Inc., registered in the United States and other
countries.
===============================================================================*/

using UnityEngine;

public class VideoTrackableEventHandler : DefaultTrackableEventHandler
{
    #region PROTECTED_METHODS

    protected override void OnTrackingLost()
    {
        //mTrackableBehaviour.GetComponentInChildren<VideoController>().Pause();

        VideoController[] videos = GetComponentsInChildren<VideoController>();

        foreach (VideoController video in videos)
        {
            video.Pause();
        }

        //base.OnTrackingLost(); //commented out for now as we dont want to see the extended tracking.
    }

	protected override void OnTrackingFound()
	{

		base.OnTrackingFound();
		VideoController[] videos = GetComponentsInChildren<VideoController>();

        foreach (VideoController video in videos)
        {
            video.Play();
        }
	}

    #endregion // PROTECTED_METHODS
}
