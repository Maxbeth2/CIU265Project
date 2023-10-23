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

        _Intermission("Now you will get some questions and you will rank yourselves.");

        allQuestions.Add(
            new Question(Qtype.rank, "Which group member has the longest reach?")
            .withArduinoEvt(new DropMagazines())
            .withFollowUp(new Question(Qtype.singleOut, "Has !PFIRST played basketball?")));

        allQuestions.Add(
            new Question(Qtype.rank, "Who is best suited to handle small animals?")
            .withFollowUp(new Question(Qtype.singleOut, "!PFIRST, Do you try to save worms that are crossing the street?")
            .withArduinoEvt(new ShakeOff()))
            .withArduinoEvt(new Shake(0)));


        _Intermission("I close my eyes and I picture us together.");


        allQuestions.Add(
            new Question(Qtype.rank, "Who is the most hygienic?")
            .withFollowUp(new Question(Qtype.singleOut, "!PFIRST, in light of your top-ranking status with regard to hygiene, we would greatly appreciate your insights on ways in which the lowest-ranked participant, !PLAST, could enhance their hygiene practices."), instant: false));

        allQuestions.Add(
            new Question(Qtype.rank, "Which person in the group is most likely to pick up a hitchhiker?")
            .withFollowUp(new Question(Qtype.singleOut, "!PFIRST, do you like movies about gladiators?")));

        allQuestions.Add(
            new Question(Qtype.rank, "Who is the most law-abiding?")
            .withFollowUp(new Question(Qtype.singleOut, "Has !PLAST ever broken the law?"))
            .withArduinoEvt(new Shake(1))
            );


        _Intermission("");


        //rankQuestion.Add(new Question(Type.rank, "Who is the best juggler?"));


        allQuestions.Add(new Question(Qtype.rank, "Who has the highest pain threshold?").withFollowUp
            (new Question(Qtype.singleOut, "Do you dare to put your hand in the box?"), instant: true)
            .withMusicEvt(new RemoveHighPass()));

        allQuestions.Add(new Question(Qtype.rank, "Who has the most knowledge in the fantasy genre of fiction?")
            .withFollowUp(
            new Question(Qtype.singleOut, "Share reading tips"), instant: true)
            .withMusicEvt(new AddDistortion()));

        allQuestions.Add(new Question(Qtype.rank, "Who is most interested in true-crime?")
            .withFollowUp(new Question(Qtype.singleOut, "!PFIRST, Why do you like it?")));

        allQuestions.Add(new Question(Qtype.rank, "Who would enjoy being a mole for a day?")
            .withFollowUp(new Question(Qtype.singleOut, "Did you mean the animal or?")));

        allQuestions.Add(new Question(Qtype.rank, "Is there anyone in the group that does not believe computers are conscious?")
            .withFollowUp(new Question(Qtype.singleOut, "Do you believe i pass the turing test?")));


        _Intermission("Now we are almost done.");

        

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
