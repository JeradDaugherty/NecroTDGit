using UnityEngine;
using System.Collections;

/// <summary>
/// Used to move the attached object.
/// </summary>
public class Mover : MonoBehaviour 
{
    public void Move(Vector3 direction)
    {
        this.transform.parent.Translate(direction);
    }
}
