namespace VRTK.Examples
{
    using UnityEngine;

    public class Gun : VRTK_InteractableObject
    {
        public Collider MainCollider;
        private GameObject bullet;
        private float bulletSpeed = 2000f;
        private float bulletLife = 5f;
        private ReferenceManager _refs;
        private AudioSource _audioSrc;
        private ParticleSystem _ps;
        private VRTK_ControllerReference _controller;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            
            FireBullet();
        }

        protected void Start()
        {
            bullet = transform.Find("Bullet").gameObject;
            bullet.SetActive(false);
            _refs = FindObjectOfType<ReferenceManager>();
            _audioSrc = GetComponent<AudioSource>();
            _ps = GetComponentInChildren<ParticleSystem>();

            InteractableObjectGrabbed += Gun_InteractableObjectGrabbed;
            InteractableObjectUngrabbed += Gun_InteractableObjectUngrabbed;
        }

        private void Gun_InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
        {
            MainCollider.enabled = true;
        }

        private void Gun_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
        {
            MainCollider.enabled = false;


            if (e.interactingObject == _refs.RightController.actual.transform.GetChild(0).gameObject)
            {
                _controller = _refs.RightController;
            }
            else _controller = _refs.LeftController;
        }

        private void FireBullet()
        {
            //Debug.Log(_controller.model);
            VRTK_ControllerHaptics.TriggerHapticPulse(_controller, _audioSrc.clip);
            _audioSrc.Play();
            _ps.Play();

            GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(-bullet.transform.forward * bulletSpeed);
            Destroy(bulletClone, bulletLife);
        }
    }
}