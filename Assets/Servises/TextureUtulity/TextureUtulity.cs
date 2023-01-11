using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Servises.TextureUtulity
{
    public static class TextureUtulity
    {
        public static string Texture2DToString(Texture2D texture2D)
        {
            byte[] bArray = texture2D.GetRawTextureData();
            return System.Convert.ToBase64String(bArray);
        }

        public static Texture2D StringToTexture2D(string Data)
        {
            byte[] d = System.Convert.FromBase64String(Data);
            Texture2D tex = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            tex.LoadRawTextureData(d);
            return tex;
        }

    }
}