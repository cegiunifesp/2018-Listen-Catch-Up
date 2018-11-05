using UnityEngine;

public class WordCube : Cube<Word>
{

    public SpriteRenderer Image;
    public Animator Animator;

    public override void Setup()
    {
        Data = WordManager.Instance.GetRandomWord();
        if (Data == null)
            Destroy(gameObject);
        PaintRandomColor();
    }

    protected override void OnDataChanged()
    {
        Image.sprite = Data?.Image;
    }

    protected override void OnMouseDown()
    {
        if (GameManager.Instance.State != GameState.Game) return;
        if (WordManager.Instance.ValidateWord(Data))
        {
            //GetComponent<Rigidbody2D>().gravityScale = 0;
            GameManager.Instance.RightChoice();
            Animator.enabled = true;
            Animator.SetBool("RightClick", true);
        }

        else
        {
            GameManager.Instance.WrongChoice();
            Animator.enabled = true;
            Animator.SetBool("WrongClick", true);
        }

    }

    private void PaintRandomColor()
    {
        var material = GetComponent<Renderer>().material;
        var propsList = new[]
        {
            "_Color1_D",
            "_Color1_F",
            "_Color1_B",
            "_Color1_L",
            "_Color1_T",
            "_Color1_R"
        };
        float hue = UnityEngine.Random.Range(0f, 1f);

        foreach (var prop in propsList)
        {
            Color rgbColor = material.GetColor(prop);
            float h, s, v;
            Color.RGBToHSV(rgbColor, out h, out s, out v);
            h = hue;
            material.SetColor(prop, Color.HSVToRGB(h, s, v));
        }
    }

    public void RightChoice()
    {
        base.OnMouseDown();
    }

    public void WrongChoice()
    {
        Animator.SetBool("WrongClick", false);
    }
}
