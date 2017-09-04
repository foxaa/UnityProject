using UnityEngine;

[CreateAssetMenu(menuName = "Collectable Object")]
public class CollectableRef : ScriptableObject
{

	public GameObject objectPrefab;
	public Texture objectImage;
	public string names;
	public int damage;
	public int healPoints;
	public bool inUse=false;

}
