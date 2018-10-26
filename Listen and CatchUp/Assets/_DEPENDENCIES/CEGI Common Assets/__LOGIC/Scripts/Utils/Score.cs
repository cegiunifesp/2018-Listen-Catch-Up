public class Score
{
    private int _rightchoices;
    private int _wrongchoices;
    private int _timepoints;

    public Score()
    {
        _rightchoices = 0;
        _wrongchoices = 0;
        _timepoints = 0;
    }

    public void RightChoice() => _rightchoices++;
    public void WrongChoice() => _wrongchoices++;
    public void TimePoints(int p) => _timepoints += p;

    public int Value => _timepoints;
    public int RightWords => _rightchoices;
}