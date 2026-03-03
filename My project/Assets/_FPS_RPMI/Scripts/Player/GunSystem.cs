using UnityEngine;
using UnityEngine.InputSystem;

public class GunSystem : MonoBehaviour
{
    #region General Variables
    [Header("General references")]
    [SerializeField] Camera fpsCam; //Ref si disparamos desde el cenro de la cam
    [SerializeField] Transform shootPoint; //Ref si queremos disparar desde la punta del cañón.
    [SerializeField] LayerMask impactLayer; //Layer con la que el raycast interactúa.
    RaycastHit hit; //Almacén de la información de los objetos a los que el raycast puede impactar

    [Header("Weapon parameter")]
    [SerializeField] int damage = 10; //Daño del arma por bala.
    [SerializeField] float range = 100f; //Alcance del arma.
    [SerializeField] float spread = 0; //Radio de dispersión del arma.
    [SerializeField] float shootingCooldown = 0.2f; //Tiempo entre disparos.
    [SerializeField] float reloadTime = 1.5f; //Tiempo de recarga en segundos.
    [SerializeField] bool allowButtonHold = false; //Si el disparo se ejecuta por click (false) o mantener (true).

    [Header("Bullet Management")]
    [SerializeField] int ammoSize = 30; //Cant. máx de balas por cargador.
    [SerializeField] int bulletsPerTap = 1; //Cant de balas disparadas por cada ejecución de disparo
    int bulletsLeft; //Cantidad de balas dentro del cargador actual.

    [Header("Feedback References")]
    [SerializeField] GameObject impactEffect; //Ref al VFX de impacto de bala.

    [Header("Dev - Gun State Bools")]
    [SerializeField] bool shooting; //Indica si estamos disparando
    [SerializeField] bool canShoot; //Indica si podemos disparar en x momento del juego
    [SerializeField] bool reloading; //Indica si estamos recargando en x momento del juego.
    #endregion

    void Awake()
    {
        bulletsLeft = ammoSize; //Al iniciar el juego, el cargador está lleno.
        canShoot = true; //Al iniciar el juego, podemos disparar.
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        //Este es el método más importante
        //Aquí se define el disparo por raycast = utilizable con cualquier mecánica

        //Almacenar la direción de disparo y modificarla en caso de haber spread
        Vector3 direction = fpsCam.transform.forward; //Se lanza rayo hacia delante de la cámara
        //Añadir dispersión aleatoria según el valor de spread
        direction.x += Random.Range(-spread, spread); //Añadir dispersión aleatoria en el eje X
        direction.y += Random.Range(-spread, spread); //Añadir dispersión aleatoria en el eje X

        //DECLARACIÓN DEL RAYCAST
        //Physics.Raycast(Origen del rayo, dirección, almacén de la info del impacto, longitud del rayo, layer con la que impacta el rayo)
        if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range, impactLayer))
        {
            //Aqui puedo codear todos los efectos que quiero para mi interacción
            Debug.Log(hit.collider.name);
        }
    }



    #region Input Methods
    public void OnShoot(InputAction.CallbackContext context)
    {

    }

    public void OnReload(InputAction.CallbackContext context)
    {

    }
    #endregion
}
