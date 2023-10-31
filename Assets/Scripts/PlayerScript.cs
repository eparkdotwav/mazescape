using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System; 

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    public Text timerText;
    public Text scoreText;
    public AudioClip clip1; // collect
    public AudioClip clip2; // win

    Rigidbody2D _rbody;
    float _speed;
    double _startTime;
    float _timer;
    int _score;
    bool _won;
    bool _over;
    int oldVal;
    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _speed = 6;
        _startTime = Time.time;
        _score = 0;
        _timer = 30;
        _won = false;
        _over = false;
        oldVal = 0;

        if (PlayerPrefs.HasKey("old"))
        {
            oldVal = PlayerPrefs.GetInt("old");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_won )
        {
            Win();
            _over = true;
        }

        if (_timer <= 0)
        {
            Lose();
            _over = true;
        }

        CheckQuit();

        if (_over)
        {
            return;
        }

        if (!_won && _timer >= 0)
        {
            _timer = _timer - Time.deltaTime;
            timerText.text = "timer: " + MathF.Round(_timer);
        }

        AxisControl();
    }
    void AxisControl()
    {
        // base direction vector
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");
        Vector2 direction = (new Vector2(xDir, yDir)).normalized;
        // set direction based on direction
        _rbody.velocity = direction.normalized * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_won && _timer >= 0)
        {
            if (collision.collider.tag.Equals("Wall"))
            {
                _score--;
                scoreText.text = "score: " + _score;
            }
            _rbody.velocity = -_rbody.velocity * _speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Collectible"))
        {
            if (!_won && _timer >=0)
            {
                GetComponent<AudioSource>().PlayOneShot(clip1);

                if (collision.GetComponent<SpriteRenderer>().color == Color.cyan)
                {
                    _score += 10;
                }

                if (collision.GetComponent<SpriteRenderer>().color == Color.green)
                {
                    _score += 5;
                }

                if (collision.GetComponent<SpriteRenderer>().color == Color.gray)
                {
                    _score += 2;
                }
                scoreText.text = "score: " + _score;
            }
            
        }
        
        if (collision.tag.Equals("Victory"))
        {
            GetComponent<AudioSource>().PlayOneShot(clip2);

            _won = true;

            _score += 20;

            timerText.color = new Color(255, 254, 0);
            scoreText.color = new Color(255, 254, 0);

            timerText.text = "u win!";
            scoreText.text = "score: " + _score;

            return;
        }
    }

    void CheckQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void Win()
    {
        if (_score > oldVal)
        {
            PlayerPrefs.SetInt("old", _score);
            scoreText.text = "new high score!";
        }
        CheckQuit();
    }

    void Lose()
    {
        if (_score > oldVal)
        {
            PlayerPrefs.SetInt("old", _score);
            scoreText.text = "new high score!";
        }

        timerText.text = "game over!";
    }
}
