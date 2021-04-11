using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> enemies;

        private void Awake()
        {

        }

        private void Start()
        {
            if (enemies == null)
            {
                enemies = new List<GameObject>();
            }
        }

        public List<GameObject> GetEnemiesList()
        {
            return enemies;
        }

        public void AddToEnemiesList(GameObject obj)
        {
            enemies.Add(obj);
        }
    }
}
