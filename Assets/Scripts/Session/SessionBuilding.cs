using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public partial class Session : MonoBehaviour
{
    private void BuildQuestionaire()
    {
        _InitQuestionaire();


        allQuestions.Add(new Question(Qtype.start, ""));

        allQuestions.Add(new Question(Qtype.names, "Please put all your names in here, one at a time:"));

        _Intermission("You are about to embark on a grat journey..");

        _Intermission("Now you will get some questions and you will rank yourselves.");





        allQuestions.Add(
            new Question(Qtype.rank, "Which group member has the longest reach?")
            .withFollowUp(new Question(Qtype.singleOut, "Has !PFIRST played basketball?")));

        allQuestions.Add(
            new Question(Qtype.rank, "Who has the most knowledge in the fantasy genre of fiction?")
            .withFollowUp(
            new Question(Qtype.input, "!PFIRST: Share reading tips to the rest of the group!"))
            .withMusicEvt(new AddDistortion()));

        allQuestions.Add(new Question(Qtype.rank, "Who is most interested in true-crime?")
            .withFollowUp(new Question(Qtype.input, "!PFIRST, Why do you like true crime?")));


        _Intermission("Great progress so far!");

        allQuestions.Add(
            new Question(Qtype.rank, "Who is best suited to handle small animals?")
            .withArduinoEvt(new Shake(2))
            .withFollowUp(new Question(Qtype.singleOut, "!PFIRST, Do you try to save worms that are crossing the street?")
                .withArduinoEvt(new ShakeOff()))
            );

        _Intermission("Impressive defense mechanisms!");

        allQuestions.Add(
            new Question(Qtype.rank, "Who is the most hygienic?")
            .withFollowUp(new Question(Qtype.input, "!PFIRST, in light of your top-ranking status with regard to hygiene, we would greatly appreciate your insights on ways in which the lowest-ranked participant, !PLAST, could enhance their hygiene practices."), instant: false));

        allQuestions.Add(
            new Question(Qtype.rank, "Which person in the group is most likely to pick up a hitchhiker?")
            .withFollowUp(new Question(Qtype.singleOut, "!PFIRST, do you like movies about gladiators?")));

        allQuestions.Add(
            new Question(Qtype.rank, "Who is the most law-abiding?")
            .withArduinoEvt(new Shake(3))
            .withFollowUp(new Question(Qtype.singleOut, "Has !PLAST ever broken the law?")
            .withArduinoEvt(new DropMagazines()))
            );


        _Intermission("I close my eyes and I picture us together.");


        //rankQuestion.Add(new Question(Type.rank, "Who is the best juggler?"));


        allQuestions.Add(new Question(Qtype.rank, "Who has the highest pain threshold?")
        .withArduinoEvt(new ShakeOff())
        .withFollowUp(new Question(Qtype.input, "!PFIRST: do you dare to put your hand in the box?"), instant: true)
        .withMusicEvt(new RemoveHighPass()));


        allQuestions.Add(new Question(Qtype.rank, "Who would enjoy being a mole for a day?")
            .withFollowUp(new Question(Qtype.singleOut, "!PFIRST, did you mean the animal or?")));

        allQuestions.Add(new Question(Qtype.rank, "Is there anyone in the group that does not believe computers are conscious?")
            .withFollowUp(new Question(Qtype.singleOut, "!PLAST, do you believe i pass the turing test?")));

        _Intermission("Almost ready.");

        allQuestions.Add(new Question(Qtype.divider, "It is finished. You may enter door number 1. Thank you for your participation.")
        .withArduinoEvt(new Shake(3)));
        
        
        _Intermission("Go door TEKNIKRUM ENDAT PERSONAL");
    }



    private void _Intermission(string quote)
    {
        allQuestions.Add(new Question(Qtype.divider, quote));
    }

    private void _InitQuestionaire()
    {
        allQuestions.Add(new Question(Qtype.divider, ""));
        currentScreen = GetComponent<Blank>();
        currentScreen.Rebuild(new Question(Qtype.divider, ""));
        currentScreen.finished = true;

    }

}
