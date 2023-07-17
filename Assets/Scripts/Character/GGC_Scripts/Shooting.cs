using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{
    public AudioSource ShootingSoundPlayer;
    public AudioSource ShootingWhileOnBossArena;
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    [SerializeField] private GameObject shootSprite;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Esto solia servir para tener un cuadrado que rotaba alrededor del jugador dependiendo de a donde se apunta 
        //en caso de querer volver a ponerlo, asegurarse de poner el cuadrado a la derecha del personaje 
        //... y pues areglar el hecho de que al voltearse el sprite se invierten los controles 
        //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        //Vector3 rotation = mousePos - transform.position;

        //float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring )
            { 
                canFire = true;
                timer = 0;  
            }
        }
        if(Input.GetMouseButton(0) && canFire)
        {

            //if (EventSystem.current.IsPointerOverGameObject()) { return;  }
            shootSprite.SetActive(true);
            canFire = false;
            ShootingSoundPlayer.Play();
            ShootingWhileOnBossArena.Play();
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            shootSprite.SetActive(false);
        }
    }

 
}
