using DefaultNamespace.ScriptableEvents;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "new AsteroidSet", menuName = "ScriptableObjects/AsteroidSet", order = 0)]
    public class AsteroidSet : ScriptableObject
    {
        private Dictionary<int, Asteroid> _asteroidDict = new Dictionary<int, Asteroid>();

        private int count;

        private void OnEnable()
        {
            _asteroidDict.Clear();
            count = 0;
        }

        public Asteroid GetAsteroid(int id)
        {
            return _asteroidDict[id];
        }
     
        public void RegisterAsteroid(Asteroid asteroid)
        {
            if (!asteroid) { return; }
            _asteroidDict.Add(asteroid.GetInstanceID(), asteroid);
            count++;
            //call registered event
        }

        public void DestroyAsteroid(Asteroid asteroid)
        {
            if (!asteroid) { return; }

            var id = asteroid.GetInstanceID();
            if (!_asteroidDict.ContainsKey(id)) { return; }

            var asteroidToDestroy =_asteroidDict[id];
            if (!asteroidToDestroy) { return; }

            count--;
            _asteroidDict.Remove(id);
            Destroy(asteroidToDestroy.gameObject);
            //_onAsteroidDestroyed.Raise(id);
            //call removed event
        }
    }
}
