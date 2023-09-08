// ----- Unity
using UnityEngine;

namespace InGame.ForState.ForUI
{
    public abstract class StateView : MonoBehaviour
    {
        public abstract void OnInit();
        public abstract void OnFinishi();
    }
}