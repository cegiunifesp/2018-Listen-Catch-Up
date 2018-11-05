using UnityEngine;

public class RankingWindow : GameWindow
{
    public RankingListView RankingList;

    public override void Show()
    {
        base.Show();
        RankingList.Refresh();
    }
}
