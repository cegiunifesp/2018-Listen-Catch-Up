using UnityEngine;

public class RankingWindow : GameWindow
{
    public RankingEntry RankingEntryTemplate;
    public Transform RankingList;

    public void AddEntries(NetworkedScoreEntry[] scores)
    {
        for (var i = 0; i < scores.Length; i++)
        {
            var score = scores[i];
            Instantiate(RankingEntryTemplate, RankingList).Init((i + 1).ToString(), score.Name, score.Score);
        }
    }

    public void Clear()
    {
        RankingEntry[] entries = RankingList.GetComponentsInChildren<RankingEntry>();
        for (var i = 0; i < entries.Length; i++)
        {
            Destroy(entries[i].gameObject);
        }
    }
}
