using System;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    public static event Action OnHookActivation;
    public static event Action OnHookDeactivation;
    
    [SerializeField] 
    private float distanceThreshold = 0.3f;

    [SerializeField] 
    private Transform _cabin;
    
    [SerializeField] 
    private Transform _truck;

    private Vector3 _cabinInitialPosition;
    private Vector3 _truckInitialPosition;
    private bool _cabinInPosition;
    private bool _truckInPosition;
    private PositionState _positionState;

    protected void Awake()
    {
        _cabinInitialPosition = _cabin.localPosition;
        _truckInitialPosition = _truck.localPosition;
    }

    public void CheckCabinInPosition()
    {
        _cabinInPosition = InPosition(_cabin.localPosition, _cabinInitialPosition);
        Debug.Log("Cabin is in position: " + _cabinInPosition); 
        CheckAllInPosition(_cabinInPosition && _truckInPosition);
    }

    public void CheckTruckInPosition()
    {
        _truckInPosition = InPosition(_truck.localPosition, _truckInitialPosition);
        Debug.Log("Truck is in position: " + _cabinInPosition); 
        CheckAllInPosition(_truckInPosition && _cabinInPosition);
    }

    private void CheckAllInPosition(bool inPosition)
    {
        if (inPosition)
        {
            var currentState = PositionState.PositionFound;
            if (currentState == _positionState) return;
            _positionState = currentState;
            Debug.Log($"Both in position, cabin: {_cabinInPosition} and track {_truckInPosition}");
        } else
        {
            var currentState = PositionState.PositionLost;
            if (currentState == _positionState) return;
            _positionState = currentState;
            Debug.Log($"Not all in position: cabin: {_cabinInPosition} and track {_truckInPosition}");
        }
        
        OnPositionChanged(_positionState);
    }
    
    private void OnPositionChanged(PositionState position)
    {
        switch (position)
        {
            case PositionState.PositionFound:
                OnHookActivation?.Invoke();
                break;
            case PositionState.PositionLost:
                OnHookDeactivation?.Invoke();
                break;
        }
    }

    private bool InPosition(Vector3 target, Vector3 position)
    {
        var distance = Vector3.Distance(target, position);
        return distance < distanceThreshold;
    }
}

public enum PositionState
{
    PositionFound = 0,
    PositionLost = 1,
}