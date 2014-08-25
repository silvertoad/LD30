using System;

public class ActiveItemState : ItemState
{
    public override void WakeUp ()
    {
        rigidbody2D.isKinematic = false;
    }
}