using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onTimerComplete;
    [SerializeField]
    private UnityEvent<string> _OnSecondPassed;
    private Coroutine _TimerCoroutine;
    public void StartTimer(float duration)
    {
        StartCoroutine(RunTimer(duration));
    }
    private IEnumerator RunTimer(float duration)
    {
        _OnSecondPassed?.Invoke(""+(int)duration);
        yield return new WaitForSeconds(duration);
        if (duration == 0)
        {
            _onTimerComplete?.Invoke();
            _TimerCoroutine = null;
        }
        else
        {
            _TimerCoroutine = StartCoroutine(RunTimer(duration - 1));
        }
    }
    public void StopTimer()
    {
        if (_TimerCoroutine != null)
        {
            StopCoroutine(_TimerCoroutine);
            _TimerCoroutine = null;
        }
    }
}
    
