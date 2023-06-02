using UnityEngine;

public abstract class Input : MonoBehaviour
{
    public abstract void Enable();
    public abstract void Disable();
    public abstract float ForwardReadValue();
    public abstract float LeftReadValue();
    public abstract float RightReadValue();
    public abstract float BackReadValue();
}
