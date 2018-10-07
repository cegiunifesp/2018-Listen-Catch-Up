public class WordGrid :  CubeGenerator<Word> {
    public override void Clear()
    {
        base.Clear();
        WordManager.Instance.ResetWords();
    }
}
