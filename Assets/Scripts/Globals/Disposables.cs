using Assets.Scripts.Globals;
using System;
using UnityEngine;

public class Disposables
{
}

public class DisposableObject : IDisposable
{
    private readonly GameObject objectToDispose;

    public DisposableObject(GameObject objectDispose)
    {
        this.objectToDispose = objectDispose;
        objectToDispose.Active();
    }

    public void Dispose()
    {
        objectToDispose.Inactive();
    }
}

public class TimedCollider : IDisposable
{
    private readonly BoxCollider2D colliderToDispose;

    public TimedCollider(BoxCollider2D colliderDispose)
    {
        this.colliderToDispose = colliderDispose;
        if (!colliderToDispose.isActiveAndEnabled)
        {
            colliderToDispose.On();
        }
    }

    public void Dispose()
    {
        colliderToDispose.Off();
    }
}

public class TogglePlayerAction : IDisposable
{
    public TogglePlayerAction()
    {
        GlobalVariables.canMove = false;
    }

    public void Dispose()
    {
        GlobalVariables.canMove = true;
    }
}