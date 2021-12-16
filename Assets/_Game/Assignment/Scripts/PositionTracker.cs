using DefaultNamespace.ScriptableEvents;
using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    [SerializeField] private ScriptableEventVector3 _onOutOfBounds;

    [SerializeField] private float _widthBoundry = 10.5f;
    [SerializeField] private float _heightBoundry = 6.2f;

    [SerializeField] private float _xResetPos = 10f;
    [SerializeField] private float _yResetPos = 6f;

    private void OnBecameInvisible()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        var newX = x;
        var newY = y;

        var outOfBoundsX = x > _widthBoundry || x < -_widthBoundry;
        var outOfBoundsY = y > _heightBoundry || y < -_heightBoundry;

        if (outOfBoundsX) { newX = x > 0 ? -_xResetPos : _xResetPos; }
        if (outOfBoundsY) { newY = y > 0 ? -_yResetPos : _yResetPos; }

        if (!_onOutOfBounds) { return; }
        _onOutOfBounds.Raise(new Vector3(newX, newY, 0f));
    }
}
