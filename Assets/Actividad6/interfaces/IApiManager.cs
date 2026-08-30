
using System.Threading.Tasks;
using UnityEngine;

public interface IApiManager
{
    Task<Texture2D> GetTexture(string url);
}
