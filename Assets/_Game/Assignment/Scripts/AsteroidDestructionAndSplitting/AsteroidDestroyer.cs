using DefaultNamespace.ScriptableEvents;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidDestroyer : MonoBehaviour
    {
        [SerializeField] private ScriptableEventSplitData _OnAsteroidSplit;
        [SerializeField] private AsteroidSet _asteroidSet;
        [SerializeField] private float _destructionThreshold = 0.4f;

        //Destroys asteroid with ID, also splits it if it is larger that threshold
        public void OnAsteroidHitByLaser(int asteroidID)
        {
            if (!_asteroidSet) { return; }

            var hitAsteroid = _asteroidSet.GetAsteroid(asteroidID);
            if (!hitAsteroid) { return; }

            var size = hitAsteroid.GetSize();
            if (size > _destructionThreshold)
            {
                if (_OnAsteroidSplit) 
                {
                    var destroyPos = hitAsteroid.transform.position;
                    _OnAsteroidSplit.Raise(new SplitData(destroyPos, size/2f));
                }
            }

            _asteroidSet.DestroyAsteroid(hitAsteroid);
        }

    }
}
