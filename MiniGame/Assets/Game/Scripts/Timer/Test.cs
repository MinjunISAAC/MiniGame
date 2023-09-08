using InGame.ForMiniGame.ForUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private TimerSystem _timer = null;
    // Start is called before the first frame update
    void Start()
    {
        _timer.Timer(TimerSystem.ECountType.CountUp, 3f, () => { Debug.Log($"End"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
