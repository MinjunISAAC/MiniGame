using InGame.ForMiniGame.ForUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utiltiy.ForLoader;

public class Test : MonoBehaviour
{
    //[SerializeField] private TimerSystem _timer = null;
    [SerializeField] private Loader _loader = null;

    // Start is called before the first frame update
    void Start()
    {
        _loader.Visiable(3f, () => { Debug.Log($"END LOADER"); });
        //_timer.Timer(TimerSystem.ECountType.CountUp, 3f, () => { Debug.Log($"End"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
