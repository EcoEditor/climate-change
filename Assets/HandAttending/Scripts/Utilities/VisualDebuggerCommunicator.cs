using System;
using CzernyStudio.OculusHandTracking.UI;
using UnityEngine;

public class VisualDebuggerCommunicator : MonoBehaviour
{
    #region Fields

    private VisualDebuggerTool _visualDebugger;

    #endregion
    
    #region Methods

    protected void Awake()
    {
        _visualDebugger = FindObjectOfType<VisualDebuggerTool>();
        var collider = GetComponent<SphereCollider>();
        if (collider == null) return;
        _visualDebugger.AssignTextF(collider.name);
    }
    
    

    #endregion
}
