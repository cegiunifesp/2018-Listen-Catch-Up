using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Score{

    int _rightchoices;
    int _wrongchoices;
    int _timepoints;

    public Score()
    {
        _rightchoices = 0;
        _wrongchoices = 0;
        _timepoints = 0;
    }

    public void RightChoice() => _rightchoices++;
    public void WrongChoice() => _wrongchoices++;
    public void TimePoints(int p) => _timepoints += p;

    public int GetScore()
    {
        return _timepoints;
    }

}