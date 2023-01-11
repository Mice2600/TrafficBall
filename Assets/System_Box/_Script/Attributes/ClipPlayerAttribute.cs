using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SystemBox
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class ClipPlayerAttribute : PropertyAttribute
    {

        public bool Hidelabel;
        public string Costumelabel;
        public TextAlignment TextAlignment; 
        public bool HorizontalLine; 
        public bool BoldLabel; 
        public ClipPlayerAttribute() { }
        public ClipPlayerAttribute(bool Hidelabel = false, string Costumelabel = "", TextAlignment TextAlignment = TextAlignment.Left, bool BoldLabel = false, bool HorizontalLine = false) 
        {
            this.Hidelabel = Hidelabel;
            this.Costumelabel = Costumelabel;
            this.TextAlignment = TextAlignment;
            this.BoldLabel = BoldLabel;
            this.HorizontalLine = HorizontalLine;
        }
    }
}
