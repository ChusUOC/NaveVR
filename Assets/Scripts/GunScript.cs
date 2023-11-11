
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GunScript : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public Light light;

    private bool isLightOn = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {

            shoot();
            StartCoroutine(EncenderApagarConRetraso());
        }
    }
    void shoot () {

        muzzleFlash.Play();
        
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {

            Debug.Log(hit.transform.name);

            EnemyTarget target = hit.transform.GetComponent<EnemyTarget>();
            if (target != null)
            {
                target.takeDamage(damage);
            }
        }
        
        

    }

    IEnumerator EncenderApagarConRetraso()
    {
        // Marcar la luz como encendida
        isLightOn = true;

        // Encender la luz
        light.enabled = true;

        // Esperar 1 segundo
        yield return new WaitForSeconds(0.1f);

        // Apagar la luz
        light.enabled = false;

        // Esperar 1 segundo
        yield return new WaitForSeconds(0.1f);

        // Marcar la luz como apagada
        isLightOn = false;
    }
}
