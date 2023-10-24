using UnityEngine;
using System.Collections.Generic;
using Unity;
using UnityEngine.UIElements;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class NameEntry : BaseScreen
{
    TextField textField;

    List<string> participants;

    public override void Rebuild(Question myQ)
    {
        base.Rebuild(myQ);
        participants = new List<string>();


        visualTree = Resources.Load<VisualTreeAsset>("NameEntry");
        labelFromUXML = visualTree.Instantiate();



        VisualElement questionField = labelFromUXML.Q("questionField");
        Image img = new Image();
        img.image = Resources.Load<Texture2D>("Assets/UI/powered.png");
        img.style.position = Position.Absolute;
        img.style.scale = new StyleScale(new Vector2(0.1f, 0.1f));
        //questionField.Add(img);
        //questionField.Add(powered);
        img.transform.position = new Vector2(400, 100);

        textField = labelFromUXML.Q<TextField>();
        VisualElement qf = questionField;
        Label question = qf.Q<Label>("prompt");
        question.text = myQ.prompt;
        //question.transform.position = new Vector2(15.0f, -200.0f);

        Button myBtn = labelFromUXML.Q<Button>("enterName");
        myBtn.RegisterCallback<ClickEvent>(AddName);

        Button finishButton = labelFromUXML.Q<Button>("finish");
        finishButton.RegisterCallback<ClickEvent>(FinishQuestion);

        root.Add(labelFromUXML);

        var styleSheet = Resources.Load<StyleSheet>("Assets/UI/myStyle.uss");

    }

    private void AddName(ClickEvent evt)
    {
        if (textField.text.Length < 1) return;
        participants.Add(textField.text);
        string txt = textField.text;
        textField.SetValueWithoutNotify("");
        TextElement te = new TextElement();
        te.text = txt;
        te.style.color = new Color(0, 255, 0);
        VisualElement nf = root.Q("namefield");

        nf.Add(te);
    }

    public override void FinishQuestion(ClickEvent evt)
    {   
        if (participants.Count >= 3) {
            finished = true;
        }
    }

    public override Answer GetAnswer()
    {
        return new Answer(participants, null);
    }

}