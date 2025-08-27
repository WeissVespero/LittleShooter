using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _singleShotBulletPrefab;
    [SerializeField] private GameObject _shotgunBulletPrefab;
    public float ShotgunSpread = 15f;
    public int ShotgunBullets = 5;

    private bool isSingleShotMode = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isSingleShotMode = !isSingleShotMode;
            var shotMode = isSingleShotMode ? "Single" : "Volley";
            print($"Gun have been shifted. Current mode: {shotMode}");
        }
    }

    public void Shoot()
    {
        if (isSingleShotMode)
        {
            Instantiate(_singleShotBulletPrefab, _shootPoint.position, _shootPoint.rotation);
        }
        else
        {
            for (int i = 0; i < ShotgunBullets; i++)
            {
                float spreadAngle = Random.Range(-ShotgunSpread, ShotgunSpread);
                Quaternion bulletRotation = Quaternion.Euler(0, 0, _shootPoint.eulerAngles.z + spreadAngle);
                Instantiate(_shotgunBulletPrefab, _shootPoint.position, bulletRotation);
            }
        }
    }
}
