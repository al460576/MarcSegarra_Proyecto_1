using UnityEngine;
using UnityEngine.Tilemaps;


public class RecogerObjetos : MonoBehaviour
{
    public Tilemap tilemapObjetos;
    public int puntosTile = 25;
    public int totalObjetos = 5;
    public Tilemap arbol1;
    public Tilemap arbol2;
    private int objetosRecogidos = 0;

    void Star()
    {
        arbol2.gameObject.SetActive(false);
    }

    void Update()
    {
        Vector3Int posicion = tilemapObjetos.WorldToCell(transform.position);
        if (tilemapObjetos.HasTile(posicion))
        {
            tilemapObjetos.SetTile(posicion, null);
            Puntuacion.instancia.SumarPuntos(puntosTile);
            objetosRecogidos++;
            if (objetosRecogidos >= totalObjetos)
            {
                Vector3Int posArbol = arbol1.WorldToCell(transform.position);
                if (arbol1.HasTile(posArbol))
                {
                    arbol1.gameObject.SetActive(false);
                    arbol2.gameObject.SetActive(true);
                }   
            }
        }
        
    }
}
