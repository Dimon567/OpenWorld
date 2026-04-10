using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int _hour;
    private int _minute;
    private int _day;

    public void AddTime(int minute = 0, int hour = 0, int day = 0)
    {
        _minute += minute;
        _hour += hour;
        _day += day;

        if (minute >= 60)
        {
            _hour += _minute / 60;
            _minute %= 60;
        }

        if (minute >= 24)
        {
            _day += _hour / 60;
            _hour %= 60;
        }

    }

    void FixedUpdate()
    {
        
    }
}
