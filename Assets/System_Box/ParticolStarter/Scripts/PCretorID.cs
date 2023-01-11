using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace SystemBox.ObjectCretor
{
    [System.Serializable]
    [HideLabel]
    public struct PCretorID
    {
        [ValueDropdown("GetAllIDs")]
        public string ID;
        public GameObject PlayParticol(Vector3 pos) => ParticolCretor.PlayParticol(ID, pos);
        private static List<string> GetAllIDs()
        {
            List<string> ids = new List<string>();
            Particolresurses.Item.ForEach(item => { ids.Add(item.Name); });
            return ids;
        }
        public static implicit operator string(PCretorID Me) => Me.ID;
    }
}
