using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public AudioSource SFXsource;
    public AudioSource MusicSource;
    public AudioSource gameOverSoundSource;
    public AudioClip CountdownBip;
    public AudioClip CountdownBiiip;
    public AudioClip coinCollect;
    public AudioClip BackgroundMusic;
    public AudioClip HurtSound;
    public AudioClip gameOverSound;
    public bool MusicOnOffBool;
    public GameObject SoundManager;
    public GameObject GameOverSoundSourceObj;


    public GameObject musicOnImg;
    public GameObject musicOffImg;

    public Text winPanelTotalCoinTxt;
    public Text urTheBestText;
    public Text scoreTxt;
    public Text bestScoreTxt;
    public Text CountdownTxt;
    public int bestScore;
    public int score = 0;
    public float health = 5f;
    public GameObject healtImgObj;
    public Image healthImgFill;
    public bool pauseRestartClickBool;
    public bool isStartedBool;
    public GameObject PauseTxt;
   // public Animator PauseTxtAnimator;
    public GameObject GameOverPanel;
    public GameObject winPanel;
    
    public GameObject Mario;
    public Rigidbody MarioRb;
    public Animator CountdownAnimator;
    public AnimationClip CountdownAnimClip;
    // Start is called before the first frame update

    private void Awake()
    {
        musicOffImg.SetActive(false);
        MusicOnOffBool = true;
        MusicSource.GetComponent<AudioSource>().volume = 0f;
        Time.timeScale = 1f;
        Mario = GameObject.Find("MarioWithAnim");
        healtImgObj = GameObject.Find("Canvas/healthImg");
        healthImgFill = healtImgObj.GetComponent<Image>();
        PauseTxt = GameObject.Find("Canvas/PauseBtn/PauseTxt");
        GameOverPanel = GameObject.Find("Canvas/gameOverPanel");
        

        Mario = GameObject.Find("MarioWithAnim");
        MarioRb = Mario.GetComponent<Rigidbody>();
        isStartedBool = false;

    }

   IEnumerator Start()
    {
        scoreTxt.text = "Coins = " + score;
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestScoreTxt.text = "Best = " + bestScore;


        GameOverPanel.SetActive(false);
        PauseTxt.SetActive(false);
        winPanel.SetActive(false);

        yield return new WaitForSeconds(1f);
        CountdownAnimator.Play("countdownAnim");
        CountdownTxt.text = "3";
        SFXsource.PlayOneShot(CountdownBip);


        yield return new WaitForSeconds(1f);
        CountdownAnimator.Play("countdownAnim");
        CountdownTxt.text = "2";
        SFXsource.PlayOneShot(CountdownBip);

        yield return new WaitForSeconds(1f);
        CountdownAnimator.Play("countdownAnim");
        CountdownTxt.text = "1";
        SFXsource.PlayOneShot(CountdownBip);

        yield return new WaitForSeconds(1f);
        CountdownAnimator.Play("countdownAnim");
        CountdownTxt.text = "GO!!";
        SFXsource.PlayOneShot(CountdownBiiip);
        yield return new WaitForSeconds(0.8f);
        CountdownTxt.text = "";

        MusicSource.GetComponent<AudioSource>().volume = 0.6f;
        isStartedBool = true;






    }

    // Update is called once per frame
    void Update()
    {

        winPanelTotalCoinTxt.text = "TOTAL = " + score;
        if(score == bestScore)
        {
            urTheBestText.text = "YOU ARE THE BEST <3";

        }

        
    }

    public void addScore(int scoreValue)
    {
        score += scoreValue;
        scoreTxt.text = "Coins = " + score;
        if (score >= bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
            bestScore = PlayerPrefs.GetInt("bestScore");
            bestScoreTxt.text = "Best = " + bestScore;
        }

    }

    public void damage(float damageValue)
    {
        health -= damageValue;
        SFXsource.PlayOneShot(HurtSound);
        healthImgFill.fillAmount = health / 5f;
        if (health <= 0)
        {
            Time.timeScale = 0; //biliyorum yanlis!!!!!!!!!!!!!!! PANEL GELICEK BURAYA
            GameOverPanel.SetActive(true);
            SoundManager.SetActive(false);
            gameOverSoundSource.PlayOneShot(gameOverSound);

        }

    }

    public void PauseClick()
    {
        pauseRestartClickBool = !pauseRestartClickBool;
        if (pauseRestartClickBool)
        {
            Time.timeScale = 0f;
            PauseTxt.SetActive(true);
           // PauseTxtAnimator.Play("PausedTxtAnim");
            
        }
        else
        {
            Time.timeScale = 1f;
            PauseTxt.SetActive(false);
        }
        
    }

    public void RestartClick()
    {
        SceneManager.LoadScene("Scenes/platform");
    }

    IEnumerator CountdownWaiter()
    {
        yield return new WaitForSeconds(1f);
    }


    public void HomeBtn()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void MusicOnOffClick()
    {
        MusicOnOffBool = !MusicOnOffBool;
        if (MusicOnOffBool)
        {
            musicOnImg.SetActive(true);
            musicOffImg.SetActive(false);
            SoundManager.SetActive(true);
            GameOverSoundSourceObj.SetActive(true);


           // SFXsource.volume = .8f; 
          //  MusicSource.volume = .6f;
        }
        if (!MusicOnOffBool)
        {
            GameOverSoundSourceObj.SetActive(false);
            
            musicOnImg.SetActive(false);
            musicOffImg.SetActive(true);
            SoundManager.SetActive(false); // ama bu da calýsýyo. bunun daha iyi calistigina karar verdim sebebi.: arkaplan muzigini audioSource.volumele acmistim yoksa caldiramadim. volumele ses acip kapatinca hatali oluyor. geri sayimda da ses kapatabilmek icin setactiva daha iyi
           // SFXsource.volume = 0f; //coin falan toplayýnca playoneshotlarda acýlýyo direkt // dur benim hatam galiba !! evet benim hatammýs týklayýnca her space bastýgýmda týklýyomus ses cýkaran her seyde de zýplandýgý icin ben playoneshot calýsanlarda oldugunu dusunmusum.
           // MusicSource.volume = 0f;

        }
    }
}
