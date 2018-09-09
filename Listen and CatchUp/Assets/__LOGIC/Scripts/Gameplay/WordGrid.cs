public class WordGrid :  CubeGenerator<Word> {
    public override void GenerateGrid()
    {
        base.GenerateGrid();
        WordManager.Instance.GetNewWord();
    }
}
