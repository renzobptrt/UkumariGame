using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   
    //Todos los bloques iniciales disponibles
    public List<LevelBlock> allInitialBlocks = new List<LevelBlock>();
    //Todos los bloques finales disponibles
    public List<LevelBlock> allFinalBlocks = new List<LevelBlock>();
    //Todos los bloques posteriores a los iniciales disponibles
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();
    //Todos los bloques en escena
    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>();
    //Posicion de generación del primer bloque
    public Transform levelStartPoint;
    //Numero de bloques iniciales
    public int numberInitialBlocks = 0;
    //Numero aleatorio
    private int randomIndex = 0;
    //Padding
    public Vector3 padding = Vector3.zero ;
    //Initial position
    Vector3 spawnPosition = Vector3.zero;

    void Awake(){
        /*if(sharedInstance!=null)
            Destroy(this.gameObject);
        else
            sharedInstance = this;*/
    }

    void Start()
    {   
        //Comenzamos el nivel iniciando los bloques que querramos
        GenerateInitialBlocks(numberInitialBlocks);
    }

    //Generacion de bloques iniciales segun se requiera
    void GenerateInitialBlocks(int numberInitialBlocks){
        for(int i=0; i< numberInitialBlocks ; i++)
            AddLevelBlock();
    }


    //Funcion que añade un bloque de nivel
    public void AddLevelBlock(){

        //Creo un objeto LevelBlock donde seteare el Bloque actual
        LevelBlock currentBlock;
        //Vector donde nacera el bloque de valor (0,0,0) inicial

        if(currentLevelBlocks.Count == 0){
            //Escoge un numero aleatorio de todos los bloques disponibles
            randomIndex = Random.Range(0, allInitialBlocks.Count);
            //Instancio el primer bloque ya que en la lista de bloques actuales no hay ninguno
            //Esto permite que se inicie con un bloque especifico como el bloque que contiene 
            //el suelo completo
            currentBlock = (LevelBlock)Instantiate(allInitialBlocks[randomIndex]);
            //El bloque instanciado lo haremos hijo del LevelManager
            currentBlock.transform.SetParent(this.transform, false);
            //La posicion de spawn lo setearemos con la posicion inicial del nivel
            //Ya que se trata del primer bloque
            spawnPosition = levelStartPoint.position;
        }
        else if(currentLevelBlocks.Count < numberInitialBlocks - 1){
            //Escoge un numero aleatorio de todos los bloques disponibles
            randomIndex = Random.Range(0, allTheLevelBlocks.Count);
            //Si existen bloques dentro de la lista de bloques actuales entonces se instanciara
            //Un bloque aleatorio de  todos los bloques disponibles
            currentBlock = (LevelBlock)Instantiate(allTheLevelBlocks[randomIndex]);
            //De igual forma lo convertiremos hijo del LevelManager
            currentBlock.transform.SetParent(this.transform, false);
            //La posicion de spawn sera restando la posicion final del ultimo bloque instanciado
            //Con la posicion inicial del bloque
            spawnPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].endPosition.position 
                            - currentBlock.startPosition.position;
        }else{
            //Escoge un numero aleatorio de todos los bloques disponibles
            randomIndex = Random.Range(0, allFinalBlocks.Count);
            //Si existen bloques dentro de la lista de bloques actuales entonces se instanciara
            //Un bloque aleatorio de  todos los bloques disponibles
            currentBlock = (LevelBlock)Instantiate(allFinalBlocks[randomIndex]);
            //De igual forma lo convertiremos hijo del LevelManager
            currentBlock.transform.SetParent(this.transform, false);
            //La posicion de spawn sera restando la posicion final del ultimo bloque instanciado
            //Con la posicion inicial del bloque
            spawnPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].endPosition.position 
                            - currentBlock.startPosition.position;
        }

        //Cambio la posicion del nuevo bloque a la posicion de spawn
        currentBlock.transform.position = spawnPosition;
        //Lo añado a la lista de bloqueas actuales
        currentLevelBlocks.Add(currentBlock);
    }

    public void RemoveOldestBlock(){
        //Instancio un bloque que tomara el valor del bloque 0
        LevelBlock oldestBlock = currentLevelBlocks[0];
        //Remuevo el primer bloque añadido a la lista de bloques actuales
        //Cuando remuevo el primero, el segundo pasa a ser el primero
        currentLevelBlocks.Remove(oldestBlock);
        //Destruyo su gameObject para que desaparesca de la escena
        Destroy(oldestBlock.gameObject);
    }

    void RemoveAllLevelBlocks(){
        for(int i=0; i< numberInitialBlocks; i++){
            RemoveOldestBlock();
        }  
    }

    public void RemakeLevel(){
        RemoveAllLevelBlocks();
        GenerateInitialBlocks(numberInitialBlocks);
    }
}
