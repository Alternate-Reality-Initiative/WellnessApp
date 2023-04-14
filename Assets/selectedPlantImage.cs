using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedPlantImage : MonoBehaviour
{
    public GameObject arabella;
    public GameObject amongus;
    public GameObject blocky;
    public GameObject guppy;
    public GameObject sunflower;
    public GameObject tootsie;
    public GameObject venus;
    public GameObject wellington;
    public GameObject sprout;
    public GameObject kirbs;

     Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player.selectedPlant == 0) {
            arabella.SetActive(true);
            amongus.SetActive(false); 
            blocky.SetActive(false); 
            guppy.SetActive (false);
            sunflower.SetActive (false);
            tootsie.SetActive (false);
            venus.SetActive (false);
            wellington.SetActive (false);
            sprout.SetActive (false);
            kirbs.SetActive (false);
        }
        else if (_player.selectedPlant == 1) {
            arabella.SetActive (false);
            amongus.SetActive (false); 
            blocky.SetActive (true); 
            guppy.SetActive (false);
            sunflower.SetActive (false);
            tootsie.SetActive (false);
            venus.SetActive (false);
            wellington.SetActive (false);
            sprout.SetActive (false);
            kirbs.SetActive (false);
        }
        else if (_player.selectedPlant == 2) {
            arabella.SetActive (false);
            amongus.SetActive (true); 
            blocky.SetActive (false); 
            guppy.SetActive (false);
            sunflower.SetActive (false);
            tootsie.SetActive (false);
            venus.SetActive (false);
            wellington.SetActive (false);
            sprout.SetActive (false);
            kirbs.SetActive (false);
        }
        else if (_player.selectedPlant == 3) {
            arabella.SetActive (false);
            amongus.SetActive (false); 
            blocky.SetActive (false); 
            guppy.SetActive (false);
            sunflower.SetActive (false);
            tootsie.SetActive (false);
            venus.SetActive (false);
            wellington.SetActive (false);
            sprout.SetActive (false);
            kirbs.SetActive (true);
        }
        else if (_player.selectedPlant == 4) {
            arabella.SetActive (false);
            amongus.SetActive (false); 
            blocky.SetActive (false); 
            guppy.SetActive (false);
            sunflower.SetActive (false);
            tootsie.SetActive (false);
            venus.SetActive (false);
            wellington.SetActive (false);
            sprout.SetActive (true);
        }
        else if (_player.selectedPlant == 5) {
            arabella.SetActive (false);
            amongus.SetActive (false); 
            blocky.SetActive (false); 
            guppy.SetActive (false);
            sunflower.SetActive (true);
            tootsie.SetActive (false);
            venus.SetActive (false);
            wellington.SetActive (false);
            sprout.SetActive (false);
        }
        else if (_player.selectedPlant == 6) {
            arabella.SetActive (false);
            amongus.SetActive (false); 
            blocky.SetActive (false); 
            guppy.SetActive (false);
            sunflower.SetActive (false);
            tootsie.SetActive (true);
            venus.SetActive (false);
            wellington.SetActive (false);
            sprout.SetActive (false);
        }
        else if (_player.selectedPlant == 7) {
            arabella.SetActive (false);
            amongus.SetActive (false); 
            blocky.SetActive (false); 
            guppy.SetActive (false);
            sunflower.SetActive (false);
            tootsie.SetActive (false);
            venus.SetActive (true);
            wellington.SetActive (false);
            sprout.SetActive (false);
        }
        else if (_player.selectedPlant == 2) {
            arabella.SetActive (false);
            amongus.SetActive (false); 
            blocky.SetActive (false); 
            guppy.SetActive (false);
            sunflower.SetActive (false);
            tootsie.SetActive (false);
            venus.SetActive (false);
            wellington.SetActive (true);
            sprout.SetActive (false);
        }
        else if (_player.selectedPlant == 2) {
            arabella.SetActive (false);
            amongus.SetActive (false); 
            blocky.SetActive (false); 
            guppy.SetActive (true);
            sunflower.SetActive (false);
            tootsie.SetActive (false);
            venus.SetActive (false);
            wellington.SetActive (false);
            sprout.SetActive (false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
