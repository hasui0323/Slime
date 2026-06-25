using UnityEngine;

//BGMタイプ
public enum BGMType
{
    //ゲーム中のBGM---------------------
    None,           //なし
    CardSelect,     //カードセレクト
    InGame,         //ゲーム中
    //----------------------------------
}

//SEタイプ
public enum SEType
{
    //ゲームのSE------------------------
    GameClear,  //ゲームクリア
    GameOver,   //ゲームオーバー
    Shot,       //ショット(弾、ハンマー)
    Buff,       //バフ(プレイヤーの効果)
    Damage,     //ダメージ
    //----------------------------------
    //選択SE----------------------------
    Select,     //選択音
    Decision,   //決定音
    Cancel,     //キャンセル音
    //----------------------------------
}

public class FSoundManager : MonoBehaviour
{
    //ゲーム中の音
    public AudioClip bgmInCardSelect;
    public AudioClip bgmInGame;
    //ゲームクリア・ゲームオーバー
    public AudioClip meGameClear;
    public AudioClip meGameOver;
    //アイテム効果音・ダメージ音
    public AudioClip seGameShot;
    public AudioClip seGameBuff;
    public AudioClip seGameDamage;
    //選択・決定・キャンセル
    public AudioClip seSelect;
    public AudioClip seDecision;
    public AudioClip seCancel;

    public static FSoundManager soundManager;   //最初のSondManagerを保存する変数

    public static BGMType playingBGM = BGMType.None;    //再生中のBGM

    private void Awake()
    {
        //BGM再生
        if(soundManager == null)
        {
            soundManager = this;    //static変数に自分を保存する
            //シーンが変わってもゲームオブジェクトを破棄しない
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);    //ゲームオブジェクトを破棄
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //BGM設定
    public void PlayBgm(BGMType type)
    {
        if(type !=playingBGM)
        {
            playingBGM = type;
            AudioSource audio = GetComponent<AudioSource>();
            
            //ゲーム中の音--------------------------------
            if(type==BGMType.CardSelect)
            {
                audio.clip = bgmInCardSelect;   //カードセレクト
            }
            else if(type==BGMType.InGame)
            {
                audio.clip = bgmInGame;         //ゲーム中
            }
            audio.Play();
            //--------------------------------------------
        }
    }
    //BGM停止
    public void StopBgm()
    {
        GetComponent<AudioSource>().Stop();
        playingBGM=BGMType.None;
    }

    //SE再生
    public void SEPlay(SEType type)
    {
        //ゲームクリアSE・ゲームオーバーSE----------------
        if (type == SEType.GameClear)
        {
            GetComponent<AudioSource>().PlayOneShot(meGameClear);   //ゲームクリア
        }
        else if(type == SEType.GameOver)
        {
            GetComponent<AudioSource>().PlayOneShot(meGameOver);   //ゲームオーバー
        }
        //------------------------------------------------
        //アイテム効果音・ダメージ音----------------------
        else if (type == SEType.Shot)
        {
            GetComponent<AudioSource>().PlayOneShot(seGameShot);   //弾・ハンマー
        }
        else if (type == SEType.Buff)
        {
            GetComponent<AudioSource>().PlayOneShot(seGameBuff);   //バフ
        }
        else if (type == SEType.Damage)
        {
            GetComponent<AudioSource>().PlayOneShot(seGameDamage);   //ゲームオーバー
        }
        //------------------------------------------------
        //選択SE------------------------------------------
        else if (type == SEType.Select)
        {
            GetComponent<AudioSource>().PlayOneShot(seSelect);   //選択
        }
        else if (type == SEType.Decision)
        {
            GetComponent<AudioSource>().PlayOneShot(seDecision);   //決定
        }
        else if (type == SEType.Cancel)
        {
            GetComponent<AudioSource>().PlayOneShot(seCancel);   //キャンセル
        }
    }


}
