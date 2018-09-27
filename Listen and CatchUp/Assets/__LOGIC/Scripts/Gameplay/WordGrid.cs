public class WordGrid :  CubeGenerator<Word> {
    public override void GenerateGrid()
    {
        base.GenerateGrid();
        WordManager.Instance.GetNewWord();
    }

    public override void Clear()
    {
        base.Clear();
        WordManager.Instance.ResetWords();
    }
}
