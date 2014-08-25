public class DangerItemState : ItemState
{
    protected override void OnPlayerCollided (Player _player)
    {
        _player.Die ();
    }
}