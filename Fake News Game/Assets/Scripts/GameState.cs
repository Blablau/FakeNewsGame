using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    public int apocalypseMeter;
    public int geld;
    public GameObject createNewHeadlineButton;
    public GameObject submitNewHeadlineButton;
    public GameObject replaceButton1;
    public GameObject replaceButton2;
    public GameObject replaceButton3;
    public GameObject feedBackText;
    public GameObject gameOverGut;
    public GameObject gameOverSchlecht;
    private string feedBackTextText;
    private string[] headlineWithGap; //initialize this
    private string[] replaceOptions1; //initialize this
    private string[] replaceOptions2; //initialize this
    private string[] replaceOptions3; //initialize this
    private NewsHeadline currentNews;
    public int counter;

    // Use this for initialization
    void Start () {
        apocalypseMeter = 0;
        geld = 1000;
        counter = 0;

        Button btn1 = createNewHeadlineButton.GetComponent<Button>();
        Button btn2 = submitNewHeadlineButton.GetComponent<Button>();
        Button btn3 = replaceButton1.GetComponent<Button>();
        Button btn4 = replaceButton2.GetComponent<Button>();
        Button btn5 = replaceButton3.GetComponent<Button>();
        //Calls the TaskOnClick method when you click the Button
        btn1.onClick.AddListener(createNewHeadlineButtonClicked);
        btn2.onClick.AddListener(submitNewHeadlineButtonClicked);
        btn3.onClick.AddListener(replaceButton1Clicked);
        btn4.onClick.AddListener(replaceButton2Clicked);
        btn5.onClick.AddListener(replaceButton3Clicked);
    }
	
	// Update is called once per frame
	void Update () {
        if(apocalypseMeter > 100)
        {
            gameOverSchlecht();
        }
        if(geld <= 0)
        {
            geld = 0;
            gameOverGut();
        }
		
	}


    void createNewHeadlineButtonClicked()
    {
        currentNews = new NewsHeadline(headlineWithGap[counter], replaceOptions1[counter], replaceOptions2[counter], replaceOptions3[counter]);
        counter++;
        createNewHeadlineButton.SetActive(false);
        submitNewHeadlineButton.SetActive(true);
        replaceButton1.SetActive(true);
        replaceButton2.SetActive(true);
        replaceButton3.SetActive(true);
        feedBackText.SetActive(false);

    }

    void submitNewHeadlineButtonClicked()
    {
        if(currentNews.replaceNumber != 0)
        {
            if(currentNews.replaceNumber == 1)
            {
                geld += Random.Range(50, 100);
                

            } else if (currentNews.replaceNumber == 2)
            {
                geld += Random.Range(100, 200);
                apocalypseMeter += Random.Range(5, 15);
            } else if (currentNews.replaceNumber == 3)
            {
                geld += Random.Range(500, 1000);
                apocalypseMeter += Random.Range(25, 30);
            }
            setFeedbackText();
            geld -= 500; //MIETE
            createNewHeadlineButton.SetActive(true);
            submitNewHeadlineButton.SetActive(false);
            replaceButton1.SetActive(false);
            replaceButton2.SetActive(false);
            replaceButton3.SetActive(false);
            feedBackText.SetActive(true);
        }
    }
    void replaceButton1Clicked()
    {
        currentNews.replaceTextPassage1();
    }
    void replaceButton2Clicked()
    {
        currentNews.replaceTextPassage2();
    }
    void replaceButton3Clicked()
    {
        currentNews.replaceTextPassage3();
    }
    void setFeedbackText()
    {
        if(currentNews.replaceNumber == 1)
        {
            feedBackTextText = "gut";
        } else if (currentNews.replaceNumber == 2)
        {
            feedBackTextText = "nicht gut";
        } else if (currentNews.replaceNumber == 3)
        {
            feedBackTextText = "schlecht";
        }
    }
    void gameOverGut()
    {
        //TODO: GAMEOVER GUT
        gameOverGut.SetActive(true);
    }
    void gameOverSchlecht()
    {
        //TODO: GAMEOVER SCHLECHT
        gameOverSchlecht.SetActive(true);
    }
}
