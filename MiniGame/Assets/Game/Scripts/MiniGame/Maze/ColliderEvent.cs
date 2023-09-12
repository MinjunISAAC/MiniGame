// ----- C#
using System;

namespace InGame.ForMiniGame.ForControl
{
    public static class ColliderEvent
    {
        public static event Action onFinishAction;
        public static void OnFinishAction()
        {
            if (onFinishAction != null)
                onFinishAction();
        }

        public static event Action onFailAction;
        public static void OnFailAction()
        {
            if (onFailAction != null)
                onFailAction();
        }

        public static event Action onStartAction;
        public static void OnStartAction()
        {
            if (onStartAction != null)
                onStartAction();
        }
    }
}