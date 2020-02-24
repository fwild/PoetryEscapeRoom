using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderTrackableEventHandler : DefaultTrackableEventHandler
{
    public WorldAnchorManager manager;
    public Text textLog;
    GameObject cubeCollider;

    #region PROTECTED_METHODS
    /**
    protected override void OnTrackingLost()
    {
        textLog.text += "tracking lost, anchoring object..\n";
        //GameObject temp = mTrackableBehaviour.GetComponentInChildren<GameObject>();
        //mTrackableBehaviour.GetComponentInChildren<GameObject>();
        
        //manager.AttachAnchor(temp);

        base.OnTrackingLost();
    }

    protected override void OnTrackingFound()
    {
        manager.AttachAnchor(mTrackableBehaviour.GetComponentInChildren<GameObject>());

        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;

        base.OnTrackingFound();
    }
    **/

    protected override void OnTrackingLost()
    {

        textLog.text += "Tracking has been lost - attaching anchor..\n";
        manager.AttachAnchor(cubeCollider);

        base.OnTrackingLost();
    }

    protected override void OnTrackingFound()
    {
        //mTrackableBehaviour.GetComponentInChildren < GameObject.FindGameObjectWithTag("Zone1Start") > ();

        textLog.text += "Tracking has been found - updating temporary Cube collider incase of loss..\n";
        cubeCollider = GetComponentInChildren<GameObject>();
       /**
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    **/
        base.OnTrackingFound();
    }
    #endregion // PROTECTED_METHODS
}
