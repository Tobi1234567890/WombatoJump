using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.HelpScripts
{
    class VerticalPositionComparer : IComparer<GameObject>
    {
        public int Compare(GameObject x, GameObject y)
        {
            return x.transform.position.y.CompareTo(y.transform.position.y);
        }
    }
}
