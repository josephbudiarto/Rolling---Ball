using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SphereScript : MonoBehaviour {

    public float speed;
    public Text scoretext;
    public Text wintext;

    private Rigidbody rb;
    private int score;

    void Start(){
        rb = GetComponent<Rigidbody>();
        score = 0;
        setScoreText();
    }

	void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
	}

    void OnTriggerEnter(Collider other){
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag("pickup")){
            other.gameObject.SetActive(false);
            score += 10;
            setScoreText();
        }
            
    }

    void setScoreText(){
        scoretext.text = "Score : " + score.ToString();
        if (score == 130)
        {
            setWinText();
        }
    }

    void setWinText(){
        wintext.text = "YOU WIN !!!";
    }
}
