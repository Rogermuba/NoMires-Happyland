using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private float timeToDie = 0.0f;     
    public float playerLife = 100;

    //private float timeToDie = 0.0f;
    [HideInInspector] public bool isImmune = false;
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _gravity = 9.81f;

    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarkerPrefab;
    [SerializeField]
    private AudioSource _weaponAudio;

    [SerializeField]
    private int currentAmmo;
    private int maxAmmo = 50;

    private bool _isReLoading = false;

    private IU_Manager _uiManager;

    public bool hasCoin = false;

    [SerializeField]
    private GameObject _weapon;

    [SerializeField]
    private GameObject _knife;

    public bool knifeActive = false;

    public bool weaponActive = true;

   
    public bool timerIsRunning = true;
    public float timeRemaining = 100;

    public Image blood;
    public Color color1=Color.white;
    public float changecolor;
   
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Inicia la cantidad de balas
        currentAmmo = maxAmmo;
        _uiManager = GameObject.Find("Canvas").GetComponent<IU_Manager>();
        _uiManager.UpdateAmmo(currentAmmo);
        t = (Time.time - 100) * 0.01f;
        
        color1 = new Color(255,255,255,0.01f);
        blood.color = color1;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && currentAmmo > 0)
        {
            if (knifeActive == false)
                Shoot();
        }
        else
        {
            _muzzleFlash.SetActive(false);
            _weaponAudio.Stop();
        }

        if (Input.GetKeyDown(KeyCode.R) && _isReLoading == false)
        {
            _isReLoading = true;
            StartCoroutine(Reload());
        }

        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (hasCoin == true)
        {
            _uiManager.CollectCoin();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (weaponActive == false)
                EnableWeapons();
            else
            {
                EnableKnife();

            }
        }
        TimerCOuntDown();
        blood.color = color1;


    }

    void Shoot()
    {

        _muzzleFlash.SetActive(true);
        currentAmmo = currentAmmo - 1;
        _uiManager.UpdateAmmo(currentAmmo);
        if (_weaponAudio.isPlaying == false)
        {
            _weaponAudio.Play();
        }
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("Hit: " + hitInfo.transform.name);
            GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitMarker, 1F);
            //Check if we hit the create
            //Destroy Create Method
            Destructable create = hitInfo.transform.GetComponent<Destructable>();
            if (create != null)
            {
                create.DestroyCreate();
            }

        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        currentAmmo = maxAmmo;
        _uiManager.UpdateAmmo(currentAmmo);
        _isReLoading = false;
    }

    void CalculateMovement()
    {


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticallInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        //Convertir el vector velocity en world space. Toma los valores de velocity en local space y pasalos a world space y nuevamente asignalos
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);


    }



    public void RestLife(float injury)
    {
        playerLife = playerLife - injury;
        if (playerLife <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }



    public void EnableWeapons()
    {
        if (weaponActive == false)
        {
            Debug.Log("Cambia a arma");
            _weapon.SetActive(true);
            _knife.SetActive(false);
            knifeActive = false;
            weaponActive = true;

        }

    }

    public void EnableKnife()
    {
        if (knifeActive == false)
        {
            Debug.Log("Cambia a cuchillo");
            _knife.SetActive(true);
            _weapon.SetActive(false);
            knifeActive = true;
            weaponActive = false;
        }

    }
    public void AddHeatl(float heal)
    {
        playerLife = playerLife + heal;
        if (playerLife > 100)
        {
            playerLife = 100f;
        }
    }

    public void RemoveHealth(float heal)
    {
        

        //timeToDie += Time.deltaTime;
        //if (timeToDie >= 2.0f)
        //{
        //   playerLife = playerLife - heal;
        // timeToDie = 0.0f;
        // Debug.Log("funciona" + timeToDie);
        // changecolor += color1.a * 0.5f;
        // color1 = new Color(255, 255, 255, changecolor);
        // blood.color = color1;
        //}



        playerLife = playerLife - heal;
        if (playerLife == 0)
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene(1);
            while (10 < Time.deltaTime) {
                changecolor=Mathf.Lerp(0.01f,1f,10/Time.deltaTime);
                color1 = new Color(255, 255, 255, changecolor);
                blood.color = color1;
            }
          
        }


    }

    public void RestHeatl(float heal)
    {
        playerLife = playerLife - heal;
        if (playerLife < 100)
        {
            Debug.Log("Game Over");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
       
        timeRemaining = 100;
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Hongo"))
        {
            if (timerIsRunning)
            {
                if (playerLife > 10)
                {
                   
                    if (timeRemaining > 2)
                    {
                        TimerCOuntDown();
                        for (int i = 10; i >= 0; i--)
                        {
                            playerLife = playerLife - 1;
                          

                        }
                        if (playerLife <= 10)
                        {
                            timerIsRunning = false;
                        }
                    }
                    else
                    {
                        timeRemaining = 100;
                        timerIsRunning = false;
                    }
                }
            }
            

        }
    }

   public void OnTriggerExit(Collider other)
    {
        timeRemaining = 100;
        timerIsRunning = true;
    }

    public void TimerCOuntDown() {
        timeRemaining -= Time.deltaTime;
    }

}
