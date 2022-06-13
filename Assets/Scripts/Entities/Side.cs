using UnityEngine;

namespace Entities
{
    public class Side : MonoBehaviour
    {
        private int _minionsInstantiateCount;
        public int GetMinionInstantiateCount() => _minionsInstantiateCount;

        public void AddMinion()
        {
            _minionsInstantiateCount++;
        }
    }
}
