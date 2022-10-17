using UnityEngine;
using UnityEngine.Events;
using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class Follower : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_target, radius);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(Position, 0.5f);

#if UNITY_EDITOR
        Handles.Label(_target, "Target");
#endif
    }

    public delegate Vector3 MoveTowardsFunction(Vector3 current, Vector3 target, float speed);
    protected MoveTowardsFunction MoveTowards;
    Action action;

    public UnityEvent OnReachTarget = new UnityEvent();
    public UnityEvent<Vector3> OnStartMoving = new UnityEvent<Vector3>();
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();

    protected void Awake()
        =>  MoveTowards = Vector3.MoveTowards;

    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    [SerializeField] Vector3 _target;
    public Vector3 Target
    {
        get => _target;
        set
        {
            _target = value;
            if (!IsFollowing)
                _task = FollowAsync();
        }
    }
    public void SetTarget(Vector3 target)
        => Target = target;

    Task _task;

    public float radius = 0.5f;
    public float maxDistanceDelta = 0.5f;
    public bool IsFollowing => _task != null && !_task.IsCompleted;
    bool IsOnTarget => (Position - Target).magnitude < radius;
    bool hasBeenStopped;

    private void LateUpdate()
        => action?.Invoke();

    [ContextMenu("StartFollowing")]
    async Task FollowAsync()
    {
        OnStartMoving?.Invoke(Target);
        action += MoveUpdate;
        hasBeenStopped = false;
        while(!IsOnTarget)
        {
            Position = MoveTowards.Invoke(Position, _target, maxDistanceDelta);
            OnMove?.Invoke(Position);
            await Task.Yield();
        }
        action -= MoveUpdate;

        if(IsOnTarget)
            OnReachTarget?.Invoke();
    }

    void MoveUpdate()
        => OnMove?.Invoke(
            Position = MoveTowards.Invoke(Position, _target, maxDistanceDelta));

    public TaskAwaiter GetAwaiter()
        => _task.GetAwaiter();

    public void Stop()
    {
        hasBeenStopped = true;
        _target = Position;
    }

    public static implicit operator Vector3(Follower f) => f.Position;
    public static implicit operator Task(Follower f) => f._task;
}
