
using UnityEngine;
using System.Threading.Tasks;

public interface IModelUserInfo
{
    Persona GetAgentWithUsername(string username);
    Task<Sprite> GetAgentImage(string imageURL);
}
